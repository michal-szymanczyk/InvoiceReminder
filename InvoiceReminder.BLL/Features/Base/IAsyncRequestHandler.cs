using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.BLL.Features.Base
{
    /// <summary>
    /// Base async handler interface for all features actions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRequestHandler<in TRequest, TResult> 
        where TRequest : IRequestModel
        where TResult : IResultModel
    {
        Task<TResult> Handle(TRequest request);
    }
}
