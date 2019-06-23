using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Discord;

namespace GbfDiscordApp.Discord
{
    /// <summary>
    /// Discord Botの本体クラスです。<br></br>
    /// コアロジックのため、変更すると動作しない恐れがあります。<br></br>
    /// 基本的にはDiscord.Option.csのみ変更してください。<br></br>
    /// </summary>
    public partial class Bot
    {
        #region Field
        readonly DiscordSocketClient _Client = new DiscordSocketClient();
        readonly CommandService _Commands = new CommandService();
        readonly IServiceProvider _Services = new ServiceCollection().BuildServiceProvider();
        Dictionary<string, ICommandContext> _cmd = new Dictionary<string, ICommandContext>();
        #endregion

        public Bot()
        {
            Console.WriteLine("botbot");
        }

        /// <summary>
        /// 起動時処理
        /// </summary>
        /// <returns></returns>
        public async Task Initialize()
        {
            _Client.MessageReceived += CommandRecieved;

            _Client.Log += (msg) =>
            {
                Console.WriteLine(msg.ToString());
                return Task.CompletedTask;
            };

            await _Commands.AddModulesAsync(Assembly.GetEntryAssembly(), _Services);
            await _Client.LoginAsync(TokenType.Bot, BOT_TOKEN);
            await _Client.StartAsync();

            await Task.Delay(-1);
        }

        /// <summary>
        /// メッセージの受信処理
        /// </summary>
        /// <param name="messageParam"></param>
        /// <returns></returns>
        async Task CommandRecieved(SocketMessage messageParam)
        {
            if (messageParam is SocketUserMessage message)
            {
                string userName;
                if (message.Author.IsBot)
                {
                    userName = $"bot#{message.Author.Username}";
                }
                else
                {
                    userName = message.Author.Username;
                }

                Console.WriteLine($"ch[{message.Channel.Name}] user[{userName}] log[{message}]");

                int argPos = 0;

                if (!HasPrifix(message, ref argPos))
                {
                    return;
                }

                //var context = new CommandContext(_Client, message);
                string m = message.ToString();
                ICommandContext context;
                if (_cmd.ContainsKey(m))
                {
                    context = _cmd[m];
                }
                else
                {
                    context = new CommandContext(_Client, message);
                    _cmd.Add(m, context);
                }
                var result = await _Commands.ExecuteAsync(context, argPos, _Services);

                if (!result.IsSuccess)
                {
                    await context.Channel.SendMessageAsync(result.ErrorReason);
                }
            }
        }

        /// <summary>
        /// 接頭詞をチェックします。
        /// チェックの際、Bot.Option.csの定数を使用します。
        /// </summary>
        /// <param name="message">メッセージ情報</param>
        /// <param name="argPos">(ref)接頭詞の文字開始位置</param>
        /// <returns>接頭詞ならtrue</returns>
        private bool HasPrifix(SocketUserMessage message, ref int argPos)
        {
            return (message.HasCharPrefix(COMMAND_PREFIX, ref argPos)
                || message.HasMentionPrefix(_Client.CurrentUser, ref argPos));
        }
    }
}
