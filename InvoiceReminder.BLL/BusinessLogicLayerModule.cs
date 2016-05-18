using Autofac;
using AutoMapper;
using InvoiceReminder.BLL.Features.Base;
using InvoiceReminder.BLL.Helpers;
using InvoiceReminder.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.BLL
{
    public class BusinessLogicLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // register automapper to use inside this 
            builder.RegisterInstance<IMapper>(new MapperConfigHelper().CreateMapper());
            
            // register all handlers found in this module:
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IAsyncRequestHandler<,>))
                .AsImplementedInterfaces();

            // register DAL layer:
            builder.RegisterAssemblyModules(typeof(DataAccessLayerModule).Assembly);
        }
    }
}
