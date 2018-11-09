namespace BLL.Imp
{
    using System.Collections.Generic;
    using BE.Entidades;
    using DAL.Dao.Imp;

    public class IdiomaBLL : IIdiomaBLL
    {
        private readonly IIdiomaDAL idiomaDAL;

        public IdiomaBLL(IIdiomaDAL idiomaDAL)
        {
            this.idiomaDAL = idiomaDAL;
        }

        public List<Idioma> ObtenerTodosLosIdiomas()
        {
            return idiomaDAL.ObtenerTodosLosIdiomas();
        }

        public List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idiomaId, string nombreForm)
        {
            return idiomaDAL.ObtenerTraduccionesFormulario(idiomaId, nombreForm);
        }
    }
}
