using Microsoft.AspNetCore.Mvc;
using RouteService.Models;

namespace RouteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        public Models.Route GetSpecificRoute(int id)
        {
            return new Models.Route();
        }
        public bool AddRoute(Models.Route)
        {
            return true;
        }
    }
}