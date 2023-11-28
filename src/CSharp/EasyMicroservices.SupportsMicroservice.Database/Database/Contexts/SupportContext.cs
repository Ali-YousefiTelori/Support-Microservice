using EasyMicroservices.SupportsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;

namespace EasyMicroservices.SupportsMicroservice.Database.Contexts
{
    public class SupportContext : RelationalCoreContext
    {
        IEntityFrameworkCoreDatabaseBuilder _builder;
        public SupportContext(IEntityFrameworkCoreDatabaseBuilder builder) : base(builder)
        {
        }

        public DbSet<DepartmentEntity> Departmants { get; set; }
        public DbSet<TicketAssignEntity> TicketAssigns { get; set; }
        public DbSet<TicketDepartmentEntity> TicketDepartments { get; set; }
        public DbSet<TicketEntity> Tickets { get; set; }
        public DbSet<TicketHistoryEntity> TicketHistories { get; set; }
        public DbSet<TicketSupportTimeHistoryEntity> TicketSupportTimeHistories { get; set; }
        public DbSet<TicketDiscussionEntity> TicketDiscussions { get; set; }


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

                model.HasOne(x => x.Ticket)
                .WithMany(x => x.TicketHistories)
                .HasForeignKey(x => x.TicketId);
            });
            modelBuilder.Entity<DepartmentEntity>(model =>
            {
                model.HasKey(x => x.Id);
            });
            modelBuilder.Entity<TicketDepartmentEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(bc => bc.Ticket)
                .WithMany(b => b.TicketDepartments)
                .HasForeignKey(bc => bc.TicketId);

                model.HasOne(bc => bc.Department)
                .WithMany(b => b.TicketDepartments)
                .HasForeignKey(bc => bc.DepartmentId);


            });
            modelBuilder.Entity<TicketSupportTimeHistoryEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(bc => bc.Ticket)
                .WithMany(b => b.TicketSupportTimeHistories)
                .HasForeignKey(bc => bc.TicketId);
            });
            modelBuilder.Entity<TicketAssignEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(bc => bc.Ticket)
                .WithMany(b => b.TicketAssigns)
                .HasForeignKey(bc => bc.TicketId);

            });
            modelBuilder.Entity<TicketDiscussionEntity>(model =>
            {
                model.HasKey(x => x.Id);

                model.HasOne(bc => bc.Ticket)
                .WithMany(b => b.TicketDiscussions)
                .HasForeignKey(bc => bc.TicketId);
            });
        }
    }
}