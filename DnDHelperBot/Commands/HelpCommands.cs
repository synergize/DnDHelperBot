using System.Threading.Tasks;
using Discord.Commands;
using DnDHelperBot.EmbedBuilders;

namespace DnDHelperBot.Commands
{
    public class HelpCommands : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task DnDHelp()
        {
            await Context.Channel.SendMessageAsync(embed: HelpOutputEmbed.GetHelpInfoOutput().Build());
        }
    }
}
