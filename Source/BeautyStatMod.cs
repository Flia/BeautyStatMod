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
        list.Label("NegotiationStatFactor".Translate(BeautyStatSettings.NegotiationStatFactor.ToStringPercent()));
        BeautyStatSettings.NegotiationStatFactor = list.Slider(BeautyStatSettings.NegotiationStatFactor, 0, 0.4f);
        list.Label("TradePriceStatFactor".Translate(BeautyStatSettings.TradePriceStatFactor.ToStringPercent()));
        BeautyStatSettings.TradePriceStatFactor = list.Slider(BeautyStatSettings.TradePriceStatFactor, 0, 0.4f);
        list.Label("SocialImpactStatFactor".Translate(BeautyStatSettings.SocialImpactStatFactor.ToStringPercent()));
        BeautyStatSettings.SocialImpactStatFactor = list.Slider(BeautyStatSettings.SocialImpactStatFactor, 0, 0.4f);
        if (ModsConfig.IdeologyActive)
        {
            list.Label("SuppressionStatFactor".Translate(BeautyStatSettings.SuppressionStatFactor.ToStringPercent()));
            BeautyStatSettings.SuppressionStatFactor = list.Slider(BeautyStatSettings.SuppressionStatFactor, 0, 0.4f);
            list.Label("ConversionStatFactor".Translate(BeautyStatSettings.ConversionStatFactor.ToStringPercent()));
            BeautyStatSettings.ConversionStatFactor = list.Slider(BeautyStatSettings.ConversionStatFactor, 0, 0.4f);
        }

        list.Gap(28f);

        if (list.ButtonText("RestoreToDefaultSettings".Translate()))
        {
            BeautyStatSettings.NegotiationStatFactor = 0.2f;
            BeautyStatSettings.ConversionStatFactor = 0.2f;
            BeautyStatSettings.TradePriceStatFactor = 0.1f;
            BeautyStatSettings.SuppressionStatFactor = 0.05f;
            BeautyStatSettings.SocialImpactStatFactor = 0.2f;
        }
        list.End();
    }

    public override string SettingsCategory()
    {
        return "BeautyStatSettings".Translate();
    }
}