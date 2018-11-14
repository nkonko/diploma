namespace BLL
{
    using System;
    using System.Collections.Generic;
    using BE.Entidades;
    using DAL.Dao;
    using log4net;

    public class BitacoraBLL : IBitacoraBLL
    {
        private readonly IBitacoraDAL bitacoraDAL;

        public BitacoraBLL(IBitacoraDAL bitacoraDAL)
        {
            this.bitacoraDAL = bitacoraDAL;
        }

        public Bitacora FiltrarBitacora(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<int> usuariosId, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            return bitacoraDAL.LeerBitacoraPorUsuarioCriticidadYFecha(usuariosId, criticidades, desde, hasta);
        }

        public void RegistrarEnBitacora(Usuario usu)
        {
            MDC.Set("iduser", usu.UsuarioId.ToString());

            var digitoVH = bitacoraDAL.GenerarDVH(usu);

            GlobalContext.Properties["dvh"] = digitoVH;
        }
    }
}
