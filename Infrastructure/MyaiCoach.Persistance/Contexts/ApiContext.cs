using Microsoft.EntityFrameworkCore;
using MyaiCoach.Domain.Entities;
using MyaiCoach.Domain.Entities.Common;

namespace MyaiCoach.Persistance.Contexts
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Exercise> Exercises { get; set; }

        public DbSet<SetRep> SetReps { get; set; }

        public DbSet<WorkoutDay> WorkoutDays { get; set; }

        public DbSet<WorkoutSession> WorkoutSessions { get; set; }

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


    }
}
