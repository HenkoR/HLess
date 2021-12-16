using System.Data.SqlClient;

namespace Hless.Api.Data
{
    public interface IDatabaseBase
    {
        public object ExecuteReader(string query);
        public int ExecuteNonQuery(string query);
        public object ExecuteScalar(string query);

    }
}
