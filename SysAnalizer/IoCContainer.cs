namespace UI
{
    using Autofac;
    using BLL;
    using DAL;
    using DAL.Imp;

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
            contBuilder.RegisterType<Principal>().As<IPrincipal>().SingleInstance();
            ////contBuilder.Register((ctx) => Principal.GetInstancia()).As<IPrincipal>().SingleInstance();
            contBuilder.RegisterType<UsuarioDAL>().As<IUsuarioDAL>().SingleInstance();
            contBuilder.RegisterType<UsuarioBLL>().As<IUsuarioBLL>().SingleInstance();
            contBuilder.RegisterType<DigitoVerificador>().As<IDigitoVerificador>().InstancePerDependency();
            contBuilder.RegisterType<VtaProd>().As<IVtaProd>().SingleInstance();
            contBuilder.RegisterType<ABMusuario>().As<IABMUsuario>().SingleInstance();
            contBuilder.RegisterType<Bitacora>().As<IBitacora>().SingleInstance();
            contBuilder.RegisterType<BitacoraBLL>().As<IBitacoraBLL>().InstancePerDependency();
            contBuilder.RegisterType<BitacoraDAL>().As<IBitacoraDAL>().InstancePerDependency();
            return contBuilder.Build();
        }
    }
}
