using System;

namespace IPKG.Domain
{
    public class Route
    {
        // Private constructor because of EF
        private Route()
        {
        }

        public Route(string departure, string destination, double distance, double averageFuelConsumption)
        {
            Reference = Guid.NewGuid();
            DepartureParking = departure;
            DestinationParking = destination;
            Distance = distance;
            AverageFuelConsumption = averageFuelConsumption;
        }

        public Guid Reference { get; private set; }
        public string DepartureParking { get; private set; }
        public string DestinationParking { get; private set; }
        public double Distance { get; private set; }
        public double AverageFuelConsumption { get; private set; }
        public double TotalFuelConsumption => (AverageFuelConsumption / 100) * Distance;


        public void SetRouteParking(string departure, string destination, double distance)
        {
            DepartureParking = departure;
            DestinationParking = destination;
            Distance = distance;

        }

        public void SetAverageFuelConsumption(double averageFuelConsumption)
        {
            AverageFuelConsumption = averageFuelConsumption;
        }


    }
}
