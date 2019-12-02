using System.Collections.Generic;

namespace RZNU_Rest.User
{
    public class UserResource
    {
        public List<User> GetUsers() {
            List<User> userList = new List<User>();
            
            userList.Add(new User() { ID = 100, Username = "nmotocic", Password = "1234"});
            userList.Add(new User() { ID = 101, Username = "fer123", Password = "demo"});

            return userList; 
        }
    }
}
