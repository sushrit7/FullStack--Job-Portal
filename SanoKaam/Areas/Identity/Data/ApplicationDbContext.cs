using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SanoKaam.Areas.Identity.Data;
using SanoKaam.Models;
using System.Reflection.Emit;

namespace SanoKaam.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    public DbSet<Job> Jobs { get; set; }

    public DbSet<Profile> Profiles { get; set; }

    public DbSet<Experience> Experiences { get; set; }

    public DbSet<Apply> Applies { get; set; }


    public DbSet<Education> Educations { get; set; }


    public DbSet<Skill> Skills { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
       
        
        builder.Entity<Profile>()
           .HasMany(e => e.Experience)
           .WithOne(e => e.Profile)
           .HasForeignKey(e => e.ProfileId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Profile>()
           .HasMany(e => e.Education)
           .WithOne(e => e.Profile)
           .HasForeignKey(e => e.ProfileId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Profile>()
           .HasMany(e => e.Skill)
           .WithOne(e => e.Profile)
           .HasForeignKey(e => e.ProfileId)
           .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Profile>()
          .HasMany(e => e.Apply)
          .WithOne(e => e.Profile)
          .HasForeignKey(e => e.ProfileId)
          .OnDelete(DeleteBehavior.Cascade);





        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
    }
    
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
