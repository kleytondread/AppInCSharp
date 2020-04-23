using Microsoft.EntityFrameworkCore;
using Pitang.ONS.Treinamento.Entities;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Pitang.ONS.Treinamento.IRepository.EFRepository
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        
        public DatabaseContext(DbContextOptions<DatabaseContext> dbContext) : base(dbContext)
        {
                
        }
        public DatabaseContext()
        {
        }

        public override int SaveChanges()
        {
            Audit();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            Audit();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserModel>()
                .HasMany(e => e.Contacts)
                .WithOne()
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<UserModel>()
                .HasIndex(e => e.UserName)
                    .IsUnique();

            modelBuilder.Entity<UserModel>()
                .HasIndex(e => e.Email)
                    .IsUnique();
        }

        public void Audit()
        {
            var entries = ChangeTracker.Entries()
                .Where(entry => entry.Entity is AuditEntity &&
                        entry.State == EntityState.Added ||
                        entry.State == EntityState.Modified ||
                        entry.State == EntityState.Deleted);

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((AuditEntity)entry.Entity).CreatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        ((AuditEntity)entry.Entity).LastUpdateDate = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        ((AuditEntity)entry.Entity).LastUpdateDate = DateTime.Now;
                        ((AuditEntity)entry.Entity).IsDeleted = true;
                        break;
                }
            }
        }
    }
}
