using MediatR;
using PRUEBA_TECNICA_UDD.Commands;
using PRUEBA_TECNICA_UDD.Models;
using PRUEBA_TECNICA_UDD.Repositories;

namespace PRUEBA_TECNICA_UDD.Handlers
{
    public class CreatePersonaHandler : IRequestHandler<CreatePersonaCommand, Persona>
    {
        private readonly IPersonaRepository _personaRepository;

        public CreatePersonaHandler(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }
        public async Task<Persona> Handle(CreatePersonaCommand command, CancellationToken cancellationToken)
        {
            var persona = new Persona()
            {
                Nombre = command.Nombre,
                FechaIngreso = command.FechaIngreso,
                EsFeriadoLegal= command.EsFeriadoLegal,
            };

            return await _personaRepository.AddPersonaAsync(persona);
        }
    }
}
