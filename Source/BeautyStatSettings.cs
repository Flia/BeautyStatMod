using Verse;

namespace BeautyStatMod;

//TODO: apparently there was an idea of implementing a setting for using either linear or square root curve. Not interested rn but maybe later --tipsy
public class BeautyStatSettings : ModSettings
{
    public static float NegotiationStatFactor = 20f;
    public static float ConversionStatFactor = 20f;
    public static float TradePriceStatFactor = 10f;
    public static float SuppressionStatFactor = 5f;
    public static float SocialImpactStatFactor = 20f;
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref NegotiationStatFactor, "NegotiationStatFactor", 20f);
        Scribe_Values.Look(ref ConversionStatFactor, "ConversionStatFactor", 20f);
        Scribe_Values.Look(ref TradePriceStatFactor, "TradePriceStatFactor", 10f);
        Scribe_Values.Look(ref SuppressionStatFactor, "SuppressionStatFactor", 5f);
        Scribe_Values.Look(ref SocialImpactStatFactor, "SocialImpactStatFactor", 20f);
    }
}