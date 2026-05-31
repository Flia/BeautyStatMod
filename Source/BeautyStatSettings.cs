using Verse;

namespace BeautyStatMod;

//TODO: apparently there was an idea of implementing a setting for using either linear or square root curve. Not interested rn but maybe later --tipsy
public class BeautyStatSettings : ModSettings
{
    public static float NegotiationStatFactor = 0.2f;
    public static float ConversionStatFactor = 0.2f;
    public static float TradePriceStatFactor = 0.1f;
    public static float SuppressionStatFactor = 0.05f;
    public static float SocialImpactStatFactor = 0.2f;
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref NegotiationStatFactor, "NegotiationStatFactor", 0.2f);
        Scribe_Values.Look(ref ConversionStatFactor, "ConversionStatFactor", 0.2f);
        Scribe_Values.Look(ref TradePriceStatFactor, "TradePriceStatFactor", 0.1f);
        Scribe_Values.Look(ref SuppressionStatFactor, "SuppressionStatFactor", 0.05f);
        Scribe_Values.Look(ref SocialImpactStatFactor, "SocialImpactStatFactor", 0.2f);
    }
}