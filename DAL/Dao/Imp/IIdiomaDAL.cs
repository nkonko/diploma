﻿namespace DAL.Dao.Imp
{
    using System.Collections.Generic;
    using BE.Entidades;

    public interface IIdiomaDAL
    {
        List<Idioma> ObtenerTodosLosIdiomas();

        List<TraduccionFormulario> ObtenerTraduccionesFormulario(int idiomaId, string nombreForm);
    }
}