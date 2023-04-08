using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRUEBA_TECNICA_UDD.Data;
using PRUEBA_TECNICA_UDD.DTOs;
using PRUEBA_TECNICA_UDD.Models;
using System.Text.Json;

namespace PRUEBA_TECNICA_UDD.Repositories
{
    public class PersonaRepository : IPersonaRepository
    {
        private readonly DbContextClass _dbContext;
        private readonly IMapper _mapper;

        public PersonaRepository(DbContextClass dbContext, IMapper autoMapper)
        {
            _dbContext = dbContext;
            _mapper = autoMapper;
        }
        public async Task<Persona> AddPersonaAsync(CreatePersonaDTO newPersona)
        {
            var persona = _mapper.Map<Persona>(newPersona);

            // Aquí realice la call al endpoint del gobierno para obtener respuesta feriado o no feriedo enviando una fecha en formato 0001/01/01
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://apis.digital.gob.cl/fl/feriados/");

                var response = await client.GetAsync(persona.FechaIngreso.ToString("yyyy/MM/dd"));
                if (response.IsSuccessStatusCode)
                {
                    string strFeriadoLegal = await response.Content.ReadAsStringAsync();

                    var feriadoLegal = JsonSerializer.Deserialize<List<FeriadosCL>>(strFeriadoLegal);

                    if (feriadoLegal is not null)
                    {
                        persona.EsFeriadoLegal = feriadoLegal[0].irrenunciable == "1" ? true : false;
                    }
                }
            }

            var result = _dbContext.Personas.Add(persona);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeletePersonaAsync(int Id)
        {
            var filteredData = _dbContext.Personas.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Personas.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Persona> GetPersonaByIdAsync(int Id)
        {
            return await _dbContext.Personas.FirstOrDefaultAsync(x => x.Id == Id);
        }
    }
}
