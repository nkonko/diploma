namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IAdminPatFamilia
    {
        void AsignarPatentes(int familiaId, List<int> patentesId);

        void NegarPatentes(int familiaId, List<int> patentesId);

        void Show();

        DialogResult ShowDialog();

        Patente ObtenerPatentesSeleccion();
    }
}
