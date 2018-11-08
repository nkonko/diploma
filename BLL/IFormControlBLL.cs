namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFormControlBLL
    {
        List<Patente> ObtenerPermisosFormularios();

        List<Patente> ObtenerPermisosFormulario(int formId);
    }
}