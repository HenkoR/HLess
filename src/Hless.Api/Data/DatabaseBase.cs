using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Hless.Api.Data
{
    public abstract class DatabaseBase : IDatabaseBase
    {
        protected readonly string connectionString;
        protected SqlConnection connection;

        public DatabaseBase(string connectrionString)
        {
            this.connectionString = connectrionString;
            connection = new SqlConnection(connectrionString);
        }

        public abstract object ExecuteReader(string query);


        public abstract int ExecuteNonQuery(string query);

        public abstract object ExecuteScalar(string query);

        ~DatabaseBase()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
