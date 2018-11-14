namespace DAL.Dao
{
    using BE;
    using BE.Entidades;
    using System;
    using System.Collections.Generic;

    public interface IBitacoraDAL
    {
        void FiltrarBitacora(FiltrosBitacora filtros);

        Bitacora LeerBitacoraConId(int bitacoraId);

        int GenerarDVH(Usuario usu);

        int ObtenerUltimoIdBitacora();

        List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<int> usuariosId, List<string> criticidades, DateTime desde, DateTime hasta);
    }
}
