using Microsoft.EntityFrameworkCore;

namespace InvestigadorAPI
{
	public class InvestigadorContext : DbContext
	{
		public DbSet<Investigador> Investigadores { get; set; }
		public DbSet<Proyecto> Proyectos { get; set; }

		public InvestigadorContext(DbContextOptions<InvestigadorContext> options) :base(options){ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			List<Investigador> investigadoresInit = new List<Investigador>();
			investigadoresInit.Add(new Investigador() { InvestigadorID = Guid.Parse("82ea4c24-53f8-4648-a0e4-76c3faf03d90"), Afiliacion = "Tiempo completo", Nombre="Raul", Apellido="Raulez", Rol ="Lider"});

			modelBuilder.Entity<Investigador>(Investigador =>
			{
				Investigador.ToTable("Investigador");

				Investigador.HasData(investigadoresInit);
			});

			List<Proyecto> proyectosInit = new List<Proyecto>();
			proyectosInit.Add(new Proyecto() { proyectoID = Guid.Parse("82ea4c24-53f8-4648-a0e4-76c3faf03d91"), area="Ingenieria", fechaFin = DateTime.MaxValue, nombre ="Las latas", descripción="Son latas", lider = "Raul",  });


			modelBuilder.Entity<Proyecto>(Proyecto =>
			{

				Proyecto.ToTable("Proyecto");

				Proyecto.HasData(proyectosInit);
			});
		}
	}
}
