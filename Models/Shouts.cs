using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shout.Models
{
    public class Shouts
    {
        public int Id { get; set; }
        public string Publication { get; set; }
        public DateTime DatePublication { get; set; }
        public Users Owner { get; set; }
    }
}
