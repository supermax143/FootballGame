using System.Collections.Generic;
using Core.Domain.Models;

namespace Core.Application.Models.Server
{
    public class ServerModel
    {
        public List<User> Clients { get; private set; }
    }
}