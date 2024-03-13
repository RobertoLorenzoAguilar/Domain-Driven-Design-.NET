using Microsoft.EntityFrameworkCore;
using Personas.DDD.Domain.Entities;
namespace Personas.DDD.Infracstructure
{
    public class DataBaseContext : DbContext
    {

        //mapeo
        //tipos complejos que son en entity framework
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {


        }
        public DbSet<Persona> personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Persona>(o => o.HasKey(x => x.id));
            modelBuilder.Entity<Persona>().OwnsOne(o => o.nombre, conf =>
            {

                conf.Property(x => x.Value).HasColumnName("nombre");// objeto completo
            });
            base.OnModelCreating(modelBuilder);

            //con eso se mapea el objetoc omplejo con la columna name d ela base de datos
        }
    }
}
