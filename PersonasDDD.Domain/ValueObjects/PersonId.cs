using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personas.DDD.Domain.ValueObjects
{
    public record PersonId // del tipo record son inmutables
    {
        public Guid Value { get; init; }

        internal PersonId(Guid value)
        {
            this.Value = value;
        }

        public static PersonId Create(Guid value)
        {

            return new PersonId(value);
        }

        public static implicit operator Guid(PersonId personId)
        {
            return personId.Value;
        }
    }
}
