using Autofac;
using SampleApp.API.Application.Queries;
using SampleApp.Domain.AggregatesModel.InventoryAggregate;
using SampleApp.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApp.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new InventoryQueries(QueriesConnectionString))
               .As<IInventoryQueries>()
               .InstancePerLifetimeScope();

            builder.RegisterType<InventoryRepository>()
                .As<IInventoryRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
