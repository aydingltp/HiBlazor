using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiBlazor.Shared.Entity
{
    public class Reservation:BaseModel
    {
        public string DestinationPlace { get; set; }
        public string StartingPlace { get; set; }
        public string Description { get; set; }

        public int Rating { get; set; }
        public ReservationState State { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Teklif> Teklifler { get; set; }
    }

    public class Teklif : BaseModel
    {
        public int Para { get; set; }

        public TeklifState State { get; set; }

        //[ForeignKey("VehicleId")]
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }

        //[ForeignKey("CompanyId")]
        //public int CompanyId { get; set; }
        //public Company? Company { get; set; }
    }

    public enum TeklifState
    {
        Red,
        Beklemede,
        Kabul
    }
    public enum ReservationState
    {
        Created,
        Doing,
        Finish
    }
}
