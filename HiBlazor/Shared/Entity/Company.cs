using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiBlazor.Shared.Entity
{
    public class Company : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int RatingScore { get; set; }

        public int OwnerId { get; set; }
        public User Owner { get; set; }

        public List<Vehicle> Vehicles { get; set; }

    }

    public class Vehicle : BaseModel
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string DriverName { get; set; }
        public string DriverPhone { get; set; }
        public int CompanyId { get; set; }

        public VehicleType VehicleType { get; set; }
    }

    public enum VehicleType
    {
        Small,
        Medium,
        Large
    }
}
