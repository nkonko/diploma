namespace BLL
{
    using BE;
    using DAL;
    using log4net;

    public class BitacoraBLL : IBitacoraBLL
    {
        private readonly IBitacoraDAL bitacoraDAL;

        public BitacoraBLL(IBitacoraDAL bitacoraDAL)
        {
            this.bitacoraDAL = bitacoraDAL;
        }

        public void RegistrarEnBitacora(Usuario usu)
        {
            MDC.Set("iduser", usu.IdUsuario.ToString());

            var digitoVH = bitacoraDAL.GenerarDVH(usu);

            GlobalContext.Properties["dvh"] = digitoVH;
        }
    }
}
