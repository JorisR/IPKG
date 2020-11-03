using System;
using System.Collections.Generic;
using System.Text;

namespace IPKG.Application.Services.Dto
{
    public class RouteDto
    {
        public Guid? Reference { get; set; }
        public string DepartureParking { get; set; }
        public string DestinationParking { get; set; }
        public double AverageFuelConsumption { get; set; }
    }
}
