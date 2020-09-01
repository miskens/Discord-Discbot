using Discord.Commands;
using Discord.WebSocket;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using MiskDiscBot.Commands;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiskDiscBot.DAL
{
	public class MiskDiscProvider : IServiceCollection
	{
		private DiscordClient _client;
		private DiscordSocketClient _socketClient;
		private CommandService _commands;
		private IServiceProvider _services;
		
		public MiskDiscProvider(IServiceProvider services, CommandService commands, DiscordSocketClient socketClient, DiscordClient client) 
		{
			_commands = commands;
			_services = services;
			_client = client;
			_socketClient = socketClient;
		}

        public ServiceDescriptor this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<ServiceDescriptor> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
		{
			throw new NotImplementedException();
		}

        public int IndexOf(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(ServiceDescriptor item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public class Initialize
		{
			private CommandService _commands;
			private DiscordSocketClient _socketclient;
			private DiscordClient _client;
			private DiscordConfiguration _config;

			public Initialize(CommandService commands = null, DiscordSocketClient socketClient = null, DiscordClient client= null)
			{
				_commands = commands ?? new CommandService();
				_socketclient = socketClient ?? new DiscordSocketClient();
				_client = client ?? new DiscordClient(_config);
			}

            public IServiceProvider BuildServiceProvider() => new ServiceCollection()
				.AddSingleton(_client)
				.AddSingleton(_socketclient)
				.AddSingleton(_commands)
				.BuildServiceProvider();
		}
	}
}
