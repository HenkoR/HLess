using System.Collections.Generic;
using System.Data.SqlClient;

namespace Hless.Api.Data
{
    public interface IDatabaseBase
    {
        public object ExecuteReader(SqlCommand command);
        public int ExecuteNonQuery(SqlCommand command);
        public object ExecuteScalar(SqlCommand command);

    }
}
