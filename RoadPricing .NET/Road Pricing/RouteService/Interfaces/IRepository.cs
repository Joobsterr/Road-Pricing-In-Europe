namespace RouteService.Interfaces
{
    public interface IRepository
    {
        Task<Route> GetRoutes();
        Task<Route> GetRoute(int carID);

    }
}
