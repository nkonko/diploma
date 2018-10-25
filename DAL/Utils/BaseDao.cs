namespace DAL.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    using log4net;

    public abstract class BaseDao
    {
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool Exec(string query)
        {
            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                connection.Execute(query);
                return true;
            }
        }

        public List<T> Exec<T>(string query)
        {
            using (IDbConnection connection = SqlUtils.Connection())
            {
                connection.Open();
                var result = (List<T>)connection.Query<T>(query);

                return result;
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
                log.Error(ex);
                throw;
            }
        }
    }
}
