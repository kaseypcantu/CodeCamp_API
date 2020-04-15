using Microsoft.AspNetCore.Mvc;

namespace CodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        // GET
        public object Get()
        {
            return new { Moniker = "AUSTIN2020", Name = "Austin Code Camp" };
        }
    }
}