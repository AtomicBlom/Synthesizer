namespace Synthesizer;

public interface IAmplitudeProvider
{
    float Frequency { get; set; }
    void SetWaveFormat(int frequency, int channels);
}