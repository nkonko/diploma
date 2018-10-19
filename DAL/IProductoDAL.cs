namespace DAL
{
    using System.Collections.Generic;
    using BE;

    public interface IProductoDAL
    {
        bool Actualizar(Producto objUpd);

        bool Borrar(Producto objDel);

        List<Producto> Cargar();

        bool Crear(Producto objAlta);
    }
}