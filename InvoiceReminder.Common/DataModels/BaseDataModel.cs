using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.Common.DataModels
{
    public class BaseDataModel<T>
    {
        public T Id { get; set; }
    }
}
