using System;
using System.Collections.Generic;
using System.Text;
using GeoCoordinatePortable;
using NetTopologySuite.Geometries;

namespace IPKG.Domain
{
    public class Parking
    {
        // Private constructor because of EF
        private Parking() { }
        public Parking(string reference, string name, GeoCoordinate location)
        {
            Reference = reference;
            Name = name;
            Location = location;
        }
        public string Reference { get; private set; }
        public string Name { get; private set; }
        public GeoCoordinate Location { get; private set; }
    }
}
