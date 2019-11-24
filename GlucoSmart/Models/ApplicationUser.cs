using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace GlucoSmart.Models
{
    public class ApplicationUser : IdentityUser
    {
        [NotMapped]
        public ICollection<string> Roles { get; set; }
        
           
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "DOB")]
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }

        [Display(Name = "Weight")]
        public int Weight { get; set; }

        [Display(Name = "DoctorID")]
        public string DoctorID { get; set; }


        public bool HasRole (string roleName)
        {
            return Roles.Any(r => r == roleName);
        }
    }
}
