using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Discord.Commands;

namespace DnDHelperBot.Commands
{
    public class DiceRollingCommands : ModuleBase<SocketCommandContext>
    {
        [Command("roll")]
        public async Task RollDice(string diceRoll)
        {
            var diceRolled = CalculateDiceToRole(diceRoll.ToLower());

            if (diceRolled != null)
            {
                var diceTotal = diceRolled.Sum(Convert.ToInt32);
                var diceRolledOutput = diceRolled.Aggregate("", (current, dice) => current + $"{dice} + ");

                diceRolledOutput = diceRolledOutput.Trim();
                diceRolledOutput = diceRolledOutput.Trim('+');
                diceRolledOutput += $" = {diceTotal}";
                await Context.Channel.SendMessageAsync($"Rolling {diceRoll}: {diceRolledOutput}");
            }
        }

        private static List<int> CalculateDiceToRole(string input)
        {
            var dice = input.Split('d');

            if (dice.Length > 2)
            {
                return null;
            }

            var random = new Random(DateTime.UtcNow.Millisecond);
            var allDice = new List<int>();
            var tryNumberOfDice = Int32.TryParse(dice[0], out int numberOfDice);
            var tryTypeOfDice = Int32.TryParse(dice[1], out int typeOfDice);


            if (tryNumberOfDice && tryTypeOfDice)
            {
                for (var i = 0; i < numberOfDice; i++)
                {
                    var rolledValue = random.Next(1, typeOfDice);
                    allDice.Add(rolledValue);
                }
            }
            else
            {
                return null;
            }

            return allDice;
        }
    }
}
