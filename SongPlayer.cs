using System.Diagnostics;
using NAudio.Wave.SampleProviders;
using Synthesizer.Data;
using Synthesizer.SongBuilding;

namespace Synthesizer;

public class SongPlayer
{
    private readonly MixingSampleProvider _mixer;
    private readonly Song _song;
    private readonly Queue<BasicSynth> _synthPool = new();
    private readonly List<BasicSynth> _activeSynths = new();

    private PositionInSong _currentPosition;
    private readonly CurrentPattern[] _currentPatterns;

    public SongPlayer(Song song, MixingSampleProvider mixer)
    {
        _song = song;
        _mixer = mixer;
        _currentPatterns = new CurrentPattern[_song.PatternSequence.GetLength(1)];
        _currentPosition = new();
        for (int sequenceColumn = 0; sequenceColumn < _currentPatterns.Length; sequenceColumn++)
        {
            var currentPatternIndex = song.PatternSequence[_currentPosition.Bar, sequenceColumn];
            _currentPatterns[sequenceColumn] = new CurrentPattern(new PositionInPatternSequenceColumn()
            {
                PatternSequenceColumn = sequenceColumn
            })
            {
                Tick =
                {
                    CurrentPatternIndex = currentPatternIndex == 0 ? null : currentPatternIndex - 1,
                    ValidPatternIndex = currentPatternIndex != 0
                },
                Active = currentPatternIndex != 0
            };
        }
    }

    public void Play()
    {
        var stopwatch = Stopwatch.StartNew();
        stopwatch.Start();
        // Main playback loop
        while (true)
        {
            stopwatch.Restart();
            // Iterate over each currently playing pattern
            for (int col = 0; col < _currentPatterns.Length; col++)
            {
                var currentPattern = _currentPatterns[col];
                if (currentPattern.Active && currentPattern.Tick.TryGetPattern(_song, out var pattern))
                {
                    // Trigger notes
                    for (var polyphonyColumn = 0; polyphonyColumn < pattern.Notes.GetLength(1); polyphonyColumn++)
                    {
                        if (currentPattern.Tick.CurrentRowInPattern < pattern.Notes.GetLength(0))
                        {
                            var note = pattern.Notes[currentPattern.Tick.CurrentRowInPattern, polyphonyColumn];
                            if (note.Retrigger)
                            {
                                var synth = GetSynthFromPool();
                                synth.Reset(pattern.InstrumentDefinition, currentPattern.Tick, col, polyphonyColumn);
                                _mixer.AddMixerInput(synth);
                                _activeSynths.Add(synth);
                            }
                        }
                        else
                        {
                            currentPattern.Active = false;
                        }
                    }
                }
            }

            // Remove inactive synths
            for (var i = _activeSynths.Count - 1; i >= 0; i--)
            {
                var synth = _activeSynths[i];
                if (!synth.IsActive)
                {
                    _mixer.RemoveMixerInput(synth);
                    _synthPool.Enqueue(synth);
                    _activeSynths.RemoveAt(i);
                }
            }

            Console.Clear();
            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"{_currentPosition.Bar}:{_currentPosition.BeatInBar}:{_currentPosition.TickInBeat} - {_activeSynths.Count}");
            for (int i = 0; i < _activeSynths.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                //convert frequency to note
                var note = NoteFrequency.GetNoteFromFrequency(_activeSynths[i].Frequency);

                Console.Write($"{note} ");
                Console.ForegroundColor = _activeSynths[i].Held ? ConsoleColor.Green : ConsoleColor.Red;
                Console.Write("█ ");
            }

            // Delay until next tick
            Thread.Sleep(TimeSpan.FromSeconds(60f / _song.BeatsPerMinute / _song.TicksPerBeat) - TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds));

            var metrics = PositionInSong.AdvanceTick(_song, ref _currentPosition);
            for (var i = 0; i < _currentPatterns.Length; i++)
            {
                ref var currentPattern = ref _currentPatterns[i];
                PositionInPatternSequenceColumn.AdvanceTick(_song, ref currentPattern.Tick);
            }
        }
    }

    private BasicSynth GetSynthFromPool()
    {
        BasicSynth basicSynth;
        if (_synthPool.Any())
        {
            basicSynth = _synthPool.Dequeue();
        }
        else
        {
            basicSynth = new BasicSynth(_song);
        }

        return basicSynth;
    }
}
