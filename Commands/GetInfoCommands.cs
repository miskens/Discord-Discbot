
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using MiskDiscBot.DAL;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace MiskDiscBot.Commands
{
    public class GetInfoCommands: MiskDiscBot
    {
        public GetInfoCommands(ServiceProvider services) : base(services) { }

        [Command("Ping")]
        [RequireOwner]
        [Description("Ping pong :)")]

        public async Task Ping(CommandContext ctx)
        {
            if (ctx.Channel.Id == testChannelId)
            {
                await ctx.Channel.SendMessageAsync("Pong!").ConfigureAwait(false);
            }
        }

        // Get DGE´s "testing" channel id (comment all testchannel code when done coding)
        ulong testChannelId = 732293267256901705;

        [Command("Getdisc")]
        [Description("Returns information about a specified disc")]
        public async Task GetDisk(CommandContext ctx)
        {
            if (ctx.Channel.Id == testChannelId)
            {
                await ctx.Member.CreateDmChannelAsync().ConfigureAwait(false);
            }
        }

        [Command("GetNews")]
        [Description("Get latest news from PDGA")]
        // Retrieves the latest news from PGDA
        public async Task GetNews(CommandContext ctx)
        {

        }

        [Command("GetDiskInfo")]
        [Description("Shows info on a disk")]
        // Retrieves info on a given disk from Innova if you know the name of the disk
        public async Task GetDiskInfo(CommandContext ctx)
        {
            // TODO: GetDiskInfo Dart..

            var discName = "";
            var discDescription = "";
            var discImageUrl = "";

            DiscordEmbedBuilder discinfoEmbed = new DiscordEmbedBuilder
            {
                Title = "Disc: " + discName,
                Description = discDescription,
                Color = DiscordColor.Green,
                ImageUrl = discImageUrl,
            };
        }

        [Command("Player")]
        [Description("Show info on a professional player. Example: ?Player Simon Lizotte")]
        public async Task ProPlayer(CommandContext ctx,
        [Description("First name")] string firstName, [Description("Last name")] string lastName)
        {
            if (ctx.Channel.Id == testChannelId)
            {
                // TODO: Give info a specific professional player
                string playerName = firstName + " " + lastName;
                // await fetchinfo on the player

                // TODO: Try to find info on the player else give error message
                await ctx.Channel.SendMessageAsync(firstName + " " + lastName + " test").ConfigureAwait(false);
            }

        }


        [Command("FollowPlayer")]
        [Description("Gives you the option to follow a specific player that you like")]
        public async Task FollowPlayer(CommandContext ctx, 
            [Description("First name")]string firstName, [Description("Last name")] string lastName)
        {
            if (ctx.Channel.Id == testChannelId)
            {
                //eg. Simon Lizotte
                string playerName = firstName + " " + lastName;
                // await fetchinfo on the player
                try
                { await ctx.Channel.SendMessageAsync(firstName + "" + lastName).ConfigureAwait(false); }
                catch
                {
                    await ctx.Channel.SendMessageAsync("something went wrong").ConfigureAwait(false);
                }
            }
        }

        [Command("GoDM")]
        [Description("Change between Direct message/Channel mode between you and the bot")]
        public async Task DM(CommandContext ctx, bool changeTodDm)
        {
            if (ctx.Channel.Id == testChannelId)
            {
                bool dm = changeTodDm;

                // TODO make it possible to always do DMs or channel for a specific user
            }
        }

        //[Command("Response")]
        //public async Task Response(CommandContext ctx)
        //{
        //    var interactivity = ctx.Client.GetInteractivityModule();

        //    await interactivity.WaitForMessageAsync(x => ctx.Channel == ctx.Channel).ConfigureAwait(false);
        //}

        // TODO: Lägg till alla alla metoder för botcommands(som tasks) för att hämta och ge info till användare

        public async Task Info(CommandContext ctx, bool brackytext)
        {
            if (ctx.Channel.Id == testChannelId)
            {
                bool brackets = brackytext;

                // TODO Make the bot read disc name if inside brackets(in any channel text) and get info from innova with picture
            }
        }
    }
}
