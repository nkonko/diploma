namespace BLL
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IIdiomaBLL
    {
        List<Idioma> ObtenerTodosLosIdiomas();

        List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idiomaId, string nombreForm);
    }
}
