﻿namespace UI
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IFormControl
    {
        Idioma LenguajeSeleccionado { get; set; }

        List<Patente> ObtenerPermisosFormularios();

        List<Patente> ObtenerPermisosFormulario(int formId);

        void GuardarDatosSesionUsuario(Usuario usuario);

        Usuario ObtenerInfoUsuario();

        Usuario ObtenerPermisosUsuario();

        string ObtenerDirectorio();

        IDictionary<string, string> ObtenerTraducciones();

        Idioma ObtenerIdioma();
    }
}