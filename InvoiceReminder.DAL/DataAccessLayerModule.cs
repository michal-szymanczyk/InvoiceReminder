using Autofac;
using InvoiceReminder.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.DAL
{
    public class DataAccessLayerModule : Module
    {
        private static SqlProviderServices instance = SqlProviderServices.Instance;

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(InvoiceReminderContext))
                .As(typeof(DbContext));

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency(); // it could be per "IOperationUnitScope"
        }
    }
}
