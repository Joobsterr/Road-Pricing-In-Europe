using Microsoft.AspNetCore.Mvc;

namespace RouteService.Interfaces
{
    public interface IRouteService
    {
        public Task<List<Route>> GetCarRoutsLastMonth(int carID);
        public Task<Route> getRoute(int routeID);

    }
}
