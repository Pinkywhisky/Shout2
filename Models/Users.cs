using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shout.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }
        public string Password { get; set; }
        public ICollection<Shouts> Shoutlist { get; set; }
        public ICollection<Follow> FollowingList { get; set; }
    }
}
