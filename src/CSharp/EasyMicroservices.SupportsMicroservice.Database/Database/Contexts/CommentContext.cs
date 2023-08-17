using EasyMicroservices.SupportsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.SupportsMicroservice.Database.Contexts
{
    public class SupportContext : RelationalCoreContext
    {
        IDatabaseBuilder _builder;
        public SupportContext(IDatabaseBuilder builder)
        {
            _builder = builder;
        }

        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TicketHistoryEntity> TicketHistory { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_builder != null)
                _builder.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TicketEntity>(model =>
            {
                model.HasKey(x => x.Id);
            });
            modelBuilder.Entity<TicketHistoryEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(x => x.TicketEntity)
                .WithMany(x => x.TicketHistory)
                .HasForeignKey(x => x.TicketId);
            });
            modelBuilder.Entity<DepartmentEntity>(model =>
            {
                model.HasKey(x => x.Id);
            });
        }
    }
}