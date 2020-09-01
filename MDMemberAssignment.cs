using System;
using System.Collections.Generic;
using System.Text;
using DSharpPlus;
using Discord.Net;
using Discord.Net.WebSockets;
using Discord.WebSocket;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using Discord;
using DSharpPlus.Entities;

namespace MiskDiscBot
{
public class MemberAssignmentService: IWebSocketClient
{
    public MemberAssignmentService(DiscordSocketClient client)
    {
        // Hook the event
        client.UserJoined += AssignMemberAsync;
    }

        public event Func<byte[], int, int, Task> BinaryMessage;
        public event Func<string, Task> TextMessage;
        public event Func<Exception, Task> Closed;

        public Task ConnectAsync(string host)
        {
            throw new NotImplementedException();
        }

        public Task DisconnectAsync()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(byte[] data, int index, int count, bool isText)
        {
            throw new NotImplementedException();
        }

        public void SetCancelToken(CancellationToken cancelToken)
        {
            throw new NotImplementedException();
        }

        public void SetHeader(string key, string value)
        {
            throw new NotImplementedException();
        }

        private async Task AssignMemberAsync( SocketGuildUser guildUser)
        {
            var guild = guildUser.Guild;
            // get DGs role
            var role = guild.GetRole(732000303561441370);
            // Check if role exist in the guild. If not, do nothing.
            if (role == null) return;
            // Check if the bot user has sufficient permission
            if (!guild.CurrentUser.GuildPermissions.Has(Discord.GuildPermission.ManageRoles)) return;

            await guildUser.AddRoleAsync(role);

            var embedGuilduserAdded = new EmbedBuilder
            {
                Color = Color.Blue,
                ThumbnailUrl = guild.CurrentUser.GetAvatarUrl()
            };

            // Send message to channel about the join and DGs add
            // TTS false needs to be passed to use embed argument
            await guild.CurrentUser.SendMessageAsync(guildUser.Username + "  joined and added to group: DGs.", false, embedGuilduserAdded.Build());      
        }
}
}
