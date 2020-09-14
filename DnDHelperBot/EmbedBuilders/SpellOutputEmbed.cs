using Discord;
using DiscordNetHelperLibrary.Context;
using DiscordNetHelperLibrary.Helpers;

namespace DnDHelperBot.EmbedBuilders
{
    public static class SpellOutputEmbed
    {
        public static EmbedBuilder SpellOutput(SpellModel spell)
        {
            var embedBuilder = EmbedBuilderHelpers.BaseEmbedBuilderSuccess();
            embedBuilder.Description = spell.Description;
            embedBuilder.Title = spell.Name;

            embedBuilder.AddField(nameof(spell.Level), spell.Level, true);
            embedBuilder.AddField(nameof(spell.Range), spell.Range,true);
            embedBuilder.AddField(nameof(spell.Save), spell.Save,true);
            embedBuilder.AddField(nameof(spell.Duration), spell.Duration,true);
            embedBuilder.AddField(nameof(spell.Components), spell.Components, true);
            embedBuilder.AddField(nameof(spell.AoE), spell.AoE, true);
            embedBuilder.AddField(nameof(spell.CastingTime), spell.CastingTime, true);
            embedBuilder.AddField(nameof(spell.Spheres), spell.Spheres, true);
            embedBuilder.AddField(nameof(spell.Class), spell.Class, true);

            return embedBuilder;
        }
    }
}
