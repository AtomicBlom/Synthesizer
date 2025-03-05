using Synthesizer.Data;
using static Synthesizer.SongBuilding.NoteFrequency;
using static Synthesizer.SongBuilding.ShortHand;

namespace Synthesizer;

public static class DemoSong
{
    public static Song TestSong()
    {
        return new Song
        {
            BeatsPerMinute = 128,
            TicksPerBeat = 2,
            BeatsPerBar = 4,
            LoopToBar = 0,
            Instruments =
            [
                new InstrumentDefinition
                {
                    Type = InstrumentType.SawtoothWave,
                    Envelope = new ADSR
                    {
                        AttackTimeMs = 0,
                        DecayTimeMs = 0,
                        SustainLevel = 0.7f,
                        ReleaseTimeMs = 100,
                        IsHeld = true
                    }
                }
            ],
            PatternSequence = new[,]
            {
                { 1 },
                { 0 }
            },
            Patterns =
            [
                new Pattern
                {
                    InstrumentDefinition = 0,
                    Notes = new[,]
                    {

                        {A4, D , D , R  },
                        {R , C5, D , D  },
                        {D , R , G5, D  },
                        {D , D , R , D  },
                        {D , A5, D , D  },
                        {D , R , D , D  },
                        {D , D , D , N(C6, 0.8) },
                        {D , D , D , E6 },

                        {G4, D , D , R  },
                        {R , B4, D , D  },
                        {D , R , D5, D  },
                        {D , D , R , D  },
                        {D , G5, D , D  },
                        {D , R , D , D  },
                        {D , D , D , N(B5, 0.8) },
                        {D , D , D , D6 },

                        {E4, D , D , R  },
                        {R , G4, D , D  },
                        {D , R , B4, D  },
                        {D , D , R , D  },
                        {D , E5, D , D  },
                        {D , R , D , D  },
                        {D , D , D , N(A5, 0.8) },
                        {D , D , D , B5 },

                        {F4, D , D , R  },
                        {R , A4, D , D  },
                        {D , R , C5, D  },
                        {D , D , R , D  },
                        {D , F5, D , D  },
                        {D , R , D , D  },
                        {D , D , D , N(B5, 0.8) },
                        {D , D , D , C6 },
                    }
                }
            ]
        };
    }

