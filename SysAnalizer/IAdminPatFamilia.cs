namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IAdminPatFamilia
    {
        void AsignarPatentes(int idFamilia, List<int> PatentesId);

        void NegarPatentes(int idFamilia, List<int> PatentesId);

        void Show();

        DialogResult ShowDialog();

        Patente ObtenerPatentesSeleccion();
    }
}
