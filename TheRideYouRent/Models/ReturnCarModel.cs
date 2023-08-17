using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Models
{
    public class ReturnCarModel
    {
        public int returnCarID { get; set; }
        public string returnDate { get; set; }
        public int elapsedDate { get; set; }
        public string carNo { get; set; }
        public int driverID { get; set; }
        public string inspectorNo { get; set; }
        public int fineID { get; set; }
        public int fineAmount { get; set; }
    }
}