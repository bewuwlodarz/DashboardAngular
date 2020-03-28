using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Advantage_WebApi.Models
{
    public class ServerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isOnline { get; set; }
    }
}
