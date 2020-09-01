using Microsoft.Extensions.DependencyInjection;
using MiskDiscBot.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiskDiscBot.Commands
{
    public class DALCommands : MiskDiscBot
    {
        public DALCommands(ServiceProvider services) : base(services) { }

    }
}
