namespace BLL
{
    using BE.Entidades;
    using DAL.Dao;
    using EasyEncryption;
    using log4net;
    using System;
    using System.Collections.Generic;

    public class BitacoraBLL : IBitacoraBLL
    {
        private const string Key = "bZr2URKx";
        private const string Iv = "HNtgQw0w";
        private readonly IBitacoraDAL bitacoraDAL;

        public BitacoraBLL(IBitacoraDAL bitacoraDAL)
        {
            this.bitacoraDAL = bitacoraDAL;
        }

        public List<string> CargarUsuarios()
        {
            return bitacoraDAL.CargarUsuarios();
        }

        public Bitacora FiltrarBitacora(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public List<Bitacora> LeerBitacoraPorUsuarioCriticidadYFecha(List<string> usuarios, List<string> criticidades, DateTime desde, DateTime hasta)
        {
            return bitacoraDAL.LeerBitacoraPorUsuarioCriticidadYFecha(usuarios, criticidades, desde, hasta);
        }

        public void RegistrarEnBitacora(Usuario usu)
        {
            if (usu.Email != null)
            {
                MDC.Set("usuario", DES.Decrypt(usu.Email, Key, Iv));
            }
            else
            {
                MDC.Set("usuario", "Sistema");
            }

            var digitoVH = bitacoraDAL.GenerarDVH(usu);

            GlobalContext.Properties["dvh"] = digitoVH;
        }
    }
}
