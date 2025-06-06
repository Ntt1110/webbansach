using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.data;
using appentity;

namespace app.control
{
    public class AuthControl
    {
        private UserData userData;

        public AuthControl()
        {
            userData = new UserData();
        }

        public bool AuthenticateAdmin(string username, string password)
        {
            var users = userData.GetAllUsers();
            var admin = users.Find(u => u is Admin && u.Username == username);
            if (admin != null)
            {
                // Giả lập kiểm tra mật khẩu (trong thực tế cần mã hóa)
                return password == "admin123"; // Ví dụ mật khẩu cứng
            }
            return false;
        }
    }
}
