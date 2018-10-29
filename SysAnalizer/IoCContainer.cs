namespace UI
{
    using Autofac;
    using BLL;
    using BLL.Imp;
    using DAL.Dao;
    using DAL.Dao.Imp;

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
            ////contBuilder.Register((ctx) => Principal.GetInstancia()).As<IPrincipal>().SingleInstance();
            var contBuilder = new ContainerBuilder();
            contBuilder.RegisterType<Principal>().As<IPrincipal>().SingleInstance();
            contBuilder.RegisterType<UsuarioDAL>().As<IUsuarioDAL>().SingleInstance();
            contBuilder.RegisterType<UsuarioBLL>().As<IUsuarioBLL>().SingleInstance();
            contBuilder.RegisterType<VentaBLL>().As<IVentaBLL>().SingleInstance();
            contBuilder.RegisterType<VentaDAL>().As<IVentaDAL>().SingleInstance();
            contBuilder.RegisterType<DigitoVerificador>().As<IDigitoVerificador>().InstancePerDependency();
            contBuilder.RegisterType<VtaProd>().As<IVtaProd>().SingleInstance();
            contBuilder.RegisterType<ABMusuario>().As<IABMUsuario>().SingleInstance();
            contBuilder.RegisterType<Bitacora>().As<IBitacora>().SingleInstance();
            contBuilder.RegisterType<BitacoraBLL>().As<IBitacoraBLL>().InstancePerDependency();
            contBuilder.RegisterType<BitacoraDAL>().As<IBitacoraDAL>().InstancePerDependency();
            contBuilder.RegisterType<FormControl>().As<IFormControl>().SingleInstance();
            contBuilder.RegisterType<Familias>().As<IFamilias>().SingleInstance();
            contBuilder.RegisterType<FamiliaBLL>().As<IFamiliaBLL>().InstancePerDependency();
            contBuilder.RegisterType<FamiliaDAL>().As<IFamiliaDAL>().InstancePerDependency();
            contBuilder.RegisterType<PatenteBLL>().As<IPatenteBLL>().InstancePerDependency();
            contBuilder.RegisterType<PatenteDAL>().As<IPatenteDAL>().InstancePerDependency();
            return contBuilder.Build();
        }
    }
}
