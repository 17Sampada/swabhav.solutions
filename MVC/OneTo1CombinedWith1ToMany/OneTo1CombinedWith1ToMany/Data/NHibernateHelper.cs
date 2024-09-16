﻿
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using OneTo1CombinedWith1ToMany.Mappings;

namespace OneTo1CombinedWith1ToMany.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactor = null;

        public static ISession CreateSession()
        {
            if (_sessionFactor == null)
            {
                _sessionFactor = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookDb;Integrated Security=True;Connect Timeout=30;Encrypt=False"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuthorMap>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                    .BuildSessionFactory();
            }
            return _sessionFactor.OpenSession();
        }
    }
}