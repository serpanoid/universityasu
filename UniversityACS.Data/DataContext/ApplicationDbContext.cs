using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.Entities;

namespace UniversityACS.Data.DataContext;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Discipline> Disciplines { get; set; }
    public DbSet<ScientificAndPedagogicalActivity> ScientificAndPedagogicalActivities { get; set; }
    public DbSet<Syllabus> Syllabi { get; set; }
    public DbSet<Traineeship> Traineeships { get; set; }
}