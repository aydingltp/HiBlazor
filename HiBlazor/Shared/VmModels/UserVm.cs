using HiBlazor.Shared.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace HiBlazor.Shared.VmModels
{
    public class UserRegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
        public bool IsCompany { get; set; }
        public Company Company { get; set; } = new Company();
        //public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
    public class UserUpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
