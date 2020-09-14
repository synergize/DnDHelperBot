using Discord;
using DiscordNetHelperLibrary.Helpers;

namespace DnDHelperBot.EmbedBuilders
{
    public static class HelpOutputEmbed
    {
        public static EmbedBuilder GetHelpInfoOutput()
        {
            var embedBuilder = EmbedBuilderHelpers.BaseEmbedBuilderSuccess();
            embedBuilder.Title = "The Helper";
            embedBuilder.Description = $"This bot is aimed at providing utility to individuals who are playing 2nd Edition D&D!";

            embedBuilder.AddField("Spells:", "It's possible to look up details on second edition spells. \r Use command **dnd!spells <spellname>**");
            embedBuilder.AddField("Dice Rolling:", "Let's roll some dice! \r Example: **dnd!roll 5d4**");

            return embedBuilder;
        }
    }
}
