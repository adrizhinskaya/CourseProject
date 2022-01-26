using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Project.Models.Identity
{
    public class User : IdentityUser
    {
        public string Language { get; set; }
        public string Theme { get; set; }
        public List<UserCollection> Collections { get; set; }
        public User()
        {
            Collections = new List<UserCollection>();
        }
    }
}
