using BE;

namespace UI
{
    public interface IFormControl
    {
        void ObtenerFormulario();
        void GuardarDatosSesionUsuario(Usuario usuario);
        Usuario ObtenerInfoUsuario();
    }
}