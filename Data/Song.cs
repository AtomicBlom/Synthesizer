namespace Synthesizer.Data;

public struct Song
{
    public int BeatsPerMinute = 120;
    public int TicksPerBeat = 4;
    public int BeatsPerBar = 4;

    public int[,] PatternSequence = new int[0,0];
    public Pattern[] Patterns = [];
    public InstrumentDefinition[] Instruments = [];

    public int LoopToBar = -1;

    public Song()
    {
    }
}