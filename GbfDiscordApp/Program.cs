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

namespace GbfDiscordAppCs
{
    class Program
    {
        static void Main()
        {
            new Discord.Bot()
                .Initialize()
                .GetAwaiter()
                .GetResult();
        }
    }
}
