using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiskDiscBot.Commands;
using MiskDiscBot.DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MiskDiscBot
{
    public class MiskDiscBot
    {
        public CommandsNextModule CommandsNext { get; private set; }
        public DiscordClient Client { get; private set; }
        private InteractivityConfiguration _interactivity;
        private DiscordConfiguration _config;
        public MiskDiscBot(IServiceProvider service)
        {
            _config = GetDiscordClientConfig();
            Client = new DiscordClient(_config);

            Client.Ready += OnClientReady;

            // Make bot wait 5 minutes for user response
            Client.UseInteractivity(new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(5)
            });

            // Register and use the custom BotCommands 
            Client.UseCommandsNext(GetCommandsNextConfig(Client));

            CommandsNext.RegisterCommands<GetInfoCommands>();
            CommandsNext.RegisterCommands<TeamCommands>();
            CommandsNext.RegisterCommands<InteractivityCommands>();
            CommandsNext.RegisterCommands<DALCommands>();

            Client.ConnectAsync();
        }
        private async Task OnClientReady(ReadyEventArgs e)
        {
            // Get DGE´s "testing" channel id
            ulong id = 732293267256901705;
            // Get DGE´s "general" channel id
            ulong generalId = 731998842219659357;
            DiscordChannel testchannel = Client.GetChannelAsync(id).Result;
            DiscordChannel genChannel = Client.GetChannelAsync(generalId).Result;

            // Set bot status info for using bot commands
            DiscordGame game = new DiscordGame("?help for botcommands");
            await Client.UpdateStatusAsync(game).ConfigureAwait(false);

            await testchannel.SendMessageAsync("MiskDisc bot connected. Under progress..").ConfigureAwait(false);
            //await genChannel.SendMessageAsync("MiskDisc bot connected. Under progress..").ConfigureAwait(false);
            //return Task.CompletedTask;
        }

        private CommandsNextConfiguration GetCommandsNextConfig(DiscordClient client)
        {
            // Json Config
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = sr.ReadToEnd();
                }
            }
            var ConfigJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            //CommandsNext Config
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefix = new string(ConfigJson.Prefix),
                EnableMentionPrefix = true,
                EnableDms = true,
                CaseSensitive = false
            };

            return commandsConfig;
        }

        public DiscordConfiguration GetDiscordClientConfig()
        {
            _interactivity = new InteractivityConfiguration();
            // Create bot with config from json
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            {
                using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = sr.ReadToEnd();
                }
            }
            var ConfigJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = ConfigJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true,
            };

            return config;
        }
    }
}
