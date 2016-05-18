using Autofac;
using InvoiceReminder.BLL.Features.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static InvoiceReminder.BLL.Features.Documents.Index;

namespace InvoiceReminder.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly Lazy<IAsyncRequestHandler<DocumentsIndexQuery,DocumentsIndexResult>> _indexQueryHandler;

        public DocumentsController(
            Lazy<IAsyncRequestHandler<DocumentsIndexQuery, DocumentsIndexResult>> indexQueryHandler)
        {
            _indexQueryHandler = indexQueryHandler;
        }

        // GET: Documents
        public async Task<ActionResult> Index()
        {
            return View(await _indexQueryHandler.Value.Handle(new DocumentsIndexQuery()));
        }
    }
}