    public static Song MakeSong()
    {
        // Define instruments
        var instruments = new[]
        {
            new InstrumentDefinition
            {
                Type = InstrumentType.SineWave,
                Envelope = new ADSR
                {
                    AttackTimeMs = 50,
                    DecayTimeMs = 100,
                    SustainLevel = 0.7f,
                    ReleaseTimeMs = 200,
                    IsHeld = false
                }
            },
            new InstrumentDefinition
            {
                Type = InstrumentType.SquareWave,
                Envelope = new ADSR
                {
                    AttackTimeMs = 10,
                    DecayTimeMs = 50,
                    SustainLevel = 0.5f,
                    ReleaseTimeMs = 300,
                    IsHeld = true
                }
            },
            new InstrumentDefinition
            {
                Type = InstrumentType.Noise,
                Envelope = new ADSR
                {
                    AttackTimeMs = 5,
                    DecayTimeMs = 20,
                    SustainLevel = 0.3f,
                    ReleaseTimeMs = 100,
                    IsHeld = false
                }
            }
        };

        // Define patterns
        var patterns = new[]
        {
            new Pattern
            {
                InstrumentDefinition = 0,
                Notes = new[,]
                {
                    { new Note { Frequency = 440.0f, Retrigger = true } }, // A4
                    { new Note { Frequency = 493.88f, Retrigger = true } }, // B4
                    { new Note { Frequency = 523.25f, Retrigger = true } }, // C5
                    { new Note { Frequency = 587.33f, Retrigger = true } }, // D5
                    { new Note { Frequency = 659.25f, Retrigger = true } }, // E5
                    { new Note { Frequency = 698.46f, Retrigger = true } }, // F5
                    { new Note { Frequency = 783.99f, Retrigger = true } }, // G5
                    { new Note { Frequency = 880.0f, Retrigger = true } }, // A5
                    { new Note { Frequency = 987.77f, Retrigger = true } }, // B5
                    { new Note { Frequency = 1046.5f, Retrigger = true } }, // C6
                    { new Note { Frequency = 1174.66f, Retrigger = true } }, // D6
                    { new Note { Frequency = 1318.51f, Retrigger = true } }, // E6
                    { new Note { Frequency = 1396.91f, Retrigger = true } }, // F6
                    { new Note { Frequency = 1567.98f, Retrigger = true } }, // G6
                    { new Note { Frequency = 1760.0f, Retrigger = true } }, // A6
                    { new Note { Frequency = 1975.53f, Retrigger = true } } // B6
                }
            },
            new Pattern
            {
                InstrumentDefinition = 1,
                Notes = new[,]
                {
                    { new Note { Frequency = 261.63f, Retrigger = true } }, // C4
                    { new Note { Frequency = 293.66f, Retrigger = true } }, // D4
                    { new Note { Frequency = 329.63f, Retrigger = true } }, // E4
                    { new Note { Frequency = 349.23f, Retrigger = true } }, // F4
                    { new Note { Frequency = 392.0f, Retrigger = true } }, // G4
                    { new Note { Frequency = 440.0f, Retrigger = true } }, // A4
                    { new Note { Frequency = 493.88f, Retrigger = true } }, // B4
                    { new Note { Frequency = 523.25f, Retrigger = true } }, // C5
                    { new Note { Frequency = 587.33f, Retrigger = true } }, // D5
                    { new Note { Frequency = 659.25f, Retrigger = true } }, // E5
                    { new Note { Frequency = 698.46f, Retrigger = true } }, // F5
                    { new Note { Frequency = 783.99f, Retrigger = true } }, // G5
                    { new Note { Frequency = 880.0f, Retrigger = true } }, // A5
                    { new Note { Frequency = 987.77f, Retrigger = true } }, // B5
                    { new Note { Frequency = 1046.5f, Retrigger = true } }, // C6
                    { new Note { Frequency = 1174.66f, Retrigger = true } } // D6
                }
            },
            new Pattern
            {
                InstrumentDefinition = 2,
                Notes = new[,]
                {
                    { new Note { Frequency = 130.81f, Retrigger = true } }, // C3
                    { new Note { Frequency = 146.83f, Retrigger = true } }, // D3
                    { new Note { Frequency = 164.81f, Retrigger = true } }, // E3
                    { new Note { Frequency = 174.61f, Retrigger = true } }, // F3
                    { new Note { Frequency = 196.0f, Retrigger = true } }, // G3
                    { new Note { Frequency = 220.0f, Retrigger = true } }, // A3
                    { new Note { Frequency = 246.94f, Retrigger = true } }, // B3
                    { new Note { Frequency = 261.63f, Retrigger = true } }, // C4
                    { new Note { Frequency = 293.66f, Retrigger = true } }, // D4
                    { new Note { Frequency = 329.63f, Retrigger = true } }, // E4
                    { new Note { Frequency = 349.23f, Retrigger = true } }, // F4
                    { new Note { Frequency = 392.0f, Retrigger = true } }, // G4
                    { new Note { Frequency = 440.0f, Retrigger = true } }, // A4
                    { new Note { Frequency = 493.88f, Retrigger = true } }, // B4
                    { new Note { Frequency = 523.25f, Retrigger = true } }, // C5
                    { new Note { Frequency = 587.33f, Retrigger = true } } // D5
                }
            }
        };

        // Define pattern sequence
        var patternSequence = new[,]
        {
            { 1, 2, 3 },
            { 2, 3, 1 },
            { 3, 1, 2 }
        };

        // Create and return the song
        return new Song
        {
            BeatsPerMinute = 60,
            TicksPerBeat = 4,
            BeatsPerBar = 4,
            PatternSequence = patternSequence,
            Patterns = patterns,
            Instruments = instruments
        };
    }
}