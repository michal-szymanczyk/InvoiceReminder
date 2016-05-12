using InvoiceReminder.BLL.Features.Base;
using InvoiceReminder.Common.Entities;
using InvoiceReminder.Common.Entities.Documents;
using InvoiceReminder.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static InvoiceReminder.BLL.Features.Documents.GetSpecific;

namespace InvoiceReminder.BLL.Features.Documents
{
    public class Index
    {
        public class DocumentsIndexQuery : IRequestModel { }

        public class DocumentsIndexResult : IResultModel
        {
            public IList<DocumentEntity> Documents { get; set; }
        }

        protected internal class Handler : IAsyncRequestHandler<DocumentsIndexQuery, DocumentsIndexResult>
        {
            private IRepository<DocumentEntity> _repository;

            public Handler(IRepository<DocumentEntity> repository)
            {
                _repository = repository;
            }

            public async Task<DocumentsIndexResult> Handle(DocumentsIndexQuery request)
            {
                return new DocumentsIndexResult {
                    Documents = await _repository.QueryAsync(q => q)
                };
            }
        }
    }
}
