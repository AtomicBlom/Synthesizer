namespace Synthesizer.Data;

public struct ADSR
{
    public float AttackTimeMs;
    public float DecayTimeMs;
    public float SustainLevel;
    public float ReleaseTimeMs;
    public bool IsHeld;
}

public static class ADSRExtensions
{
    public static float GetLength(this ADSR envelope)
    {
        return envelope.AttackTimeMs + envelope.DecayTimeMs + envelope.ReleaseTimeMs;
    }

    public static float GetEnvelope(this ADSR envelope, float envelopeTime, bool isReleased,
        out bool progressEnvelopeTime, out bool ended)
    {
        ended = false;
        progressEnvelopeTime = true;
        if (envelopeTime < envelope.AttackTimeMs)
        {
            return envelopeTime / envelope.AttackTimeMs;
        }
        else if (envelopeTime < envelope.AttackTimeMs + envelope.DecayTimeMs)
        {
            return 1.0f + (envelope.SustainLevel - 1.0f) *
                (envelopeTime - envelope.AttackTimeMs) / envelope.DecayTimeMs;
        }
        else if (envelopeTime < envelope.AttackTimeMs + envelope.DecayTimeMs + envelope.ReleaseTimeMs)
        {
            if (isReleased || !envelope.IsHeld)
            {
                return envelope.SustainLevel *
                       (1 - (envelopeTime - envelope.AttackTimeMs - envelope.DecayTimeMs) / envelope.ReleaseTimeMs);
            }
            else
            {
                progressEnvelopeTime = false;
                return envelope.SustainLevel;
            }
        }
        else
        {
            ended = true;
            return 0;
        }
    }
}