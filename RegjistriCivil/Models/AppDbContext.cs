using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace RegjistriCivil.Models
{
    public class AppDbContext : IdentityDbContext // App Dbcontext must inherit from IdentityDbContext
    {                                               
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<IdCard> IdCards { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }
        public DbSet<MarriageCertificate> MarriageCertificates { get; set; }
        public DbSet<DeathCertificate> DeathCertificates { get; set; }
        public DbSet<FamilyCertificate> FamilyCertificates { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonStatistic> PersonStatistics { get; set; }
        public DbSet<FamilyMemberBase> FamilyMembers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
            //modelBuilder.Seed();
        }
    }

}
