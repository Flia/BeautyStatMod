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
        if (req.Thing is Pawn pawn)
        {
            val += GetOffset(pawn);
        }
    }

    public override string ExplanationPart(StatRequest req)
    {
        if (req.HasThing && req.Thing is Pawn pawn && GetOffset(pawn) != 0f)
        {
            return "BeautyStatPart".Translate(GetOffset(pawn).ToStringPercent());
        }
        return null;
    }

    private float GetOffset(Pawn pawn)
    {
        float pawnBeauty = pawn.GetStatValue(StatDefOf.PawnBeauty);
        if (parentStat.Equals(StatDefOf.SocialImpact))
        {
            return pawnBeauty * BeautyStatSettings.SocialImpactStatFactor;
        }
        if (parentStat.Equals(StatDefOf.NegotiationAbility))
        {
            return pawnBeauty * BeautyStatSettings.NegotiationStatFactor;
        }
        if (ModsConfig.IdeologyActive && parentStat.Equals(StatDefOf.SuppressionPower))
        {
            return pawnBeauty * BeautyStatSettings.SuppressionStatFactor;
        }
        if (ModsConfig.IdeologyActive && parentStat.Equals(StatDefOf.ConversionPower))
        {
            return pawnBeauty * BeautyStatSettings.ConversionStatFactor;
        }
        if (parentStat.Equals(StatDefOf.TradePriceImprovement))
        {
            return Mathf.Clamp(pawnBeauty * BeautyStatSettings.TradePriceStatFactor, -.4f, .4f);
        }
        return 0f;
    }
}