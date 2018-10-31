﻿namespace DAL.Utils
{
    using Dapper;
    using log4net;
    using System;
    using System.Collections.Generic;

    public abstract class BaseDao
    {
        private readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool Exec(string query)
        {
            using (var connection = SqlUtils.Connection())
            {
                connection.Open();
                connection.Execute(query);
                return true;
            }
        }

        public List<T> Exec<T>(string query, object param = null)
        {
            using (var connection = SqlUtils.Connection())
            {
                connection.Open();

                var result = param == null ? (List<T>)connection.Query<T>(query) : (List<T>)connection.Query<T>(query, param);

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
