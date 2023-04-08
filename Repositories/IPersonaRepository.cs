using PRUEBA_TECNICA_UDD.Models;

namespace PRUEBA_TECNICA_UDD.Repositories
{
    public interface IPersonaRepository
    {
        public Task<Persona> GetPersonaByIdAsync(int Id);
        public Task<Persona> AddPersonaAsync(Persona Persona);
        public Task<int> DeletePersonaAsync(int Id);
    }
}
