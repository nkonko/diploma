namespace DAL.Imp
{
    using BE;
    using System.Text;

    public class Bitacora
    {
        public Bitacora()
        {
        }

        public void CrearRegistro(BE.Bitacora objAlta)
        {
            var query = string.Format(
                                      "INSERT INTO Bitacora values('{0}', '{1}', '{2}', '{3}','{4}','{5}')",
                                      objAlta.Fecha,
                                      objAlta.IdUsuario,
                                      objAlta.Actividad,
                                      objAlta.InformacionAsociada,
                                      objAlta.Criticidad,
                                      objAlta.DVH);
            ////integrar helper a la base de datos para ejecutar
        }

        public void LeerBitacora(Filtros filtros)
        {
            var query = new StringBuilder();

            var baseQuery = string.Format("SELECT * FROM Bitacora WHERE Fecha >= {0} AND Fecha <= {1} ", filtros.FechaDesde, filtros.FechaHasta);

            query.Append(baseQuery);

            if (filtros.IdsUsuarios.Count > 0)
            {
                query.Append(string.Format("AND IdUsuario IN ({0})", filtros.IdsUsuarios));
            }

            if (filtros.Criticidades.Count > 0)
            {
                query.Append(string.Format("AND Criticidad IN ({0})", filtros.Criticidades));
            }

            ////integrar helper a la base de datos para ejecutar
        }
    }
}
