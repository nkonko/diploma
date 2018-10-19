using System.Collections.Generic;
using BE;

namespace DAL.Imp
{
    public interface IPatenteDAL
    {
        bool Actualizar(Patente objUpd);
        bool Borrar(Patente objDel);
        List<Patente> Cargar();
        bool Crear(Patente objAlta);
    }
}