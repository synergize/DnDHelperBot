using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using DiscordNetHelperLibrary;

namespace DnDHelperBot
{
    internal class Program : DiscordBotBase
    {
        private static string Token => Environment.GetEnvironmentVariable("DND_TOKEN");
        private static void Main(string[] args) => new Program().DnDMainAsync().GetAwaiter().GetResult();

        private async Task DnDMainAsync()
        {
            await MainAsync(Token);
            await Commands.AddModulesAsync(typeof(Program).Assembly, null);
            Client.MessageReceived += Client_MessageReceived;
            Client.Ready += Client_Ready;
            await Task.Delay(-1);
        }

        private async Task Client_MessageReceived(SocketMessage messageParam)
        {
            var message = messageParam as SocketUserMessage;
            var context = new SocketCommandContext(Client, message);
            var argPos = 0;

            if (context.Message == null || context.Message.Content == "") return;
            if (context.User.IsBot) return;

            if (!(message.HasStringPrefix("dnd!", ref argPos) || message.HasMentionPrefix(Client.CurrentUser, ref argPos))) return;

            var result = await Commands.ExecuteAsync(context, argPos, null);

            if (!result.IsSuccess)
            {
                Console.WriteLine($"{DateTime.Now} at Commands] Something went wrong with executing command. Text: {context.Message.Content} | Error: {result.ErrorReason}");
            }
        }

        private async Task Client_Ready()
        {
            await Client.SetGameAsync("dnd!help for more info.", null, ActivityType.Playing);
        }
    }
}
