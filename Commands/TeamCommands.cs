
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Microsoft;
using MiskDiscBot.DAL;
using Microsoft.Extensions.DependencyInjection;
//using Discord.Commands;

namespace MiskDiscBot.Commands
{
    [RequirePermissions(Permissions.Administrator)]
    public class TeamCommands: MiskDiscBot
    {
        public TeamCommands(ServiceProvider services) : base(services) { }

        // Get DGE´s "testing" channel id (comment all testchannel code when done coding)
        ulong testChannelId = 732293267256901705;

        public async Task Join(CommandContext ctx)
        {
            var joinEmbed = new DiscordEmbedBuilder
            {
                Title = "Joined channel:" + ctx.Member.DisplayName,
                Color = DiscordColor.Red
            };
        }
    }
}
