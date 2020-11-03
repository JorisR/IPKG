using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IPKG.Web.Models
{
    public class Routes
    {
        public List<RouteItem> RouteList { get; set; }
    }

    public class RouteItem
    {
        public Guid Reference { get; set; }
        public string DepartureParking { get; set; }
        public string DestinationParking { get; set; }
        public string DepartureParkingName { get; set; }
        public string DestinationParkingName { get; set; }
        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double Distance { get; set; }

        [DisplayFormat(DataFormatString = "{0:0.00}")]
        public double TotalFuelConsumption { get; set; }
    }
}
