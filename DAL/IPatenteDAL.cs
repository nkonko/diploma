namespace DAL.Imp
{
    using System.Collections.Generic;
    using BE;

    public interface IPatenteDAL
    {
        bool Actualizar(Patente objUpd);

        bool Borrar(Patente objDel);

        List<Patente> Cargar();

        bool Crear(Patente objAlta);
    }
}