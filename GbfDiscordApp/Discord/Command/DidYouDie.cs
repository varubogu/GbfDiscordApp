using Discord.Commands;
using System.Threading.Tasks;

namespace GbfDiscordAppCs.Discord.Command
{
    /// <summary>
    /// 生存確認コマンドクラス
    /// </summary>
    class DidYouDie : ModuleBase, ICommandcs
    {
        /// <summary>
        /// 生存確認コマンド
        /// コマンドとコマンドーをかけ合わせたかったという訳ではないぞ。
        /// </summary>
        /// <returns></returns>
        [Command("死んだんじゃない？")]
        public async Task ExecAsync()
        {
            string message = "生きてるよ";
            System.Console.WriteLine(message);
            await ReplyAsync(message);
        }
    }
}
