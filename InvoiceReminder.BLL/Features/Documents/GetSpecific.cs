using InvoiceReminder.BLL.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvoiceReminder.BLL.Features.Documents.Index;

namespace InvoiceReminder.BLL.Features.Documents
{
    public class GetSpecific
    {
        public class DocumentsGetSpecificQuery : IRequestModel
        {
            public int Id { get; set; }
        }

        public class DocumentsGetSpecificResult : IResultModel
        {
            public string Name { get; set; }
            public DateTime SubmitedDate { get; set; }
            public double NetAmount { get; set; }
            public short TaxRate { get; set; }
            public string CategoryName { get; set; }
            public string ReminderName { get; set; }
        }

        protected class Handler : IAsyncRequestHandler<DocumentsGetSpecificQuery, DocumentsGetSpecificResult>
        {
            public Task<DocumentsGetSpecificResult> Handle(DocumentsGetSpecificQuery request)
            {
                throw new NotImplementedException();
            }
        }
    }
}
