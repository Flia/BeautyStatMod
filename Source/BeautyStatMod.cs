using UnityEngine;
using Verse;

namespace BeautyStatMod;

public class BeautyStatMod : Mod
{
    public BeautyStatSettings settings;

    public BeautyStatMod(ModContentPack content) : base(content)
    {
        settings = GetSettings<BeautyStatSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        Listing_Standard list = new();

        list.Begin(inRect);
        list.Label("NegotiationStatFactor".Translate() + ": " + settings.NegotiationStatFactor + "%");
        settings.NegotiationStatFactor = list.Slider(settings.NegotiationStatFactor, 0, 40f);
        list.Label("ConversionStatFactor".Translate() + ": " + settings.ConversionStatFactor + "%");
        settings.ConversionStatFactor = list.Slider(settings.ConversionStatFactor, 0, 40f);
        list.Label("TradePriceStatFactor".Translate() + ": " + settings.TradePriceStatFactor + "%");
        settings.TradePriceStatFactor = list.Slider(settings.TradePriceStatFactor, 0, 40f);
        list.Label("SuppressionStatFactor".Translate() + ": " + settings.SuppressionStatFactor + "%");
        settings.SuppressionStatFactor = list.Slider(settings.SuppressionStatFactor, 0, 40f);
        list.Label("SocialImpactStatFactor".Translate() + ": " + settings.SocialImpactStatFactor + "%");
        settings.SocialImpactStatFactor = list.Slider(settings.SocialImpactStatFactor, 0, 40f);
        /*list.CheckboxLabeled("TypeofScaling", ref settings.exampleBool);
        foreach (var label in Enum.GetNames(typeof(StatFormula)))
        {
            var val = (StatFormula)Enum.Parse(typeof(StatFormula), label);
            if (list.RadioButton(label.Translate(), settings.StatBeautyFormula == val, 8f)) settings.StatBeautyFormula = val;
        }*/
        list.Gap(28f);

        if (list.ButtonText("RestoreToDefaultSettings".Translate()))
        {
            settings.NegotiationStatFactor = 20f;
            settings.ConversionStatFactor = 20f;
            settings.TradePriceStatFactor = 10f;
            settings.SuppressionStatFactor = 5f;
            settings.SocialImpactStatFactor = 20f;
        }
        list.End();
        //base.DoSettingsWindowContents(inRect);
    }

    public override string SettingsCategory()
    {
        return "Beauty Stat Settings";
    }
}