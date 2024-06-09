using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyaiCoach.Domain.Entities;
using MyaiCoach.Domain.Entities.Common;
using MyaiCoach.Domain.Role;
using System.Reflection.Emit;

namespace MyaiCoach.Persistance.Contexts
{
    public class ApiContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<SetRep> SetReps { get; set; }
        public DbSet<WorkoutDay> WorkoutDays { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }


        public DbSet<Food> Foods { get; set; }
        public DbSet<Gram> Grams { get; set; }
        public DbSet<NutritionDay>NutritionDays { get; set; }
        public DbSet<NutritionSession>  NutritionSessions { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.Entity<NutritionDay>()
            .HasOne(nd => nd.AppUser)
            .WithMany(au => au.NutritionDays)
            .HasForeignKey(nd => nd.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }


            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedTime = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }


    }
}
