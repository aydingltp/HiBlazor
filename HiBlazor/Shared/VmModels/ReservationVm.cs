using HiBlazor.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiBlazor.Shared.VmModels
{
    public class ReservationVm
    {
        public string DestinationPlace { get; set; }
        public string StartingPlace { get; set; }
        public string Description { get; set; }
        public ReservationState State { get; set; }
    }
}
