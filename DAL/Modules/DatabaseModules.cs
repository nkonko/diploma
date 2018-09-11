namespace DAL.Modules
{
    using Autofac;

    public class DatabaseModules : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Encriptador>().As<IEncriptador>().InstancePerDependency();
        }
    }
}
