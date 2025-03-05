using Synthesizer.Data;

namespace Synthesizer.SongBuilding;

internal static class ShortHand
{
    public static Note N(NoteFrequency frequency) => new() { Frequency = frequency, Retrigger = true };
    public static Note N(NoteFrequency frequency, double amplitude) => new() { Frequency = frequency, Retrigger = true, Amplitude = (float)amplitude};
    public static Note P(NoteFrequency frequency) => new() { Frequency = frequency };
    public static Note R => new() { Release = true };
    public static Note D => default;

    public static Retrigger RT => default;

    public struct Retrigger();
}