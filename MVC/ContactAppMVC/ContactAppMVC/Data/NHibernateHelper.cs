using ContactAppMVC.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace ContactAppMVC.Data
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactor = null;

        public static ISession CreateSession()
        {
            if (_sessionFactor == null)
            {
                _sessionFactor = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2012.ConnectionString("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ContactDb;Integrated Security=True;Connect Timeout=30;Encrypt=False"))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())
                    .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                    .BuildSessionFactory();
            }
            return _sessionFactor.OpenSession();
        }
    }
}