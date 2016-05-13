using InvoiceReminder.Common.DataModels;
using InvoiceReminder.Common.DataModels.Documents;
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

        public DbSet<Document> Documents { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<DocumentType> DocCategories { get; set; }
        
    }
}
