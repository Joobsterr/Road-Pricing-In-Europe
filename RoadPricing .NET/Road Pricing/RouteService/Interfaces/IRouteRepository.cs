namespace RouteService.Interfaces
{
    public interface IRouteRepository
    {
        Task<Route> GetRoutes();
        Task<Route> GetRoute(int carID);

    }
}
