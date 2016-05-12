using InvoiceReminder.Common.Entities;
using InvoiceReminder.Common.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.DAL
{
    class DatabaseContext : DbContext
    {

        public DbSet<DocumentEntity> Documents { get; set; }
        public DbSet<ReminderEntity> Reminders { get; set; }
        public DbSet<DocumentTypeEntity> DocCategories { get; set; }
        
    }
}
