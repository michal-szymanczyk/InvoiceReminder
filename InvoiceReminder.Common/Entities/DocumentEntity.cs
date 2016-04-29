using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.Common.Entities
{
    public enum CostTpe
    {
        Unknown = 0, // not determined yet
        NotBillable = 1, // standard cost
        Billable = 2, // business cost
    }

    public class DocumentEntity : BaseEntity
    {
        public string Name { get; set; }
        public DateTime SubmitedDate { get; set; }
        public string FileHash { get; set; }
        public CostTpe CostType { get; set; }
        public double NetAmount { get; set; }
        public short TaxRate { get; set; }

        public virtual DocCategoryEntity Category { get; set; }
        public virtual ReminderEntity Reminder { get; set; }
    }
}
