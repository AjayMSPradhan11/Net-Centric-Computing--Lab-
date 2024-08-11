using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class StudentRegistrationDb: IdentityDbContext{
  public DbSet<Author> Authors { get; set; }
  public DbSet<ApplicationUser> Users { get; set; }

    public StudentRegistrationDb(DbContextOptions<StudentRegistrationDb> options) : base(options) { }
}