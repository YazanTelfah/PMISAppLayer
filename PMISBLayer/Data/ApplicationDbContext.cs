using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PMISBLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMISBLayer.Data //change Name to Name of my busnis Layer
{
    public class ApplicationDbContext : IdentityDbContext<Person> //identity person
    {
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Engineer> Engineers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Phase> Phases { get; set; }
        public DbSet<PhaseType> PhaseTypes { get; set; }
        public DbSet<ProjectPhase> ProjectPhases { get; set; }
        public DbSet<ProjectStatus> ProjectStatus { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        public DbSet<Deliverable> Deliverables { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<PaymentTerm> PaymentTerms { get; set; }

        public DbSet<InvoicePaymentTerm> InvoicePaymentTerms { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            //builder.Entity<Project>().HasOne(x => x.ProjectStatus)
            //    .WithMany(x => x.Project)
            //    .HasForeignKey(s => s.ProjectStatusId);

            //builder.Entity<Project>().HasOne(x => x.ProjectType)
            //  .WithMany(x => x.Project)
            //  .HasForeignKey(s => s.ProjectTypeId);


            //builder.Entity<Deliverable>().HasOne(x => x.ProjectPhase)
            //  .WithMany(c => c.Deliverable)
            //  .HasForeignKey(s => s.ProjectPhaseId);

            //builder.Entity<PaymentTerm>().HasOne(x => x.Deliverable)
            // .WithMany(c => c.PaymentTerms)
            // .HasForeignKey(s => s.DeliverableId);


            //builder.Entity<ProjectPhase>()
            //    .HasOne(x => x.Project).WithMany(pp => pp.ProjectPhases)
            //    .HasForeignKey(s => s.ProjectId);
            //builder.Entity<ProjectPhase>()
            //    .HasOne(x => x.Phase).WithMany(z => z.ProjectPhases)
            //    .HasForeignKey(s => s.PhaseId);
            //builder.Entity<ProjectPhase>().HasKey(x => x.ProjectPhaseId);



            //builder.Entity<InvoicePaymentTerm>().HasKey(x => new { x.PaymentTermId, x.InvoiceId });

            //builder.Entity<InvoicePaymentTerm>().HasOne(x => x.Invoice)
            //    .WithMany(pp => pp.InvoicePaymentTerms)
            //    .HasForeignKey(s => s.PaymentTermId);

            //builder.Entity<InvoicePaymentTerm>()
            //    .HasOne(x => x.PaymentTerm).WithMany(z => z.InvoicePaymentTerms)
            //    .HasForeignKey(s => s.PaymentTermId);




        }
    }
}


    

