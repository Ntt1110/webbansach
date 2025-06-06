using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.data;
using appentity;


namespace app.control
{
    public class UserControl
    {
        private UserData userData;

        public UserControl()
        {
            userData = new UserData();
        }

        public List<User> GetUsers()
        {
            return userData.GetAllUsers();
        }

        public void UpdateUser(int userId, string username)
        {
            userData.UpdateUser(userId, username);
        }
    }
}
