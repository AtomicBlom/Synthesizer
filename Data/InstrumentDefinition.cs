namespace Synthesizer.Data;

public struct InstrumentDefinition
{
    public InstrumentType Type = InstrumentType.SineWave;

    public ADSR Envelope = new ADSR();

    public InstrumentDefinition()
    {
    }
}