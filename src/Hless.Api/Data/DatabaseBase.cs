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

        public abstract object ExecuteReader(SqlCommand command);


        public abstract int ExecuteNonQuery(SqlCommand command);

        public abstract object ExecuteScalar(SqlCommand command);

        ~DatabaseBase()
        {
            connection.Close();
            connection.Dispose();
        }
    }
}
