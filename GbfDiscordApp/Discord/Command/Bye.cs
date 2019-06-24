using Discord.Commands;
using System.Threading.Tasks;

namespace GbfDiscordAppCs.Discord.Command
{
    public class Bye : ModuleBase, ICommandcs
    {
        [Command("bye")]
        public async Task ExecAsync()
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
