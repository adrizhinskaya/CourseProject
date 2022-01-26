using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models.Identity
{
    public class UserCollection
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Theme { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
