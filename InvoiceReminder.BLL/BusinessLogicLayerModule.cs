using Autofac;
using InvoiceReminder.BLL.Features.Base;
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
            // register all handlers found in this module:
            builder.RegisterAssemblyTypes(ThisAssembly)
                .AsClosedTypesOf(typeof(IAsyncFeatureHandler<,>))
                .AsImplementedInterfaces();
        }
    }
}
