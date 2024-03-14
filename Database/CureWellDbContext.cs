using CureWell.Models;
using Microsoft.EntityFrameworkCore;

namespace CureWell.Database
{
    public class CureWellDbContext : DbContext
    {
        public CureWellDbContext(DbContextOptions<CureWellDbContext> options) : base(options)
        {

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Surgery> Surgeries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorSpecialization>().HasKey(e=>new {e.DoctorID,e.SpecializationCode});
            
            modelBuilder.Entity<Doctor>()
                .HasAnnotation("AutoIncrement", true)
                .HasAnnotation("StartValue", 1000);

            
                
                
        }

    }
}