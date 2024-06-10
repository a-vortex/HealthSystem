using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ConsoleAppDb;Trusted_Connection=True;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<Doctor>().ToTable("Doctors");
        modelBuilder.Entity<Customer>().ToTable("Customers");

        modelBuilder.Entity<Doctor>()
            .HasBaseType<User>();

        modelBuilder.Entity<Customer>()
            .HasBaseType<User>();

        modelBuilder.Entity<User>()
            .OwnsOne(u => u.PersonalInfo);
    }
}
