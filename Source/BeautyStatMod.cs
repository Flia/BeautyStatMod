using System;
using JetBrains.Annotations;
using UnityEngine;
using Verse;

namespace BeautyStatMod;

public class BeautyStatMod : Mod
{
    [UsedImplicitly]
    public readonly BeautyStatSettings settings;
    public BeautyStatMod(ModContentPack content) : base(content)
    {
        GetSettings<BeautyStatSettings>();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        Listing_Standard list = new();

        list.Begin(inRect);
        list.Label("BeautyStatMod_NegotiationStatFactor".Translate(BeautyStatSettings.NegotiationStatFactor.ToStringPercent()));
        BeautyStatSettings.NegotiationStatFactor = list.Slider(MathF.Round(BeautyStatSettings.NegotiationStatFactor, 2), 0, 0.4f);
        list.Label("BeautyStatMod_TradePriceStatFactor".Translate(BeautyStatSettings.TradePriceStatFactor.ToStringPercent()));
        BeautyStatSettings.TradePriceStatFactor = list.Slider(MathF.Round(BeautyStatSettings.TradePriceStatFactor, 2), 0, 0.4f);
        list.Label("BeautyStatMod_SocialImpactStatFactor".Translate(BeautyStatSettings.SocialImpactStatFactor.ToStringPercent()));
        BeautyStatSettings.SocialImpactStatFactor = list.Slider(MathF.Round(BeautyStatSettings.SocialImpactStatFactor, 2), 0, 0.4f);
        if (ModsConfig.IdeologyActive)
        {
            list.Label("BeautyStatMod_SuppressionStatFactor".Translate(BeautyStatSettings.SuppressionStatFactor.ToStringPercent()));
            BeautyStatSettings.SuppressionStatFactor = list.Slider(MathF.Round(BeautyStatSettings.SuppressionStatFactor, 2), 0, 0.4f);
            list.Label("BeautyStatMod_ConversionStatFactor".Translate(BeautyStatSettings.ConversionStatFactor.ToStringPercent()));
            BeautyStatSettings.ConversionStatFactor = list.Slider(MathF.Round(BeautyStatSettings.ConversionStatFactor, 2), 0, 0.4f);
        }

        list.Gap(28f);

        if (list.ButtonText("BeautyStatMod_RestoreDefaultSettings".Translate()))
        {
            BeautyStatSettings.NegotiationStatFactor = 0.2f;
            BeautyStatSettings.ConversionStatFactor = 0.2f;
            BeautyStatSettings.TradePriceStatFactor = 0.1f;
            BeautyStatSettings.SuppressionStatFactor = 0.05f;
            BeautyStatSettings.SocialImpactStatFactor = 0.2f;
        }
        list.End();
    }

    public override string SettingsCategory() => "BeautyStatMod_BeautyStatSettings".Translate();
}