using Synthesizer.Data;

namespace Synthesizer;

public struct PositionInSong
{
    public int Bar = 0; //Corresponds to the row in the pattern sequence
    public int BeatInBar = 0; //Corresponds to the beat within the bar
    public int TickInBeat = 0; //Corresponds to the tick within the beat

    public PositionInSong()
    {
    }

    public static PositionInSongMetrics AdvanceTick(in Song song, ref PositionInSong position)
    {
        PositionInSongMetrics results = default;
        position.TickInBeat++;
        if (position.TickInBeat >= song.TicksPerBeat)
        {
            position.TickInBeat = 0;
            position.BeatInBar++;
            results.NextBeat = true;

            if (position.BeatInBar >= song.BeatsPerBar)
            {
                position.BeatInBar = 0;
                position.Bar++;
                results.NextBar = true;

                var barsInSong = song.PatternSequence.GetLength(0);
                if (position.Bar >= barsInSong)
                {
                    if (song.LoopToBar >= 0)
                    {
                        position.Bar = song.LoopToBar; // Loop the song
                    }
                    else
                    {
                        results.SongEnded = true;
                    }
                }
            }
        }

        return results;
    }
}