namespace BLL.Imp
{
    using BE.Entidades;
    using DAL.Dao;
    using System.Collections.Generic;

    public class FormControlBLL : IFormControlBLL
    {
        private readonly IFormControlDAL formControlDAL;

        public FormControlBLL(IFormControlDAL formControlDAL)
        {
            this.formControlDAL = formControlDAL;
        }

        public List<Patente> ObtenerPermisosFormulario(int formId)
        {
            return formControlDAL.ObtenerPermisosFormulario(formId);
        }

        public List<Patente> ObtenerPermisosFormularios()
        {
            return formControlDAL.ObtenerPermisosFormularios();
        }
    }
}
