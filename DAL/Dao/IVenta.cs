namespace DAL.Dao
{
    using BE.Entidades;
    using System.Collections.Generic;

    public interface IVentaDAL
    {
        bool Actualizar(Venta objUpd);

        bool Borrar(Venta objDel);

        List<Venta> Cargar();

        bool Crear(Venta objAlta);
    }
}