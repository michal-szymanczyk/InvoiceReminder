using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.Common.Entities.Documents
{
    /// <summary>
    /// Invoice type document - it's table-per-hierarchy inheritance, so it's stored in one DB table
    /// </summary>
    public class InvoiceEntity : DocumentEntity
    {
        public double Invoice_NetAmount { get; set; }
        public short Invoice_TaxRate { get; set; }
    }
}
