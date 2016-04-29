using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.Common.Infrastructure
{
    /// <summary>
    /// Action scope for data access (etc.) to use with ControllerAction/View/ViewModel/Service/etc. - can be treated as one session/db tranaction/etc.
    /// </summary>
    public interface IOperationUnitScope : IDisposable
    {
    }
}
