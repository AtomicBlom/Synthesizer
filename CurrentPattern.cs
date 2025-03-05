namespace Synthesizer;

public struct CurrentPattern(PositionInPatternSequenceColumn tick)
{
    public PositionInPatternSequenceColumn Tick = tick;
    public bool Active = false;
}