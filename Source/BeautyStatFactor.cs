using JetBrains.Annotations;
using RimWorld;
using UnityEngine;
using Verse;

namespace BeautyStatMod;

[UsedImplicitly]
public class StatPartBeautyOffsets : StatPart
{
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
            return "BeautyStatPart".Translate(offset.ToStringPercent());
        }
        return null;
    }

    private bool TryGetBeauty(Thing t, out float offset)
    {
        if (t is Pawn pawn)
        {
            float pawnBeauty = pawn.GetStatValue(StatDefOf.PawnBeauty);
            if (parentStat.Equals(StatDefOf.SocialImpact))
            {
                offset = pawnBeauty * (BeautyStatSettings.SocialImpactStatFactor / 100f);
                return true;
            }
            if (parentStat.Equals(StatDefOf.NegotiationAbility))
            {
                offset = pawnBeauty * (BeautyStatSettings.NegotiationStatFactor / 100f);
                return true;
            }
            if (ModsConfig.IdeologyActive && parentStat.Equals(StatDefOf.SuppressionPower))
            {
                offset = pawnBeauty * (BeautyStatSettings.SuppressionStatFactor / 100f);
                return true;
            }
            if (ModsConfig.IdeologyActive && parentStat.Equals(StatDefOf.ConversionPower))
            {
                offset = pawnBeauty * (BeautyStatSettings.ConversionStatFactor / 100f);
                return true;
            }
            if (parentStat.Equals(StatDefOf.TradePriceImprovement))
            {
                offset = Mathf.Clamp(pawnBeauty * (BeautyStatSettings.TradePriceStatFactor / 100f), -.4f, .4f);
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