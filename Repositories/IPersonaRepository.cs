using PRUEBA_TECNICA_UDD.DTOs;
using PRUEBA_TECNICA_UDD.Models;

namespace PRUEBA_TECNICA_UDD.Repositories
{
    public interface IPersonaRepository
    {
        public Task<Persona> GetPersonaByIdAsync(int Id);
        public Task<Persona> AddPersonaAsync(CreatePersonaDTO newPersona);
        public Task<int> DeletePersonaAsync(int Id);
    }
}
