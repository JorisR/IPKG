using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using IPKG.Application.Services.Dto;
using IPKG.Application.Services.Interfaces;
using IPKG.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IPKG.Web.Controllers
{
    public class RouteController : Controller
    {
        private readonly IParkingService _parkingService;

        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public RouteController(IMapper mapper ,IParkingService parkingService, IRouteService routeService)
        {
            _parkingService = parkingService;
            _routeService = routeService;
            _mapper = mapper;
        }

        // GET: all Routes
        public async Task<IActionResult> Index()
        {
            var routes = (await _routeService.GetAllRoutes()).Select(_mapper.Map<RouteItem>).ToList();
            var carParks = _parkingService.GetAllCarParks().ToList();
            routes.ForEach(x=> SetRightParking(x, carParks));
            var model = new Routes
            {
                RouteList = routes.ToList()
            };
            return View(model);
        }

        private void SetRightParking(RouteItem route, List<Domain.Parking> parking)
        {
            route.DepartureParkingName = parking.FirstOrDefault(x => x.Reference == route.DepartureParking)?.Name;
            route.DestinationParkingName = parking.FirstOrDefault(x => x.Reference == route.DestinationParking)?.Name;
        }

        // GET: Route/Create
        public IActionResult Create()
        {
            ViewData["CarParks"] = _parkingService.GetAllCarParks().Select(_mapper.Map<Parking>);
            return View("UpdateCreate", new UpdateCreateRoute());
        }

        // Post: Route/Edit/
        [HttpPost]
        public async Task<IActionResult> Create(UpdateCreateRoute route)
        {
            try
            {
                await _routeService.InsertUpdateRoute(new RouteDto { DepartureParking = route.DepartureParking, DestinationParking = route.DestinationParking, AverageFuelConsumption = route.AverageFuelConsumption });
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }


        // Get: Route/Edit/1
        public async Task<IActionResult> Edit(Guid reference)
        {
            var item = await _routeService.GetRouteByReference(reference);
            ViewData["CarParks"] =  _parkingService.GetAllCarParks().Select(_mapper.Map<Parking>);
            return View("UpdateCreate", _mapper.Map<UpdateCreateRoute>(item));
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateCreateRoute route)
        {
            try
            {
                await _routeService.InsertUpdateRoute(new RouteDto { Reference = route.Reference,DepartureParking = route.DepartureParking, DestinationParking = route.DestinationParking, AverageFuelConsumption = route.AverageFuelConsumption});
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}