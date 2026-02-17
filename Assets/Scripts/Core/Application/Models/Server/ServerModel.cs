using System.Collections.Generic;
using Core.Domain.Models;

namespace Core.Application.Models.Server
{
    public class ServerModel
    {
        public List<User> Users { get; private set; }
    }
}