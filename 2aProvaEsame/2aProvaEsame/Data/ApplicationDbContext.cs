using System;
using System.Collections.Generic;
using System.Text;
using _2aProvaEsame.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _2aProvaEsame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<DatiRichiesta>()
                .HasOne(dr => dr.Richiedente)
                .WithMany(r => r.RichiesteCreate)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<DatiRichiesta>()
                .HasOne(dr => dr.Assegnato)
                .WithMany(r => r.RichiesteAssegnate)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<DatiAnagrafici> DatiAnagrafici { get; set; }

        public DbSet<DatiRichiesta> DatiRichieste { get; set; }
    }
}
