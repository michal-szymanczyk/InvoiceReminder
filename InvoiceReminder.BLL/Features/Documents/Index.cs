using AutoMapper;
using InvoiceReminder.BLL.Features.Base;
using InvoiceReminder.Common.DataModels;
using InvoiceReminder.Common.DataModels.Documents;
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
            public IList<DocumentDataModel> Documents { get; set; }
        }

        protected internal class Handler : IAsyncRequestHandler<DocumentsIndexQuery, DocumentsIndexResult>
        {
            private IRepository<DocumentDataModel> _repository;
            private IMapper _autoMapper;

            public Handler(IRepository<DocumentDataModel> repository)
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
