using LogicaNegocio.Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace LogicaDatos.Repositorios
{
    public class LibreriaContext : DbContext
    {
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Linea> Lineas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

		
			base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLOCALDB; Initial Catalog=ObligatorioP3_BD; Integrated Security=SSPI;");
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Cliente>()
				.HasKey(c => c.Id);

			modelBuilder.Entity<Articulo>()
			    .HasKey(a => a.Id);

            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Promocion>()
              .HasKey(pr => pr.Id);

            modelBuilder.Entity<Linea>()
              .HasKey(l => l.Id);

            modelBuilder.Entity<Direccion>()
            .HasKey(d => d.Id);

            modelBuilder.Entity<Cliente>()
            .HasOne(c => c.Direccion)
            .WithOne()
            .HasForeignKey<Direccion>(d => d.ClienteId);

            modelBuilder.Entity<Linea>()
              .HasOne(b => b.Pedido)
              .WithMany(r => r.Lineas)
              .HasForeignKey(b => b.PedidoId);

            base.OnModelCreating(modelBuilder);
		}
	}
}
