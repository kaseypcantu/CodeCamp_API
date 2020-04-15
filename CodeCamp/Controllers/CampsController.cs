using System;
using System.Threading.Tasks;
using CodeCamp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _repository;

        public CampsController(ICampRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        // GET
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repository.GetAllCampsAsync();
                return Ok(results);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}