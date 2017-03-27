using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;
using Entidades;

namespace DAL
{
    public class BarberShopDb : DbContext
    {
        public BarberShopDb() : base("ConStr")
        {

        }
        public DbSet<Usuarios> usuario { get; set; }
        public DbSet<Clientes> cliente { get; set; }
        public DbSet<Peluqueros> peluquero { get; set; }
        public DbSet<Turnos> turno { get; set; }
        public DbSet<TipoServicios> servicio { get; set; }
        public DbSet<Facturas> factura { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Facturas>()
                .HasMany(p => p.ServicioList)
                .WithMany(p => p.FacturaList)
                .Map(mapeo =>
                {
                    mapeo.MapLeftKey("ServicioId");
                    mapeo.MapRightKey("FacturaId");
                    mapeo.ToTable("FacturaServicios");
                });
        }
    }
}
