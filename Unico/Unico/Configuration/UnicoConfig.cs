using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Autofac;
using Autofac.Integration.Mvc;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using Unico.Data.Interfaces;
using Unico.Infrastructure;
using Unico.Modules;
using Unico.Modules.RequestFilters;
using AutoMapper;
using Unico.Data.Entities;
using Unico.Models;
using Unico.Email;

namespace Unico.Configuration
{
    public class UnicoConfig
    {
        public static void Config()
        {
            var builder = new ContainerBuilder();

            var sessionFactory = GetSessionFactory();

            NHibernateSessionModule.InitSessionFactory(sessionFactory, GetRequestFilter());
            
            builder.RegisterInstance<ISessionFactory>(sessionFactory).SingleInstance();
            builder.Register(x => x.Resolve<ISessionFactory>().OpenSession()).InstancePerHttpRequest();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).PropertiesAutowired();
            builder.RegisterType(typeof(EmailGenerator)).As(typeof(IEmailGenerator)).PropertiesAutowired();
            builder.RegisterType(typeof(EmailSender)).As(typeof(IEmailSender)).PropertiesAutowired();

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
               .CurrentSessionContext<WebSessionContext>()
               .BuildSessionFactory();
            return sessionFactory;
        }

        private static IRequestFilter GetRequestFilter()
        {
            return new ServiceRequestFilter(new[] { ".*/Content/.*", ".*/Scripts/.*", ".*/Images/.*" });
        }

        public static void ConfigureAutoMapper()
        {
            Mapper.CreateMap<Order, OrderModel>();
            Mapper.CreateMap<ProductOrder, OrderItemModel>();
            Mapper.CreateMap<Product, ProductModel>();
            Mapper.CreateMap<OcpProduct, OcpProductModel>();
        }
    }
}