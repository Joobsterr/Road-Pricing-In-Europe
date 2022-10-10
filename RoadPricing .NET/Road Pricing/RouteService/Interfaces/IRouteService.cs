using Microsoft.AspNetCore.Mvc;

namespace RouteService.Interfaces
{
    public interface IRouteService
    {
        public Task<List<Route>> getRoutes();
        public Task<Route> getRoute(int routeID);

    }
}
