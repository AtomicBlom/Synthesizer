using NAudio.Wave;
using Synthesizer.Data;
using Synthesizer.SongBuilding;

namespace Synthesizer;

public class BasicSynth : ISampleProvider
{
    private readonly Song _song;
    private float _amplitude = 1.0f;
    private ADSR _envelope;
    private float _envelopePosition;

    private float _frequency = 440.0f;

    private int _sample;
    private int _polyphonyColumn;
    private PositionInSynthBuffer _position;
    private bool _released;
    private InstrumentType _type;

    public BasicSynth(Song song)
    {
        _song = song;
        WaveFormat = WaveFormat.CreateIeeeFloatWaveFormat(44100, 1);
    }

    public bool IsActive { get; private set; }
    public float Frequency => _frequency;
    
    public WaveFormat WaveFormat { get; }
    public bool Held => !_released;

    public int Read(float[] buffer, int offset, int sampleCount)
    {
        if (!IsActive)
        {
            return 0;
        }

        var sampleRate = WaveFormat.SampleRate;
        var samplesRead = 0;

        for (var n = 0; n < sampleCount; n++)
        {
            float sampleValue = GetSample(_type, _sample, _frequency, _amplitude, WaveFormat.SampleRate);

            buffer[n + offset] = sampleValue * _envelope.GetEnvelope(_envelopePosition, _released, out var progressEnvelopeTime, out var ended);
            _sample++;
            samplesRead++;

            if (progressEnvelopeTime)
            {
                _envelopePosition += 1000.0f / sampleRate;
            }
            
            if (ended)
            {
                IsActive = false;
                return samplesRead;
            }
            
            var metrics = PositionInSynthBuffer.AdvanceSample(_song, ref _position);
            if (metrics.NextTick)
            {
                UpdateCurrentNote();
            }
        }

        

        return samplesRead;
    }

    private static float GetSample(InstrumentType type, int sample, float frequency, float amplitude, int waveFormatSampleRate)
    {
        float sampleValue = 0;
        float t = (float)sample / waveFormatSampleRate;
        float phase = 2 * MathF.PI * frequency * t;

        switch (type)
        {
            case InstrumentType.SineWave:
                sampleValue = amplitude * MathF.Sin(phase);
                break;
            case InstrumentType.SquareWave:
                sampleValue = amplitude * MathF.Sign(MathF.Sin(phase));
                break;
            case InstrumentType.SawtoothWave:
                sampleValue = amplitude * (2 * (t * frequency - MathF.Floor(0.5f + t * frequency)));
                break;
            case InstrumentType.Noise:
                sampleValue = amplitude * (2 * (float)new Random().NextDouble() - 1);
                break;
            case InstrumentType.Sample:
                // Handle sample-based instruments if needed
                break;
        }

        return sampleValue;
    }

    public void Reset(
        int songInstrumentNumber,
        PositionInPatternSequenceColumn currentPatternTick,
        int patternSequenceColumn,
        int polyphonyColumn
    )
    {
        var ticksPerMinute = _song.BeatsPerMinute * _song.TicksPerBeat;
        var samplesPerMinute = WaveFormat.SampleRate * 60;
        var instrument = _song.Instruments[songInstrumentNumber];

        _position = new PositionInSynthBuffer(currentPatternTick, samplesPerMinute / ticksPerMinute);

        _polyphonyColumn = polyphonyColumn;
        _envelope = instrument.Envelope;
        _type = instrument.Type;

        _frequency = NoteFrequency.A4;
        _amplitude = 1.0f;
        _sample = 0;
        _envelopePosition = 0;
        _released = false;

        UpdateCurrentNote();
    }

    private void UpdateCurrentNote()
    {
        if (_position.Tick.TryGetPattern(_song, out var pattern))
        {
            var currentNote = pattern.Notes[_position.Tick.CurrentRowInPattern, _polyphonyColumn];
            _frequency = currentNote.Frequency ?? _frequency; // Default to A4 if frequency is not set
            _amplitude = currentNote.Amplitude ?? _amplitude; // Default to full amplitude if not set
            IsActive = true;
            if (currentNote.Release)
            {
                _released = true;
            }
        }
        else
        {
            _released = true;
        }
    }
}