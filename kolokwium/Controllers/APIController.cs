using System;
using kolokwium.DTOs;
using kolokwium.Services;
using Microsoft.AspNetCore.Mvc;

namespace kolokwium.Controllers
{
    [ApiController]
    [Route("api/musicians")]
    public class APIController : ControllerBase
    {
        private readonly IDbService _dbservice;

        public APIController(IDbService dbservice)
        {
            _dbservice = dbservice;
        }

        [HttpGet("{id}")]
        public IActionResult GetMusician(int id)
        {
            GetMusicianResponse response;

            try
            {
                response = _dbservice.GetMusician(id);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok(response);

        }

        [HttpPost]
        public IActionResult AddMusician(MusicianRequest request)
        {
            try
            {
                _dbservice.AddMusician(request);

            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok("Dodano muzyka");

        }

    }
}
