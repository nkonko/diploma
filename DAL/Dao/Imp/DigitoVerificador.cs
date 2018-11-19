namespace DAL.Dao.Imp
{
    using DAL.Utils;
    using System.Collections.Generic;

    public class DigitoVerificador : BaseDao, IDigitoVerificador
    {
        public List<string> Entidades { get; set; } = SqlUtils.Tables;

        public int CalcularDVHorizontal(List<string> columnasString, List<int> columnasInt)
        {
            var colLenght = new List<int>();
            var digito = 0;
            colLenght = columnasInt;

            foreach (var col in columnasString)
            {
                colLenght.Add(col.Length);
            }

            foreach (var colL in colLenght)
            {
                digito += colL * colLenght.FindIndex(x => x == colL);
            }

            return digito;
        }

        public int CalcularDVVertical(string entidad)
        {
            var queryString = string.Format("SELECT SUM(DVH) FROM {0}", entidad);

            return CatchException(() =>
            {
                return Exec<int>(queryString)[0];
            });
        }

        public void InsertarDVVertical(string entidad)
        {
            var digito = CalcularDVVertical(entidad);

            var queryString = "INSERT INTO DigitoVerificadorVertical(Entidad, ValorDigitoVerificador) VALUES(@entidad, @digito)";

            CatchException(() =>
            {
                Exec(queryString, new { @entidad = entidad, @digito = digito });
            });
        }

        public void ActualizarDVVertical(string entidad)
        {
            var digito = CalcularDVVertical(entidad);

            var queryString = "UPDATE DigitoVerificadorVertical SET ValorDigitoVerificador = @digito WHERE Entidad = @entidad";

            CatchException(() =>
            {
                Exec(queryString, new { @entidad = entidad, @digito = digito });
            });
        }

        public bool ComprobarPrimerDigito(string entidad)
        {
            var queryString = "SELECT ValorDigitoVerificador FROM DigitoVerificadorVertical WHERE Entidad = @entidad";
            var digito = new List<int>();
            CatchException(() =>
            {
                digito = Exec<int>(queryString, new { @entidad = entidad });
            });

            if (digito.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Dictionary<string, int> ConsultarDVVertical(string entidades)
        {
            var entidadesdic = new Dictionary<string, int>();

            //foreach (var entidad in entidades)
            //{
                var queryString = string.Format("SELECT ValorDigitoVerificador FROM DigitoVerificadorVertical WHERE Entidad = '{0}'", entidades);

                CatchException(() =>
                {
                    entidadesdic.Add(entidades, Exec<int>(queryString)[0]);
                });
            //}
            return entidadesdic;
        }

        public bool ComprobarIntegridad()
        {
            var returnValue = true;

            var ResultadoUsuario = CalcularDVVertical(Entidades.Find(x => x == "Usuario"));

            var dVVerticalUsuario = ConsultarDVVertical(Entidades.Find(x => x == "Usuario"));

            if (ResultadoUsuario != dVVerticalUsuario["Usuario"])
            {
                returnValue = false;
            }

            return returnValue;
        }
    }
}
