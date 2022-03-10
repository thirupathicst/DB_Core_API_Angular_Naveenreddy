using DBRepository.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace DBRepository
{
    public class NaveenReddyDbContext : DbContext
    {
        public NaveenReddyDbContext()
        {
        }

        public NaveenReddyDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<PersonalInfo> Tbl_PersonalInfo { get; set; }
        public DbSet<EducationDetails> Tbl_EducationDetails { get; set; }
        public DbSet<AddressDetails> Tbl_AddressDetails { get; set; }
        public DbSet<ReligiousDetails> Tbl_ReligiousDetails { get; set; }
        public DbSet<FamilyDetails> Tbl_FamilyDetails { get; set; }
        public DbSet<LoginDetails> Tbl_LoginDetails { get; set; }
        public DbSet<LoginHistory> Tbl_LoginHistory { get; set; }
        public DbSet<ProfessionalDetails> Tbl_ProfessionalDetails { get; set; }
        public DbSet<Images> Tbl_Images { get; set; }
        public DbSet<Story> Tbl_Story { get; set; }
        public DbSet<PartnerInfo> Tbl_Partner { get; set; }
        public DbSet<Audit> Tbl_Audits { get; set; }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            var temoraryAuditEntities = await AuditNonTemporaryProperties();
            var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            await AuditTemporaryProperties(temoraryAuditEntities);
            return result;
        }


        async Task<IEnumerable<Tuple<EntityEntry, Audit>>> AuditNonTemporaryProperties()
        {
            ChangeTracker.DetectChanges();
            var entitiesToTrack = ChangeTracker.Entries().Where(e => !(e.Entity is Audit) && e.State != EntityState.Detached && e.State != EntityState.Unchanged);

            await Tbl_Audits.AddRangeAsync(
                entitiesToTrack.Where(e => !e.Properties.Any(p => p.IsTemporary)).Select(e => new Audit()
                {
                    TableName = e.Metadata.Name,
                    Action = Enum.GetName(typeof(EntityState), e.State),
                    DateTime = DateTime.Now.ToUniversalTime(),
                    Username = null,
                    KeyValues = JsonSerializer.Serialize(e.Properties.Where(p => p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()),
                    NewValues = JsonSerializer.Serialize(e.Properties.Where(p => e.State == EntityState.Added || e.State == EntityState.Modified).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()),
                    OldValues = JsonSerializer.Serialize(e.Properties.Where(p => e.State == EntityState.Deleted || e.State == EntityState.Modified).ToDictionary(p => p.Metadata.Name, p => p.OriginalValue).NullIfEmpty())
                }).ToList()
            );

            //Return list of pairs of EntityEntry and ToolAudit  
            return entitiesToTrack.Where(e => e.Properties.Any(p => p.IsTemporary))
                 .Select(e => new Tuple<EntityEntry, Audit>(e,
                 new Audit()
                 {
                     TableName = e.Metadata.Name,
                     Action = Enum.GetName(typeof(EntityState), e.State),
                     DateTime = DateTime.Now.ToUniversalTime(),
                     Username = null,
                     NewValues = JsonSerializer.Serialize(e.Properties.Where(p => !p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty())
                 }
                 )).ToList();
        }

        async Task AuditTemporaryProperties(IEnumerable<Tuple<EntityEntry, Audit>> temporatyEntities)
        {
            if (temporatyEntities != null && temporatyEntities.Any())
            {
                await Tbl_Audits.AddRangeAsync(
                temporatyEntities.ForEach(t => t.Item2.KeyValues = JsonSerializer.Serialize(t.Item1.Properties.Where(p => p.Metadata.IsPrimaryKey()).ToDictionary(p => p.Metadata.Name, p => p.CurrentValue).NullIfEmpty()))
                    .Select(t => t.Item2)
                );
                await SaveChangesAsync();
            }
            await Task.CompletedTask;
        }
    }

    public static class Extensions
    {
        public static IDictionary<TKey, TValue> NullIfEmpty<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null || !dictionary.Any())
            {
                return null;
            }
            return dictionary;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (T element in source)
            {
                action(element);
            }
            return source;
        }
    }
}
