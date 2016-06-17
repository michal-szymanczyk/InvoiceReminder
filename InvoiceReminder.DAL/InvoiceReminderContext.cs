using InvoiceReminder.Common.DataModels;
using InvoiceReminder.Common.DataModels.Documents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.DAL
{

    public class InvoiceReminderContext : DbContext
    {
        public InvoiceReminderContext()
            : base("name=InvoiceReminderContext")
        {
            Database.SetInitializer<InvoiceReminderContext>(null);
#if DEBUG
            Database.Log = Console.Write;
#endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            modelBuilder.Entity<DocumentDataModel>()
                .Map(m =>
                {
                    m.ToTable("Documents");
                })
                .Map<InvoiceDataModel>(m =>
                {
                    //m.MapInheritedProperties();
                    //m.Requires("TypeId").HasValue(2);
                    m.Property(i => i.Id).HasColumnName("DocumentId");
                    m.Properties(i => new { i.TaxRate, i.NetAmount });
                    m.ToTable("Invoices");
                })
                .HasRequired<ReminderDataModel>(t => t.Reminder)
                .WithRequiredDependent()
                .Map(m => m.MapKey("ReminderId"));
        }

        public virtual DbSet<DocumentDataModel> Documents { get; set; }
        public virtual DbSet<DocumentTypeDataModel> DocumentTypes { get; set; }
        public virtual DbSet<InvoiceDataModel> Invoices { get; set; }
        public virtual DbSet<ReminderDataModel> Reminders { get; set; }
    }
}
