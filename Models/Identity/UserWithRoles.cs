using Project.Models.Identity;
using System.Collections.Generic;

namespace Project.Models.Identity
{
    public class UserWithRoles
    {
        public User User {get; set;}

        public IList<string> Roles { get; set; }

        public UserWithRoles(User user, IList<string> roles)
        {
            this.User = user;
            this.Roles = roles;
        }
    }
}