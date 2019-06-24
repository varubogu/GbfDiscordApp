using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GbfDiscordAppCs.Discord.Times
{
    class Schedule : ModuleBase
    {
        static int _NoticeMiliSecond = 60000;

        /// <summary>
        /// 通知を行います
        /// </summary>
        /// <returns></returns>
        public async Task Notice()
        {
            string message = "Hello!";
            System.Console.WriteLine(message);
            await ReplyAsync(message);
        }
    }
}
