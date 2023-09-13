using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HiBlazor.Shared.Entity
{
    public class User:BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
        public UserType UserType { get; set; }

    }
    public enum UserType
    {
        User,
        CompanyOwner
    }
}
