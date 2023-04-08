using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PRUEBA_TECNICA_UDD.Commands;
using PRUEBA_TECNICA_UDD.DTOs;
using PRUEBA_TECNICA_UDD.Models;
using PRUEBA_TECNICA_UDD.Queries;
using System.Globalization;
using System.Net;

namespace PRUEBA_TECNICA_UDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonaController(IMediator mediator, IMapper mapper)
        {
            this._mediator = mediator;
            this._mapper = mapper;
        }

        [HttpGet("personaId")]
        public async Task<IActionResult> GetPersonaByIdAsync(int? personaId)
        {
            // Verfificar el valor recibido en la peticion Get 
            if (!personaId.HasValue || personaId < 0)
            {
                return BadRequest("Id persona es requerido.");
            }

            var persona = await _mediator.Send(new GetPersonaByIdQuery() { Id = (int)personaId });

            if (persona is null)
            {
                return NotFound($"La persona con el Id {personaId} no existe.");
            }

            return Ok(persona);
        }
        [HttpPost]
        public async Task<IActionResult> AddPersonaAsync(CreatePersonaDTO newPersona)
        {
            try
            {
                if (newPersona is null || string.IsNullOrEmpty(newPersona.Nombre))
                {
                    return BadRequest("Persona no puede estar vacío.");
                }

                DateTime fechaIngresa;

                bool validDate = DateTime.TryParseExact(
                newPersona.FechaIngreso.ToString("yyyy/MM/dd"),
                "yyyy/MM/dd",
                DateTimeFormatInfo.InvariantInfo, // Esto significa independiente del culture info que se defina
                DateTimeStyles.None,
                out fechaIngresa);

                if (!validDate) return BadRequest("Fecha no válida.");

                var persona = await _mediator.Send(new CreatePersonaCommand(
                newPersona.Nombre,
                newPersona.FechaIngreso));

                return Created($"/personaId?id={persona.Id}", persona);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePersonaAsync(int personaId)
        {
            try
            {
                //Verificar si Persona existe
                var persona = await _mediator.Send(new GetPersonaByIdQuery() { Id = personaId });

                //Si Persona es null retorna 404 NotFound
                if (persona == null)
                {
                    return NotFound();
                }

                int rowsDeleted = await _mediator.Send(new DeletePersonaCommand() { Id = personaId });

                if (rowsDeleted > 0) return NoContent();
                else
                {
                    // En caso de no borrar el registro
                    return BadRequest();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
