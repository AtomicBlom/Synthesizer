using Synthesizer.Data;

namespace Synthesizer;

public struct PositionInPatternSequenceColumn(int patternSequenceColumn, PositionInSong positionInSong)
{
    public PositionInSong PositionInSong = positionInSong;
    public int PatternSequenceColumn = patternSequenceColumn;
    
    public int BeatInPattern = 0; //Corresponds to the beat within the pattern
    public int? CurrentPatternIndex = 0; //Corresponds with song.TicksPerBeat * BeatInPattern + TickInBeat
    public int CurrentRowInPattern = 0;
    public bool ValidPatternIndex = true;

    public static void AdvanceTick(in Song song, ref PositionInPatternSequenceColumn position)
    {
        var metrics = PositionInSong.AdvanceTick(song, ref position.PositionInSong);
        position.CurrentRowInPattern++;

        if (metrics.NextBeat)
        {
            position.BeatInPattern++;
        }

        if (metrics.NextBar)
        {
            var barsInSong = song.PatternSequence.GetLength(0);
            if (position.PositionInSong.Bar < barsInSong)
            {
                var sequenceColumnEntry = song.PatternSequence[position.PositionInSong.Bar, position.PatternSequenceColumn];
                if (sequenceColumnEntry > 0)
                {
                    position.CurrentPatternIndex = sequenceColumnEntry - 1;
                    position.BeatInPattern = 0;
                    position.CurrentRowInPattern = 0;
                    position.ValidPatternIndex = true;
                }

                if (position.CurrentPatternIndex is not null)
                {
                    if (position.CurrentRowInPattern >= song.Patterns[position.CurrentPatternIndex.Value].Notes.GetLength(0))
                    {
                        position.ValidPatternIndex = false;
                        position.CurrentPatternIndex = null;
                        position.CurrentRowInPattern = 0;
                    }
                }
                else
                {
                    position.ValidPatternIndex = false;
                    position.CurrentPatternIndex = null;
                }
            }
        }
    }

    public bool TryGetPattern(Song song, out Pattern pattern)
    {
        if (ValidPatternIndex && CurrentPatternIndex is not null)
        {
            pattern = song.Patterns[CurrentPatternIndex.Value];
            return true;
        }

        pattern = default;
        return false;
    }
}