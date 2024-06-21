using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MyAplication.DTO;
using MyAplication.Operation;
using MyAplication.Rutes;
using System.Net;

namespace MyAplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : ControllerBase
    {
        private PersonaOperation _ope;
        public PersonaController(PersonaOperation op) 
        { 
            _ope = op;
        }

        [HttpGet("GetPersona")]
        public async Task<IActionResult> GetPersonas()
        {
            var operation = await _ope.GetPersonas();
            return Ok(operation);
        }

        [HttpPost("AddPersona")]
        public async Task<IActionResult> createPersona([FromBody]PersonaDTO persona)
        {
            Persona result = new Persona
            {
                Id = persona.Id,
                Name = persona.Name,
                Lastname = persona.Lastname,
                Gmail = persona.Gmail,
                Dni = persona.Dni,
            };

            var operation = await _ope.CreatePersona(result);
           
            return Ok(operation);

        }

        [HttpPut("UpdatePersona/{id}")]
        public async Task<IActionResult> UpdatePersona(PersonaDTO persona)
        {
            bool result = await _ope.UpdatePersona(persona);

            return Ok(result);
        }


        [HttpDelete("DeletePersona/{id}")]
        public async Task<IActionResult> DeletePersona([FromRoute]int id)
        {
            bool result = await _ope.DeletePersona(id);

            return Ok(result);
        }
    }
}


