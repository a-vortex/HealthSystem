using Microsoft.EntityFrameworkCore;
using HealthSystem.Models.Users;


namespace HealthSystem.Data;
public class HealthSystemDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<HealthPlan> HealthPlans { get; set; }
    public DbSet<MedicalAppointment> MedicalAppointments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=LAPTOP-6GD96SPC\SQLEXPRESS;Database=HealthSystem;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<Doctor>().ToTable("Doctors");
        modelBuilder.Entity<Customer>().ToTable("Customers");

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.PersonalInfo, personal =>
            {
                personal.Property(p => p.Name).IsRequired();
                personal.Property(p => p.Address).IsRequired();
                personal.Property(p => p.Email).IsRequired();
                personal.Property(p => p.Telephone).IsRequired();
                personal.Property(p => p.Cpf).IsRequired();
            });

        modelBuilder.Entity<HealthPlan>().HasKey(hp => hp.PlanId);

        modelBuilder.Entity<MedicalAppointment>().HasKey(ma => ma.AppointmentId);
        modelBuilder.Entity<MedicalAppointment>()
                .OwnsOne(ma => ma.medicalService, ms =>
                {
                    ms.Property(m => m.Name).IsRequired();
                    ms.Property(m => m.Price).IsRequired();
                    ms.Property(m => m.Description).IsRequired();
                    ms.Property(m => m.Type).IsRequired();
                    ms.Property(m => m.Area).IsRequired();
                });

        modelBuilder.Entity<Customer>()
            .HasOne(c => c.HealthPlan)
            .WithMany()
            .HasForeignKey(c => c.HealthPlanId);

        modelBuilder.Entity<MedicalAppointment>()
            .HasOne(ma => ma.Doctor)
            .WithMany()
            .HasForeignKey(ma => ma.DoctorId)
            .HasPrincipalKey(d => d.id);

        modelBuilder.Entity<MedicalAppointment>()
            .HasOne(ma => ma.Customer)
            .WithMany()
            .HasForeignKey(ma => ma.PatientId)
            .HasPrincipalKey(c => c.id);
    }
}
