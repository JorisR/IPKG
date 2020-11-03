using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPKG.Application.Services.Dto;
using IPKG.Application.Services.Interfaces;
using IPKG.Application.Services.Repositories;
using IPKG.Domain;

namespace IPKG.Application.Services.Implementations
{
    internal class RouteService : IRouteService
    {
        private readonly IRouteRepository _repository;
        private readonly IParkingService _parkingService;

        public RouteService(IRouteRepository repository, IParkingService parkingService)
        {
            _repository = repository;
            _parkingService = parkingService;
        }

        public async Task<IEnumerable<Route>> GetAllRoutes()
        {
            return await _repository.GetAllRoutes();
        }

        public async Task<Route> GetRouteByReference(Guid reference)
        {
            return await _repository.GetByReference(reference);
        }

        public async Task<Route> InsertUpdateRoute(RouteDto routeDto)
        {
            var carParks =  _parkingService.GetAllCarParks().ToList();
            var destination = carParks.FirstOrDefault(x => x.Reference == routeDto.DestinationParking);
            var departure = carParks.FirstOrDefault(x => x.Reference == routeDto.DepartureParking);
            if (departure == null || destination == null)
                return null;
            var distance = destination.Location.GetDistanceTo(departure.Location) / 1000;
            Route route;
            if (routeDto.Reference == null)
            {
                route = new Route(routeDto.DepartureParking, routeDto.DestinationParking, distance, routeDto.AverageFuelConsumption);
                await _repository.AddRoute(route);
            }
            else
            {
                route = await _repository.GetByReference(routeDto.Reference.Value);
                route.SetRouteParking(routeDto.DepartureParking, routeDto.DestinationParking, distance);
                route.SetAverageFuelConsumption(routeDto.AverageFuelConsumption);
            }

            await _repository.UnitOfWork.SaveChangesAsync();
            return route;
        }
    }
}
