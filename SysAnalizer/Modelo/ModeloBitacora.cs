namespace UI.Modelo
{
    using System;
    using System.Data;

    public class ModeloBitacora : IModeloBitacora
    {
        public string Usuario { get; set; }

        public DateTime Fecha { get; set; }

        public string Criticidad { get; set; }

        public string Funcionalidad { get; set; }

        public string Descripcion { get; set; }

        public DataSet ListadoBitacora { get; set; } = new DataSet();
    }

    public interface IModeloBitacora
    {
        DataSet ListadoBitacora { get; set; }
    }
}
