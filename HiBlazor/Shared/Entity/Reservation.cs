using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Red Edildi")]
        Red,
        [Display(Name = "Beklemede")]
        Beklemede,
        [Display(Name = "Kabul Edildi")]
        Kabul
    }
    public enum ReservationState
    {
        [Display(Name = "Oluşturuldu")]
        Created,
        [Display(Name = "İşleniyor")]
        Doing,
        [Display(Name = "Bitti")]
        Finish
    }
}
