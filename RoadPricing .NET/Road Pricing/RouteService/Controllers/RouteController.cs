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
            return new Models.RouteModel();
        }
        public bool AddRoute(Models.RouteModel)
        {
            return true;
        }
    }
}