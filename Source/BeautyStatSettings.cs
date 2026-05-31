using Verse;

namespace BeautyStatMod;

public class BeautyStatSettings : ModSettings
{
    public float NegotiationStatFactor = 20f;
    public float ConversionStatFactor = 20f;
    public float TradePriceStatFactor = 10f;
    public float SuppressionStatFactor = 5f;
    public float SocialImpactStatFactor = 20f;
    //public bool exampleBool = true;
    //public StatFormula StatBeautyFormula = StatFormula.Linear;
    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref NegotiationStatFactor, "NegotiationStatFactor", 20f);
        Scribe_Values.Look(ref ConversionStatFactor, "ConversionStatFactor", 20f);
        Scribe_Values.Look(ref TradePriceStatFactor, "TradePriceStatFactor", 10f);
        Scribe_Values.Look(ref SuppressionStatFactor, "SuppressionStatFactor", 5f);
        Scribe_Values.Look(ref SocialImpactStatFactor, "SocialImpactStatFactor", 20f);
        //Scribe_Values.Look(ref StatBeautyFormula, "StatBeautyFormula", StatFormula.Linear);

        //Scribe_Values.Look(ref ManipulationAffects, "ManipulationAffects", true);
        //Scribe_Values.Look(ref ManipulationMoreForDamage, "ManipulationMoreForDamage", true);
    }
}