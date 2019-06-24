using Discord.Commands;
using System.Threading.Tasks;

namespace GbfDiscordAppCs.Discord.Command
{
    public class Hello : ModuleBase, ICommandcs
    {
        [Command("hello")]
        public async Task ExecAsync()
        {
            string message = "Hello!";
            System.Console.WriteLine(message);
            await ReplyAsync(message);
        }
        public Hello()
        {
            System.Console.WriteLine("a");
        }
    }
}
