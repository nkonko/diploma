namespace BLL
{
    using System.Collections.Generic;

    public class Producto : BE.ICRUD<BE.Producto>
    {
        private Producto()
        {
        }

        private static Producto instancia;

        public static Producto Getinstancia()
        {
            if (instancia != null)
            {
                instancia = new Producto();
            }

            return instancia;
        }

        public bool Create(BE.Producto objAlta)
        {
            return DAL.Producto.Getinstancia().Create(objAlta);
        }

        public List<BE.Producto> Retrive()
        {
            return DAL.Producto.Getinstancia().Retrive();
        }

        public bool Delete(BE.Producto objDel)
        {
            return DAL.Producto.Getinstancia().Delete(objDel);
        }

        public bool Update(BE.Producto objUpd)
        {
            return DAL.Producto.Getinstancia().Update(objUpd);
        }
    }
}
