using RimWorld;
using UnityEngine;
using Verse;

namespace BeautyStatMod;

public class StatPartBeautyOffsets : StatPart
{
    public float startsAt = 0.01f;
    public float endsAt = -0.01f;

    public override void TransformValue(StatRequest req, ref float val)
    {
        if (TryGetBeauty(req.Thing, out var offset))
        {
            val += offset;
        }
    }

    public override string ExplanationPart(StatRequest req)
    {
        if (req.HasThing && TryGetBeauty(req.Thing, out var offset))
        {
            return "Pawn Beauty Multiplier" + (": +" + offset.ToStringPercent());
        }
        return null;
    }

    private bool TryGetBeauty(Thing t, out float offset)
    {
        if (t is Pawn pawn)
        {
            float num = pawn.GetStatValue(StatDefOf.PawnBeauty);
            if (parentStat.Equals(StatDefOf.SocialImpact))
            {
                float num1 = LoadedModManager.GetMod<BeautyStatMod>().GetSettings<BeautyStatSettings>().SocialImpactStatFactor / 100f;
                offset = num * num1;
                return true;
            }
            if (parentStat.Equals(StatDefOf.NegotiationAbility))
            {
                float num1 = LoadedModManager.GetMod<BeautyStatMod>().GetSettings<BeautyStatSettings>().NegotiationStatFactor / 100f;
                offset = num * num1;
                return true;
            }
            if (parentStat.Equals(StatDefOf.SuppressionPower))
            {
                float num1 = LoadedModManager.GetMod<BeautyStatMod>().GetSettings<BeautyStatSettings>().SuppressionStatFactor / 100f;
                offset = num * num1;
                return true;
            }
            if (parentStat.Equals(StatDefOf.ConversionPower))
            {
                float num1 = LoadedModManager.GetMod<BeautyStatMod>().GetSettings<BeautyStatSettings>().ConversionStatFactor / 100f;
                offset = num * num1;
                return true;
            }
            if (parentStat.Equals(StatDefOf.TradePriceImprovement))
            {
                float num1 = LoadedModManager.GetMod<BeautyStatMod>().GetSettings<BeautyStatSettings>().TradePriceStatFactor / 100f;
                offset = Mathf.Clamp(num * num1, -.4f, .4f);
                return true;
            }
            else
            {
                offset = 0f;
                return true;
            }

        }
        offset = 0f;
        return false;
    }
}