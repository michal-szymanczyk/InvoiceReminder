using AutoMapper;
using InvoiceReminder.Common.DataModels;
using InvoiceReminder.Common.DataModels.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.BLL.Helpers
{
    class MapperConfigHelper
    {
        public IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg => {
                //cfg.CreateMap<DAL.Document, DocumentDataModel>();
                //cfg.CreateMap<DAL.Invoice, InvoiceDataModel>();
                //cfg.CreateMap<DAL.DocumentType, DocumentTypeDataModel>();
                //cfg.CreateMap<DAL.Reminder, ReminderDataModel>();
            });
            return config.CreateMapper();
        }
    }
}
