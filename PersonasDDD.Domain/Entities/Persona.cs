using Personas.DDD.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.DDD.Domain.Entities
{
    public class Persona
    {
        public Guid id { get; init; }

        public PersonName nombre { get; private set; }

        public string? pwd { get; private set; }
        public int? rol_id { get; private set; }


        public Persona( Guid id)
        {
            this.id = id;
        }
        public void SetName(PersonName nombre) { 
            this.nombre = nombre;
        }
    }
}
