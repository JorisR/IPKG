using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPKG.Web.Models
{
    public class UpdateCreateRoute
    {
        public Guid Reference { get; set; }
        public string DepartureParking { get; set; }
        public string DestinationParking { get; set; }
        public double AverageFuelConsumption { get; set; }


    }
}
