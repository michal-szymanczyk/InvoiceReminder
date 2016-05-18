using Autofac;
using InvoiceReminder.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceReminder.DAL
{
    public class DataAccessLayerModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(DatabaseContext)).AsSelf();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerDependency(); // it could be per "IOperationUnitScope"
        }
    }
}
