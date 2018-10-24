namespace DAL.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Dapper;

    public abstract class BaseDao
    {
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
    }
}
