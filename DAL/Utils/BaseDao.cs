namespace DAL.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    using log4net;

    public abstract class BaseDao
    {
        private readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Exec(string query)
        {
            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                connection.Execute(query);
            }
        }

        public List<T> Exec<T>(string query)
        {
            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                var result = (List<T>)connection.Query<T>(query);

                return (List<T>)Convert.ChangeType(result, typeof(T));
            }
        }

        protected void CatchException(Action func)
        {
            CatchException(() =>
            {
                func();
                return true;
            });
        }

        protected T CatchException<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}
