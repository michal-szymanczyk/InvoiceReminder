using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.Common.DataModels.Documents
{
    /// <summary>
    /// Invoice type document
    /// </summary>
    public class InvoiceDataModel : DocumentDataModel
    {
        public double NetAmount { get; set; }
        public short TaxRate { get; set; }
    }
}
