using Personas.DDD.Domain.Entities;
using Personas.DDD.Domain.Repositories;
using Personas.DDD.Domain.ValueObjects;

namespace PersonasDDD.Queries
{
    public class PersonaQueries
    {
        private readonly IPersonRepository _personRepository;
        public PersonaQueries(IPersonRepository _personRepository)
        {
            this._personRepository = _personRepository;
        }
        public async Task<Persona> GetPersonaIdAsync(Guid id)
        {
            var response = await _personRepository.GetPersonabyId(
                PersonId.Create(id));
            return response;
        }
    }
}
