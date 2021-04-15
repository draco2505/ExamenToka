using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonaFisica.Core.Entities;
using PersonaFisica.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaFisica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaFisicaController : ControllerBase
    {
        private readonly IPersonaFisicaRepositorio _personaFisicaRepositorio;
        public PersonaFisicaController(IPersonaFisicaRepositorio personaFisicaRepositorio)
        {
            _personaFisicaRepositorio = personaFisicaRepositorio;
        }
        [HttpGet]
        public async Task<IActionResult> GetPersonasFisicas()
        {
            var Personas = await _personaFisicaRepositorio.GetPersonasFisicas();

            return Ok(Personas);
        }

        [HttpGet("{IdPersonaFisica}")]
        public async Task<IActionResult> GetPersonasFisicas(int IdPersonaFisica)
        {
            var Persona = await _personaFisicaRepositorio.GetPersonaFisicaPorID(IdPersonaFisica);

            return Ok(Persona);
        }

        [HttpPost]
        [Route("api/PostPersonaFisica")]
        public async Task<IActionResult> PostPersonaFisica(TbPersonasFisica Persona)
        {
            await _personaFisicaRepositorio.PostPersonaFisica(Persona);
            return Ok(Persona);
        }

        [HttpPut]
        [Route("api/PutPersonaFisica")]
        public async Task<IActionResult> PutPersonaFisica(int IdPersonaFisica, TbPersonasFisica Persona)
        {
            if(IdPersonaFisica == Persona.IdPersonaFisica)
            {
                bool Exito = await _personaFisicaRepositorio.PutPersonaFisica(Persona);
                return Ok(Exito);
            }
            return BadRequest();
        }

        [HttpDelete("DeletePersonaFisica/{IdPersonaFisica:int}")]
        public async Task<IActionResult> DeletePersonaFisica(int IdPersonaFisica)
        {
            bool Exito = await _personaFisicaRepositorio.DeletePersonaFisica(IdPersonaFisica);
            return Exito ? Ok(Exito) : BadRequest();
        }

        [HttpPost]
        [Route("api/PostPersonaFisicaSP")]
        public async Task<IActionResult> PostPersonaFisicaSP(TbPersonasFisica Persona)
        {
            var Result = await _personaFisicaRepositorio.PostPersonaFisicaSP(Persona);
            if (Result.Error > 0)
            {
                return Ok();
            }
            return BadRequest(Result);
        }

        [HttpPut]
        [Route("api/PutPersonaFisicaSP/{IdPersonaFisica}")]
        public async Task<IActionResult> PutPersonaFisicaSP(int IdPersonaFisica, TbPersonasFisica Persona)
        {
            var Result = await _personaFisicaRepositorio.PutPersonaFisicaSP(Persona);
            if (Result.Error > 0)
            {
                return Ok();
            }
            return BadRequest(Result);
        }

        [HttpDelete("DeletePersonaFisicaSP/{IdPersonaFisicaSP}")]
        public async Task<IActionResult> DeletePersonaFisicaSP(int IdPersonaFisicaSP)
        {
            var Result = await _personaFisicaRepositorio.DeletePersonaFisicaSP(IdPersonaFisicaSP);
            if(Result.Error == 0)
            {
                return Ok();
            }
            return BadRequest(Result);
        }
    }
}
