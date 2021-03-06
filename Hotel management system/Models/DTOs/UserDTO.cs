using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel_management_system.Models.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        // public string Roles { get; set; }

        [NotMapped]
        public IList<string> Roles { get; set; }

    }
}
