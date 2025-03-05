using Synthesizer.Data;

namespace Synthesizer;

public struct PositionInSynthBuffer
{
    public PositionInPatternSequenceColumn Tick;
    public int SamplesPerTick; //The sample rate of the synth

    //Only used inside of Synths
    public int SampleInTick = 0; //The sample within the tick
    //public int CurrentTickNoteIndex = 0; //The index of the note within the pattern for the current tick

    public PositionInSynthBuffer(PositionInPatternSequenceColumn positionInPatternSequenceColumn, int samplesPerTick)
    {
        Tick = positionInPatternSequenceColumn;
        SamplesPerTick = samplesPerTick;
    }

    public static PositionInSynthBufferMetrics AdvanceSample(in Song song, ref PositionInSynthBuffer position)
    {
        PositionInSynthBufferMetrics result = default;
        position.SampleInTick++;
        if (position.SampleInTick >= position.SamplesPerTick)
        {
            result.NextTick = true;
            position.SampleInTick = 0;
            var previousPattern = position.Tick.CurrentPatternIndex;
            PositionInPatternSequenceColumn.AdvanceTick(song, ref position.Tick);

            //if (previousPattern != position.Tick.CurrentPatternIndex)
            //{
            //    position.CurrentTickNoteIndex = 0;
            //}
            //else
            //{
            //    position.CurrentTickNoteIndex++;
            //}
        }

        return result;
    }
}