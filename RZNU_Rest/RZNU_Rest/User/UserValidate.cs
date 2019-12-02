using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RZNU_Rest.User
{
    public class UserValidate
    {
        public static bool Login(string username, string password) {
            UserResource userResource = new UserResource();
            var userLists = userResource.GetUsers();

            return userLists.Any(user => user.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && user.Password == password);
        }
    }
}
