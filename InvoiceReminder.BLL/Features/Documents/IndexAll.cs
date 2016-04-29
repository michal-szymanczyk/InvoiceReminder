using InvoiceReminder.BLL.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvoiceReminder.BLL.Features.Documents.Index;

namespace InvoiceReminder.BLL.Features.Documents
{
    public class IndexAll
    {
        public class DocumentsIndexAllQuery : IRequestModel { }

        public class DocumentsIndexAllResult : IResultModel
        {
            public IList<DocumentsIndexResult> Documents { get; set; }
        }

        protected class Handler : IAsyncFeatureHandler<DocumentsIndexAllQuery, DocumentsIndexAllResult>
        {
            public Task<DocumentsIndexAllResult> Handle(DocumentsIndexAllQuery request)
            {
                throw new NotImplementedException();
            }
        }
    }
}
