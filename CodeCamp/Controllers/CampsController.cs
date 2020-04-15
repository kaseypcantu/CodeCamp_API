using System;
using System.Threading.Tasks;
using AutoMapper;
using CodeCamp.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeCamp.Controllers
{
    [Route("api/[controller]")]
    public class CampsController : ControllerBase
    {
        private readonly ICampRepository _repository;
        private readonly IMapper _mapper;

        public CampsController(ICampRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet]
        // GET
        public async Task<ActionResult<CampModel[]>> Get()
        {
            try
            {
                var results = await _repository.GetAllCampsAsync();

                CampModel[] models = _mapper.Map<CampModel[]>(results);

                return models;
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database Failure");
            }
        }
    }
}