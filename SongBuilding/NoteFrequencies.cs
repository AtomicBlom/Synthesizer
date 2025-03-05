using Synthesizer.Data;

namespace Synthesizer.SongBuilding;

public record struct NoteFrequency(float Frequency)
{
    public static NoteFrequency C0 = 16.35f;
    public static NoteFrequency CSharp0 = 17.32f;
    public static NoteFrequency D0 = 18.35f;
    public static NoteFrequency DSharp0 = 19.45f;
    public static NoteFrequency E0 = 20.60f;
    public static NoteFrequency F0 = 21.83f;
    public static NoteFrequency FSharp0 = 23.12f;
    public static NoteFrequency G0 = 24.50f;
    public static NoteFrequency GSharp0 = 25.96f;
    public static NoteFrequency A0 = 27.50f;
    public static NoteFrequency ASharp0 = 29.14f;
    public static NoteFrequency B0 = 30.87f;
    public static NoteFrequency C1 = 32.70f;
    public static NoteFrequency CSharp1 = 34.65f;
    public static NoteFrequency D1 = 36.71f;
    public static NoteFrequency DSharp1 = 38.89f;
    public static NoteFrequency E1 = 41.20f;
    public static NoteFrequency F1 = 43.65f;
    public static NoteFrequency FSharp1 = 46.25f;
    public static NoteFrequency G1 = 49.00f;
    public static NoteFrequency GSharp1 = 51.91f;
    public static NoteFrequency A1 = 55.00f;
    public static NoteFrequency ASharp1 = 58.27f;
    public static NoteFrequency B1 = 61.74f;
    public static NoteFrequency C2 = 65.41f;
    public static NoteFrequency CSharp2 = 69.30f;
    public static NoteFrequency D2 = 73.42f;
    public static NoteFrequency DSharp2 = 77.78f;
    public static NoteFrequency E2 = 82.41f;
    public static NoteFrequency F2 = 87.31f;
    public static NoteFrequency FSharp2 = 92.50f;
    public static NoteFrequency G2 = 98.00f;
    public static NoteFrequency GSharp2 = 103.83f;
    public static NoteFrequency A2 = 110.00f;
    public static NoteFrequency ASharp2 = 116.54f;
    public static NoteFrequency B2 = 123.47f;
    public static NoteFrequency C3 = 130.81f;
    public static NoteFrequency CSharp3 = 138.59f;
    public static NoteFrequency D3 = 146.83f;
    public static NoteFrequency DSharp3 = 155.56f;
    public static NoteFrequency E3 = 164.81f;
    public static NoteFrequency F3 = 174.61f;
    public static NoteFrequency FSharp3 = 185.00f;
    public static NoteFrequency G3 = 196.00f;
    public static NoteFrequency GSharp3 = 207.65f;
    public static NoteFrequency A3 = 220.00f;
    public static NoteFrequency ASharp3 = 233.08f;
    public static NoteFrequency B3 = 246.94f;
    public static NoteFrequency C4 = 261.63f;
    public static NoteFrequency CSharp4 = 277.18f;
    public static NoteFrequency D4 = 293.66f;
    public static NoteFrequency DSharp4 = 311.13f;
    public static NoteFrequency E4 = 329.63f;
    public static NoteFrequency F4 = 349.23f;
    public static NoteFrequency FSharp4 = 369.99f;
    public static NoteFrequency G4 = 392.00f;
    public static NoteFrequency GSharp4 = 415.30f;
    public static NoteFrequency A4 = 440.00f;
    public static NoteFrequency ASharp4 = 466.16f;
    public static NoteFrequency B4 = 493.88f;
    public static NoteFrequency C5 = 523.25f;
    public static NoteFrequency CSharp5 = 554.37f;
    public static NoteFrequency D5 = 587.33f;
    public static NoteFrequency DSharp5 = 622.25f;
    public static NoteFrequency E5 = 659.25f;
    public static NoteFrequency F5 = 698.46f;
    public static NoteFrequency FSharp5 = 739.99f;
    public static NoteFrequency G5 = 783.99f;
    public static NoteFrequency GSharp5 = 830.61f;
    public static NoteFrequency A5 = 880.00f;
    public static NoteFrequency ASharp5 = 932.33f;
    public static NoteFrequency B5 = 987.77f;
    public static NoteFrequency C6 = 1046.50f;
    public static NoteFrequency CSharp6 = 1108.73f;
    public static NoteFrequency D6 = 1174.66f;
    public static NoteFrequency DSharp6 = 1244.51f;
    public static NoteFrequency E6 = 1318.51f;
    public static NoteFrequency F6 = 1396.91f;
    public static NoteFrequency FSharp6 = 1479.98f;
    public static NoteFrequency G6 = 1567.98f;
    public static NoteFrequency GSharp6 = 1661.22f;
    public static NoteFrequency A6 = 1760.00f;
    public static NoteFrequency ASharp6 = 1864.66f;
    public static NoteFrequency B6 = 1975.53f;
    public static NoteFrequency C7 = 2093.00f;
    public static NoteFrequency CSharp7 = 2217.46f;
    public static NoteFrequency D7 = 2349.32f;
    public static NoteFrequency DSharp7 = 2489.02f;
    public static NoteFrequency E7 = 2637.02f;
    public static NoteFrequency F7 = 2793.83f;
    public static NoteFrequency FSharp7 = 2959.96f;
    public static NoteFrequency G7 = 3135.96f;
    public static NoteFrequency GSharp7 = 3322.44f;
    public static NoteFrequency A7 = 3520.00f;
    public static NoteFrequency ASharp7 = 3729.31f;
    public static NoteFrequency B7 = 3951.07f;
    public static NoteFrequency C8 = 4186.01f;
    public static NoteFrequency CSharp8 = 4434.92f;
    public static NoteFrequency D8 = 4698.63f;
    public static NoteFrequency DSharp8 = 4978.03f;

    //implicit conversion from float
    public static implicit operator NoteFrequency(float value) => new NoteFrequency(value);
    //implicit conversion to float
    public static implicit operator float(NoteFrequency value) => value.Frequency;

    //implicit conversion to Note
    public static implicit operator Note(NoteFrequency value) => new Note { Frequency = value, Retrigger = true };

    public static string GetNoteFromFrequency(float frequency)
    {
        //convert a frequency to a note name, e.g, 440 -> A4
        var note = (int)Math.Round(12 * Math.Log(frequency / 440.0f) / Math.Log(2) + 49);
        var octave = (note / 12) - 1;
        var noteIndex = note % 12;
        var noteName = noteIndex switch
        {
            0 => "C ",
            1 => "C#",
            2 => "D ",
            3 => "D#",
            4 => "E ",
            5 => "F ",
            6 => "F#",
            7 => "G ",
            8 => "G#",
            9 => "A ",
            10 => "A#",
            11 => "B ",
            _ => throw new ArgumentOutOfRangeException()
        };

        return $"{noteName}{octave}";
    }
}
