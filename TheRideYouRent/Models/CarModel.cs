using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheRideYouRent.Models
{
    public class CarModel
    {
        public string carNo { get; set; }
        public string carMake { get; set; }
        public string carModel { get; set; }
        public string carBodyType { get; set; }
        public int kilometresTravelled { get; set; }
        public int serviceKilometres { get; set; }
        public string available { get; set; }

    }
}
