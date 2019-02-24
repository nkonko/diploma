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
            contBuilder.RegisterType<FormControlBLL>().As<IFormControlBLL>().SingleInstance();
            contBuilder.RegisterType<FormControlDAL>().As<IFormControlDAL>().SingleInstance();
            contBuilder.RegisterType<DigitoVerificador>().As<IDigitoVerificador>().InstancePerDependency();
            contBuilder.RegisterType<DetalleVentaUI>().As<IDetalleVenta>().SingleInstance();
            contBuilder.RegisterType<ABMusuario>().As<IABMUsuario>().SingleInstance();
            contBuilder.RegisterType<BitacoraUI>().As<IBitacoraUI>().SingleInstance();
            contBuilder.RegisterType<BitacoraBLL>().As<IBitacoraBLL>().InstancePerDependency();
            contBuilder.RegisterType<BitacoraDAL>().As<IBitacoraDAL>().InstancePerDependency();
            contBuilder.RegisterType<FormControl>().As<IFormControl>().SingleInstance();
            contBuilder.RegisterType<Familias>().As<IFamilias>().SingleInstance();
            contBuilder.RegisterType<FamiliaBLL>().As<IFamiliaBLL>().InstancePerDependency();
            contBuilder.RegisterType<FamiliaDAL>().As<IFamiliaDAL>().InstancePerDependency();
            contBuilder.RegisterType<PatenteBLL>().As<IPatenteBLL>().InstancePerDependency();
            contBuilder.RegisterType<PatenteDAL>().As<IPatenteDAL>().InstancePerDependency();
            contBuilder.RegisterType<ProductoBLL>().As<IProductoBLL>().SingleInstance();
            contBuilder.RegisterType<ProductoDAL>().As<IProductoDAL>().SingleInstance();
            contBuilder.RegisterType<Productos>().As<IProductos>().SingleInstance();
            contBuilder.RegisterType<AdminPatFamilia>().As<IAdminPatFamilia>().SingleInstance();
            contBuilder.RegisterType<DatosUsuario>().As<IDatosUsuario>().SingleInstance();
            contBuilder.RegisterType<Clientes>().As<IClientes>().SingleInstance();
            contBuilder.RegisterType<ClienteBLL>().As<IClienteBLL>().SingleInstance();
            contBuilder.RegisterType<ClienteDAL>().As<IClienteDAL>().SingleInstance();
            contBuilder.RegisterType<BackupUI>().As<IBackupUI>().SingleInstance();
            contBuilder.RegisterType<RestoreUI>().As<IRestoreUI>().SingleInstance();
            contBuilder.RegisterType<IdiomaBLL>().As<IIdiomaBLL>().SingleInstance();
            contBuilder.RegisterType<IdiomaDAL>().As<IIdiomaDAL>().SingleInstance();
            contBuilder.RegisterType<DigitoVerificador>().As<IDigitoVerificador>().SingleInstance();
            contBuilder.RegisterType<BloqueoProductos>().As<IBloqueoProductos>().SingleInstance();
            contBuilder.RegisterType<BloqueoUsuario>().As<IBloqueoUsuario>().SingleInstance();
            contBuilder.RegisterType<AdminFamUsuario>().As<IAdminFam>().SingleInstance();
            contBuilder.RegisterType<AdminPatUsuario>().As<IAdminPat>().SingleInstance();
            contBuilder.RegisterType<NegarPatUsuario>().As<INegarPat>().SingleInstance();
            contBuilder.RegisterType<DetalleVentaDAL>().As<IDetalleVentaDAL>().SingleInstance();
            contBuilder.RegisterType<DetalleVentaBLL>().As<IDetalleVentaBLL>().SingleInstance();
            contBuilder.RegisterType<Traductor>().As<ITraductor>().SingleInstance();
            contBuilder.RegisterType<VentaUI>().As<IVentaUI>().SingleInstance();
            contBuilder.RegisterType<DetalleRefForm>().As<IDetalleRefForm>().SingleInstance();
            return contBuilder.Build();
        }
    }
}
