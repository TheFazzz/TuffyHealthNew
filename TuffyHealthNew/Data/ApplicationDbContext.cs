using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TuffyHealthNew.Models;

namespace TuffyHealthNew.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        //public DbSet<Appointments>? Appointments { get; set; }
        //public DbSet<Treatments>? Treatments { get; set; }
        //public DbSet<PatientLogs>? PatientLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Appointments>().ToTable("Appointments");
            //modelBuilder.Entity<Treatments>().ToTable("Treatments");
            //modelBuilder.Entity<PatientLogs>().ToTable("PatientLogs");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:tuffysql.database.windows.net,1433;Initial Catalog=TuffyHealth;Persist Security Info=False;User ID=david;Password=!Student1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30",
                options => options.EnableRetryOnFailure());
            
        }

    }
}