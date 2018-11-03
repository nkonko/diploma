namespace BLL
{
    using BE.Entidades;
    using System;

    public interface IBitacoraBLL
    {
        void RegistrarEnBitacora(Usuario usu);

        Bitacora FiltrarBitacora(DateTime from, DateTime to);
    }
}