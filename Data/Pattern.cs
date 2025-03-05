namespace Synthesizer.Data;

public struct Pattern
{
    public Note[,] Notes = new Note[16, 1];
    public int InstrumentDefinition = 0;
    public Pattern()
    {
    }
}