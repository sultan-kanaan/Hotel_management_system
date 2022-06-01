using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.DTOs
{
    public class RegisterUserDTO
    {
        [Required(ErrorMessage ="Please Enter The UserName")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="invalid UserName")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter The Passwoed")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please Enter The EmailAddress")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }

    }
}
