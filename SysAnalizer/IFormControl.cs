namespace UI
{
    using BE.Entidades;

    public interface IFormControl
    {
        void ObtenerFormulario();

        void GuardarDatosSesionUsuario(Usuario usuario);

        Usuario ObtenerInfoUsuario();
    }
}