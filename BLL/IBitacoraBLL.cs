namespace BLL
{
    using BE.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IBitacoraBLL
    {
        void RegistrarEnBitacora(Usuario usu);

        Bitacora FiltrarBitacora(DateTime from, DateTime to);

        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, DateTime desde, DateTime hasta);

        List<string> CargarUsuarios();
    }
}