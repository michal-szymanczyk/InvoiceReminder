using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.Common.DataModels
{
    public class ReminderDataModel : BaseDataModel<short>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan ReminderInterval { get; set; }
    }
}
