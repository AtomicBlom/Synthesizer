namespace Synthesizer.Data;

public struct Note
{
    public bool Retrigger = false;
    public float? Frequency = null;
    public bool Release = false;
    public float? Amplitude = 1.0f;

    public Note()
    {
    }
}