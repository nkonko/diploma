namespace DAL.Modules
{
    using Autofac;

    public class DatabaseModules : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Encriptador>().As<IEncriptador>().InstancePerDependency();
        }
    }
}
