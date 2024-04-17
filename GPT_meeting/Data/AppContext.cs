using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace GPT_meeting.Data
{
    internal class AppContext : DbContext
    {
        //public DbSet<IncomingMail> IncomingMails => Set<IncomingMail>();
        //public DbSet<IncomingMailFile> IncomingMailFiles => Set<IncomingMailFile>();
        //public DbSet<User> Users => Set<User>();
        //public DbSet<Sender> Senders => Set<Sender>();
        //public DbSet<DeliveryMethod> DeliveryMethods => Set<DeliveryMethod>();
        //public DbSet<Executor> Executors => Set<Executor>();
        //public DbSet<Project> Projects => Set<Project>();
        //public DbSet<IncomingHistoryEntry> IncomingHistory => Set<IncomingHistoryEntry>();
        //public DbSet<Signature> Signatures => Set<Signature>();
        //public DbSet<Privilege> Privileges => Set<Privilege>();
        //public DbSet<Department> Departments => Set<Department>();
        //public DbSet<Position> Positions => Set<Position>();
        //public DbSet<ExecutionOrder> ExecutionOrders => Set<ExecutionOrder>();
        //public DbSet<ExecutionStatus> ExecutionStatuses => Set<ExecutionStatus>();

        //public AdUserProvider CurrentUserProvider { get; }

        //public AppContext(DbContextOptions<AppContext> options, AdUserProvider currentUserProvider) : base(options)
        //{
        //    //Database.EnsureCreated();
        //    CurrentUserProvider = currentUserProvider;
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    modelBuilder.ApplyConfiguration(new SignatureConf());
        //    modelBuilder.ApplyConfiguration(new IncomingMailConf());
        //}

        //public override int SaveChanges()
        //{
        //    var userName = CurrentUserProvider.GetCurrentUser();

        //    if (userName is not null)
        //    {
        //        var user = Users.FirstOrDefault(x => x.AdLogin == userName);

        //        SetEntityes(user);
        //    }

        //    return base.SaveChanges();
        //}

        //public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        //{
        //    var userName = CurrentUserProvider.GetCurrentUser();

        //    if (userName is not null)
        //    {
        //        var user = Users.FirstOrDefault(x => x.AdLogin == userName);

        //        SetEntityes(user);
        //    }

        //    return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        //}

        //private void SetEntityes(User user)
        //{
        //    var modifiedEntities = ChangeTracker.Entries<BaseEntity>()
        //                                        .Where(e => (e.State == EntityState.Modified || e.State == EntityState.Added));

        //    var currentTime = DateTime.UtcNow;

        //    foreach (var entry in modifiedEntities)
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.CreatedDate = currentTime;
        //            entry.Entity.CreatedBy = user.Id;
        //        }

        //        entry.Entity.ModifiedDate = currentTime;
        //    }
        //}
    }
}
