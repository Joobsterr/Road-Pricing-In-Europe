using Microsoft.AspNetCore.Mvc;
using RouteService.Interfaces;

namespace RouteService.Services
{
    public class RouteService : IRouteService
    {
        public Task<bool> DeleteRoute(int routeID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Route>> GetCarRoutsLastMonth(int carID)
        {
            throw new NotImplementedException();
        }

        public Task<Route> getRoute(int routeID)
        {
            throw new NotImplementedException();
        }

        public Task<List<Route>> getRoutes()
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> PostRoute()
        {
            throw new NotImplementedException();
        }
    }
}
