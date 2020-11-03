using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GeoCoordinatePortable;
using IPKG.Application.Services.Interfaces;
using IPKG.Application.Services.Repositories;
using IPKG.Domain;

namespace IPKG.Application.Services.Implementations
{
    internal class ParkingService : IParkingService
    {

        private List<Parking> _carParks = new List<Parking>
        {
            new Parking("PKA", "Kalmthout", new GeoCoordinate(51.381800, 4.476950)),
            new Parking("IPAN", "Antwerpen", new GeoCoordinate(51.219448, 4.402464)),
            new Parking("IPMAL", "Mechelen", new GeoCoordinate(51.028938, 4.477940)),
            new Parking("IBRUS", "Brussel", new GeoCoordinate(50.845539, 4.355710)),
            new Parking("PHAS", "Hasselt", new GeoCoordinate(50.929729, 5.338230)),
            new Parking("IPBRU", "Brugge", new GeoCoordinate(51.209391, 3.224998))
        };

    public ParkingService()
        {

        }

        public IEnumerable<Parking> GetAllCarParks()
        {
            return _carParks;
        }
    }
}
