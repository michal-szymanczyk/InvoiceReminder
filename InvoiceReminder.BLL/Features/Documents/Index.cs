using InvoiceReminder.BLL.Features.Base;
using InvoiceReminder.Common.Entities;
using InvoiceReminder.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.BLL.Features.Documents
{
    public class Index
    {
        public class DocumentsIndexQuery : IRequestModel
        {
            public int Id { get; set; }
        }

        public class DocumentsIndexResult : IResultModel
        {
            public string Name { get; set; }
            public DateTime SubmitedDate { get; set; }
            public CostTpe CostType { get; set; }
            public double NetAmount { get; set; }
            public short TaxRate { get; set; }
            public string CategoryName { get; set; }
            public string ReminderName { get; set; }
        }

        protected internal class Handler : IAsyncFeatureHandler<DocumentsIndexQuery, DocumentsIndexResult>
        {
            private IRepository<DocumentEntity> _repository;

            public Handler(IRepository<DocumentEntity> repository)
            {
                _repository = repository;
            }

            public async Task<DocumentsIndexResult> Handle(DocumentsIndexQuery request)
            {
                return new DocumentsIndexResult { Name = "test" };// await _repository.GetByIdAsync(request.Id);
            }
        }
    }
}
