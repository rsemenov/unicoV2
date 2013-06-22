using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Unico.Data.Interfaces;

namespace Unico.Configuration
{
    public class UnicoConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            var sessionFactory = GetSessionFactory();

            builder.RegisterInstance<ISessionFactory>(sessionFactory);
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>))
                .WithProperty("SessionFactory", sessionFactory).InstancePerDependency();

            builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static ISessionFactory GetSessionFactory()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
               .Database(MsSqlConfiguration.MsSql2008
                             .ConnectionString(c => c.FromConnectionStringWithKey("UnicoDbConnection"))
                             .ShowSql())
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<IEntity>())
               .ExposeConfiguration((config) => { new SchemaUpdate(config); })
               .BuildSessionFactory();
            return sessionFactory;
        }
    }
}