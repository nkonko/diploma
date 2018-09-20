namespace DAL.Modules
{
    using Autofac;
    using System.Data.Common;
    using System.Data.SqlClient;

    public class DatabaseModules : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Encriptador>().As<IEncriptador>().InstancePerDependency();
            builder.RegisterType<SqlConnection>().As<DbConnection>()
                .WithParameter("ConnectionString", ConnectionString)
                .InstancePerDependency();
        }
    }
}
