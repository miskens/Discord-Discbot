
using Discord;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using MiskDiscBot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MiskDiscBot.Commands
{
    public class InteractivityCommands : MiskDiscBot
    {
        public InteractivityCommands(ServiceProvider services) : base(services) { }

        [Command("Pollopt")]
        [Description("Poll with options, usage example: ?pollopt <question>: <option> <option>")]
        public async Task Poll(CommandContext ctx, params string[] pollOptions)
        {
            var interactivity = ctx.Client.GetInteractivityModule();
            var options = pollOptions.Select(x => x.ToString());
            var message = ctx.Message.Content;
            var messageList = message.Split(" ").ToList();

            // remove the ?pollopt command from the message sent
            messageList.Remove("?pollopt");
            messageList.Remove("?Pollopt");

            // The question and options words separated
            var fullMessage = string.Join(" ", messageList);
            var messageQuestion = string.Empty;
            var messageOptions = string.Empty;
            var indexOfColon = 0;

            // Remove options
            if (fullMessage.Contains(":"))
            {
                indexOfColon = fullMessage.IndexOf(":");
            }
            else if (fullMessage.Contains("?"))
            {
                indexOfColon = fullMessage.IndexOf("?");
            }
            if (indexOfColon > 0)
                messageQuestion = fullMessage.Substring(0, indexOfColon);

            // Get options to show in the embed both if poll was written with a ? or :
            if (fullMessage.Contains(":"))
            {
                messageOptions = fullMessage.Substring(fullMessage.IndexOf(":"), (fullMessage.Length - messageQuestion.Length));
            }
            else if (fullMessage.Contains("?"))
            {
                messageOptions = fullMessage.Substring(fullMessage.IndexOf("?"), (fullMessage.Length - messageQuestion.Length));
            }
            messageOptions = messageOptions.Substring(2, (messageOptions.Length - 2));
            var optionsList = messageOptions.Split(" ").ToList();
            var optionsDescription = new StringBuilder();

            //var interactiveOption = string.Empty;

            foreach (string option in optionsList)
            {
                // TODO: Fix interactive text method
                //interactiveOption = GetInteractiveText(option);
                optionsDescription = optionsDescription.Append(option + Environment.NewLine);
            };

            var pollEmbed = new DiscordEmbedBuilder
            {
                Title = messageQuestion,
                Description = optionsDescription.ToString(),
                //< asp:LinkButton ID = "LinkButton1" runat = "server" OnClick = "LinkButton1_Click" > LinkButton </ asp:LinkButton >,
                Color = DiscordColor.Azure
            };

            var pollMessage = await ctx.Channel.SendMessageAsync(embed: pollEmbed).ConfigureAwait(false);

            //await ctx.Channel.SendMessageAsync(embed: pollEmbed).ConfigureAwait(false);
            foreach (var option in options)
            {

                //await pollMessage.CreateReactionAsync(option)
            }
        }

                    [Command("Poll")]
        [Description("Poll with emoji options, example: ?Poll Ride a pony?")]
        public async Task Poll(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivityModule();
            //var options = pollOptions.Select(x => x.ToString());
            string pollName = ctx.Message.Content;
            pollName = pollName.Substring(6, (pollName.Length - 6));

            var pollEmbed = new DiscordEmbedBuilder
            {
                Title = pollName,
                Color = DiscordColor.Azure
            };

            var pollMessage = await ctx.Channel.SendMessageAsync(embed: pollEmbed).ConfigureAwait(false);

            DiscordEmoji[] pollOptions = new DiscordEmoji[2];
            pollOptions[0] = DiscordEmoji.FromName(ctx.Client, ":thumbsup:");
            pollOptions[1] = DiscordEmoji.FromName(ctx.Client, ":thumbsdown:");

            foreach (var option in pollOptions)
            {
                await pollMessage.CreateReactionAsync(option).ConfigureAwait(false);
            }
        }
        public string GetInteractiveText(string option)
        {
            var interactiveOption = string.Empty;
            

            //Make option as interactive text


            return interactiveOption;
        }
    }


}

