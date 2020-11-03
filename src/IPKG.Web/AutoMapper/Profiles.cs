using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace IPKG.Web.AutoMapper
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Domain.Route, Models.UpdateCreateRoute>();
            CreateMap<Domain.Route, Models.RouteItem>();
            CreateMap<Domain.Parking, Models.Parking>();
        }
    }
}
