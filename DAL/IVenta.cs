namespace DAL
{
    using System.Collections.Generic;
    using BE;

    public interface IVentaDAL
    {
        bool Actualizar(Venta objUpd);

        bool Borrar(Venta objDel);

        List<Venta> Cargar();

        bool Crear(Venta objAlta);
    }
}