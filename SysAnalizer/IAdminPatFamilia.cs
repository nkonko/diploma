namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public interface IAdminPatFamilia
    {
        bool FamiliaNueva { get; set; }

        void AsignarPatente(int familiaId, int patenteId);

        void BorrarPatente(int familiaId, int patenteId);

        void Show();

        DialogResult ShowDialog();
    }
}
