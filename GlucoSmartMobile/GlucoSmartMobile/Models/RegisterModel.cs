using System;
using System.Collections.Generic;
using System.Text;

namespace GlucoSmartMobile.Models
{
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public int Weight { get; set; }
        public string DoctorID { get; set; }
        public string PhoneNumber { get; set; }

        public RegisterModel()
        {

        }
    }
}
