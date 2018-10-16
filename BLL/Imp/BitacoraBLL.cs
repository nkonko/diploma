namespace BLL
{
    using BE;
    using DAL;
    using log4net;
    using System.Collections.Generic;

    public class BitacoraBLL
    {
        private readonly IBitacoraDAL bitacoraDAL;

        public BitacoraBLL(IBitacoraDAL bitacoraDAL)
        {
            this.bitacoraDAL = bitacoraDAL;
        }

        public void RegistrarEnBitacora(Usuario usu)
        {
            MDC.Set("idusuario", usu.IdUsuario.ToString());

            var digitoVH = bitacoraDAL.GenerarDVH(usu);

            GlobalContext.Properties["DVH"] = digitoVH;
        }
    }
}
