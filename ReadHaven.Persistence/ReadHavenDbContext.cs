using Microsoft.EntityFrameworkCore;
using ReadHaven.Domain.Common;
using ReadHaven.Domain.Entities;

namespace ReadHaven.Persistence
{
    public class ReadHavenDbContext : DbContext
    {
        public ReadHavenDbContext(DbContextOptions<ReadHavenDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Global query filters for soft deletes
            modelBuilder.Entity<Book>().HasQueryFilter(b => !b.IsDeleted);
        }

        public override int SaveChanges()
        {
            SetUpdatedAtForModifiedEntities();
            HandleSoftDeletes();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetUpdatedAtForModifiedEntities();
            HandleSoftDeletes();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void SetUpdatedAtForModifiedEntities()
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Modified);

            foreach (var entry in modifiedEntities)
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    baseEntity.UpdatedAt = DateTime.Now;
                }
            }
        }

        private void HandleSoftDeletes()
        {
            var deletedEntities = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted);

            foreach (var entry in deletedEntities)
            {
                if (entry.Entity is BaseEntity baseEntity)
                {
                    baseEntity.IsDeleted = true;
                    entry.State = EntityState.Modified;
                }
            }
        }
    }
}
