namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IABMUsuario
    {
        Form MdiParent { get; set; }

        void Show();

        Usuario ObtenerUsuarioSeleccionado();

        List<Usuario> ObtenerUsuariosBd();
    }
}
