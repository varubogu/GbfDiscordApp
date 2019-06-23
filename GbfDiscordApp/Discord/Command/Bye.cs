using Discord.Commands;
using System.Threading.Tasks;

namespace GbfDiscordApp.Discord.Command
{
    public class Bye : ModuleBase, ICommandcs
    {
        [Command("bye")]
        public async Task Exec()
        {
            string message = "bye!";
            System.Console.WriteLine(message);
            await ReplyAsync(message);
        }

        public Bye()
        {
            System.Console.WriteLine("b");
        }
    }
}
