using Personas.DDD.Domain.Entities;
using Personas.DDD.Domain.Repositories;
using Personas.DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.DDD.Infracstructure
{


    public class PersonRepository : IPersonRepository
    {
        DataBaseContext db;
        public PersonRepository(DataBaseContext db)
        {
            this.db = db;
        }

        public async Task AddPerson(Persona persona)
        {
            await db.AddAsync(persona);
            await db.SaveChangesAsync();
        }

        public async Task<Persona> GetPersonabyId(PersonId id)
        {
            return await db.personas.FindAsync((Guid)id);
        }
    }
}
