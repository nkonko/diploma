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
            var queryString = "SELECT SUM(DVH) FROM @entidad";

            return CatchException(() =>
            {
                return Exec<int>(queryString, new { @entidad = entidad })[0];
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

            var queryString = "UPDATE DigitoVerificadorVertical SET ValorDigitoVerificador = @digito WHERE @entidad = entidad";

            CatchException(() =>
            {
                Exec(queryString, new { @entidad = entidad, @digito = digito });
            });
        }







    }
}
