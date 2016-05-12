using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InvoiceReminder.Web
{
    public class IoCConfig
    {

        public static IDependencyResolver CreateResolver()
        {
            var builder = new ContainerBuilder();

            // register controllers:
            builder.RegisterControllers(typeof(IoCConfig).Assembly);
            var container = builder.Build();

            return new AutofacDependencyResolver(container);
        }

    }
}