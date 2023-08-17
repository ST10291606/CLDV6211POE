using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Models
{
    public class RentalModel
    {
        public int rentalID { get; set; }
        public int rentalFee { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string carNo { get; set; }
        public int driverID { get; set; }
        public string inspectorNo { get; set; }


    }
}
