namespace DAL.Dao.Imp
{
    using System.Collections.Generic;

    public class DigitoVerificador : IDigitoVerificador
    {
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
    }
}
