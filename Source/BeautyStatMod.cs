using UnityEngine;
using Verse;

namespace BeautyStatMod;

public class BeautyStatMod : Mod
{
    public readonly BeautyStatSettings settings;

    public BeautyStatMod(ModContentPack content) : base(content)
    {
        settings = GetSettings<BeautyStatSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        Listing_Standard list = new();

        list.Begin(inRect);
        list.Label("NegotiationStatFactor".Translate() + ": " + BeautyStatSettings.NegotiationStatFactor + "%");
        BeautyStatSettings.NegotiationStatFactor = list.Slider(BeautyStatSettings.NegotiationStatFactor, 0, 40f);
        list.Label("TradePriceStatFactor".Translate() + ": " + BeautyStatSettings.TradePriceStatFactor + "%");
        BeautyStatSettings.TradePriceStatFactor = list.Slider(BeautyStatSettings.TradePriceStatFactor, 0, 40f);
        list.Label("SocialImpactStatFactor".Translate() + ": " + BeautyStatSettings.SocialImpactStatFactor + "%");
        BeautyStatSettings.SocialImpactStatFactor = list.Slider(BeautyStatSettings.SocialImpactStatFactor, 0, 40f);
        if (ModsConfig.IdeologyActive)
        {
            list.Label("SuppressionStatFactor".Translate() + ": " + BeautyStatSettings.SuppressionStatFactor + "%");
            BeautyStatSettings.SuppressionStatFactor = list.Slider(BeautyStatSettings.SuppressionStatFactor, 0, 40f);
            list.Label("ConversionStatFactor".Translate() + ": " + BeautyStatSettings.ConversionStatFactor + "%");
            BeautyStatSettings.ConversionStatFactor = list.Slider(BeautyStatSettings.ConversionStatFactor, 0, 40f);
        }

        list.Gap(28f);

        if (list.ButtonText("RestoreToDefaultSettings".Translate()))
        {
            BeautyStatSettings.NegotiationStatFactor = 20f;
            BeautyStatSettings.ConversionStatFactor = 20f;
            BeautyStatSettings.TradePriceStatFactor = 10f;
            BeautyStatSettings.SuppressionStatFactor = 5f;
            BeautyStatSettings.SocialImpactStatFactor = 20f;
        }
        list.End();
    }

    public override string SettingsCategory()
    {
        return "BeautyStatSettings".Translate();
    }
}