using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControllersApi.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public string ClientName { get; set; }
        public string Location { get; set; }
    }
}
