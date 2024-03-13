using Personas.DDD.Domain.Entities;
using Personas.DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.DDD.Domain.Repositories
{
    public interface IPersonRepository
    {
        Task<Persona> GetPersonabyId(PersonId id);
        Task AddPerson(Persona persona);
    }
}