using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ah_shop_wpf
{
    public class User
    {
        public int id;
        public string username;
        public string password;
        public UserInfo user_info;

    }

    public class UserInfo
    {
        public int id;
        public string firstname;
        public string lastname;
        public double balance;
    }

    public class CreateUser
    {
        public string type;
        public string message;
    }

    public class LoginUser : CreateUser
    {
        public List<User> data;
    }
}
