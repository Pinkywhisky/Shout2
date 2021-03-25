using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shout.Models
{
    public class Follow
    {
        public int Id { get; set; }
        public Users Follower { get; set; }
        public Users Following { get; set; }
    }
}
