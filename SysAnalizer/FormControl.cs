namespace UI
{
    using BE;

    public class FormControl : IFormControl
    {
        private Usuario UsuarioActivo { get; set; }

        private readonly IABMUsuario aBMUsuario;
        private readonly IVtaProd venta_De_Productos;

        public FormControl(IABMUsuario aBMUsuario)
        {
            this.aBMUsuario = aBMUsuario;
        }

        public void ObtenerFormulario()
        {
            //// Este metodo debe validar las patentes de usuario y familia para devolver el formulario
            aBMUsuario.Show();
        }

        public void GuardarDatosSesionUsuario(Usuario usuario)
        {
            UsuarioActivo = usuario;
        }

        public Usuario ObtenerInfoUsuario()
        {
            return UsuarioActivo;
        }
    }
}
