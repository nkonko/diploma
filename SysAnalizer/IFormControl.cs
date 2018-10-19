namespace UI
{
    using BE;

    public interface IFormControl
    {
        void ObtenerFormulario();

        void GuardarDatosSesionUsuario(Usuario usuario);

        Usuario ObtenerInfoUsuario();
    }
}