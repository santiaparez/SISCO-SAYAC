using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SISCO_SAYACv3._5.Models;

namespace SISCO_SAYACv3._5.Models
{
    public class SISCO_SAYACv3_5Context : DbContext
    {
        public SISCO_SAYACv3_5Context (DbContextOptions<SISCO_SAYACv3_5Context> options)
            : base(options)
        {
        }

        public DbSet<SISCO_SAYACv3._5.Models.Auditorias> Auditorias { get; set; }

        public DbSet<SISCO_SAYACv3._5.Models.Contratistas> Contratistas { get; set; }

        public DbSet<SISCO_SAYACv3._5.Models.Contratos> Contratos { get; set; }

        public DbSet<SISCO_SAYACv3._5.Models.Obras> Obras { get; set; }

        public DbSet<SISCO_SAYACv3._5.Models.Reportes> Reportes { get; set; }

        public DbSet<SISCO_SAYACv3._5.Models.Usuarios> Usuarios { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Obras>()
                .HasOne(p => p.Contratistas)
                .WithMany(b => b.Obra)
                .HasForeignKey(p => p.ContratistasId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("ForeignKey_Obras_Contratistas");

        }*/
    }
}
