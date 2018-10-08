namespace UI
{
    using Autofac;
    using BLL;
    using DAL;

    public static class IoCContainer
    {
        private static IContainer container;

        static IoCContainer()
        {
            container = CreateContainer();
        }

        public static T Resolve<T>()
        {
            return container.Resolve<T>();
        }

        private static IContainer CreateContainer()
        {
            var contBuilder = new ContainerBuilder();
            contBuilder.Register((ctx) => Principal.GetInstancia()).As<IPrincipal>().SingleInstance();
            contBuilder.RegisterType<UsuarioDAL>().As<IUsuarioDAL>().SingleInstance();
            contBuilder.RegisterType<UsuarioBLL>().As<IUsuarioBLL>().SingleInstance();
            return contBuilder.Build();
        }
    }
}
