namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

        public void logIn()
        {

        }


        public bool Create(BE.Producto ObjAlta)
        {
            return DAL.Producto.Getinstancia().Create(ObjAlta);
        }

        public List<BE.Producto> Retrive()
        {
            return DAL.Producto.Getinstancia().Retrive();
        }

        public bool Delete(BE.Producto ObjDel)
        {
            return DAL.Producto.Getinstancia().Delete(ObjDel);
        }

        public bool Update(BE.Producto ObjUpd)
        {
            return DAL.Producto.Getinstancia().Update(ObjUpd);
        }
    }
}
