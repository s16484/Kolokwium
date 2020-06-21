using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kolokwium.DTOs;
using kolokwium.Models;
using kolokwium.Services;
using Kolokwium.Models;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AddMusician(Musician doc)
        {
            //_dbservice.AddMusician(doc);
            return Ok("Dodano doktora");
        }



    }
}
