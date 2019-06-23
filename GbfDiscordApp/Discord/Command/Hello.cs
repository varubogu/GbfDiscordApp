using Discord.Commands;
using System.Threading.Tasks;

namespace GbfDiscordApp.Discord.Command
{
    public class Hello : ModuleBase, ICommandcs
    {
        [Command("hello")]
        public async Task Exec()
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
