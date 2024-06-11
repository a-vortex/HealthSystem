using HealthSystem.Models.User;
using Microsoft.EntityFrameworkCore;

namespace HealthSystem.Data;
public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<HealthPlan> HealthPlans { get; set; }
    public DbSet<MedicalService> MedicalServices { get; set; }
    public DbSet<MedicalAppointment> MedicalAppointments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-6GD96SPC\SQLEXPRESS;Database=HealthSystem;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users")
            .HasDiscriminator<string>("UserType")
            .HasValue<Doctor>("Doctor")
            .HasValue<Customer>("Customer");

        modelBuilder.Entity<Doctor>().ToTable("Doctors");
        modelBuilder.Entity<Customer>().ToTable("Customers");

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.PersonalInfo, personal =>
            {
                personal.Property(p => p.Name).IsRequired();
                personal.Property(p => p.Address).IsRequired();
                personal.Property(p => p.Email).IsRequired();
                personal.Property(p => p.Telephone).IsRequired();
            });
    }
}
