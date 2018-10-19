namespace BLL
{
    using System.Collections.Generic;
    using BE;

    public interface IVentaBLL
    {
        bool Actualizar(Venta objUpd);

        bool Borrar(Venta objDel);

        List<Venta> Cargar();

        bool Crear(Venta objAlta);
    }
}