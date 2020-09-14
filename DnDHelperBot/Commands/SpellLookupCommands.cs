using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord.Commands;
using DiscordNetHelperLibrary.Context;
using DiscordNetHelperLibrary.Extensions;
using DnDHelperBot.EmbedBuilders;
using Newtonsoft.Json;
using VTFileSystemManagement;

namespace DnDHelperBot.Commands
{
    public class SpellLookupCommands : ModuleBase<SocketCommandContext>
    {
        [Command("spell")]
        public async Task SpellLookup(string spellName)
        {
            var programDirectory = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var fileManager = new FileSystemManager();
            var spellsFromFile = fileManager.ReadJsonFileFromSpecificLocation("AllSpells.json", $"{programDirectory}\\SpellData");
            var spells = JsonConvert.DeserializeObject<List<SpellModel>>(spellsFromFile);

            var spell = spells.Find(x => x.Name == spellName.UpperCaseFirstLetter());

            if (spell != null)
            {
                await Context.Channel.SendMessageAsync(embed: SpellOutputEmbed.SpellOutput(spell).Build());
            }
            else
            {
                await Context.Channel.SendMessageAsync($"{spellName} wasn't able to be found. Please double check your spelling or contact my developer.");
            }
        }
    }
}
