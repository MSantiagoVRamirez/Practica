using Microsoft.EntityFrameworkCore;
using Practica.Server.Models.Medicamentos;

namespace Practica.Server.Models
{
    public class MedicamentosContext : DbContext
    {
        public MedicamentosContext(DbContextOptions<MedicamentosContext> options) : base(options)
        {
        }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Presentacion> Presentacion { get; set; }
        public DbSet<Medicamento> Medicamento { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Categoria>()
                .HasOne(c => c.EstadoFk)
                .WithMany()
                .HasForeignKey(c => c.estadoCategoria)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presentacion>()
                .HasOne(p => p.EstadoFk)
                .WithMany()
                .HasForeignKey(p => p.estadoPresentacion)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Medicamento>()
                .HasOne(m => m.CategoriaFk)
                .WithMany()
                .HasForeignKey(m => m.categoriaId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Medicamento>()
                .HasOne(m => m.PresentacionfK)
                .WithMany()
                .HasForeignKey(m => m.presentacionId)
                .OnDelete(DeleteBehavior.Restrict);
        }    } 
 }
