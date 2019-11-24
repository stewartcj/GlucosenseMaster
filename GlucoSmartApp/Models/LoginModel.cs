using System;
using System.Collections.Generic;
using System.Text;

namespace GlucoSmart.Models
{
    class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginModel(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
