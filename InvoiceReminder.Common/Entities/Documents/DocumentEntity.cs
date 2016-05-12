using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.Common.Entities.Documents
{
    public class DocumentEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime SubmitedDate { get; set; }
        public string FileHash { get; set; }

        public virtual DocumentTypeEntity Category { get; set; }
        public virtual ReminderEntity Reminder { get; set; }
    }
}
