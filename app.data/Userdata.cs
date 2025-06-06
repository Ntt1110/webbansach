using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appentity;

namespace app.data
{
    public class UserData
    {
        private List<User> users;

        public UserData()
        {
            users = new List<User>
            {
                 new Admin(1, "admin1", "admin1@example.com", "hash1"),
                new Admin(2, "admin2", "admin2@example.com", "hash2"),
                new Customer(1, "john", "john@gmail.com", "123456"),
                 new Customer(2, "alice", "alice@gmail.com", "pass123")
            };
        }

        public List<User> GetAllUsers()
        {
            return users;
        }

        public void UpdateUser(int userId, string username)
        {
            var user = users.Find(u => u.Id == userId);
            if (user != null)
            {
                user.Username = username;
            }
        }
    }
}
