using Microsoft.AspNetCore.Mvc;
using RouteService.Models;

namespace RouteService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RouteController : ControllerBase
    {
        public Models.RouteModel GetSpecificRoute(int id)
        {
            return new RouteModel();
        }
        public bool AddRoute(RouteModel routeModel)
        {
            return true;
        }
    }
}