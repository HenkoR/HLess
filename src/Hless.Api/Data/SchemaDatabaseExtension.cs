﻿using Hless.Common.Repositories;
using Hless.Data.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Api.Data
{
    public class SchemaDatabaseExtension : DatabaseBase, IDatabaseBase, ISchemaDatabaseExtension
    {
        public SchemaDatabaseExtension(string connectrionString) : base(connectrionString)
        {
        }

        public override int ExecuteNonQuery(SqlCommand command)
        {
            command.Connection = connection;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                return command.ExecuteNonQuery();
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public override IEnumerable<Schema> ExecuteReader(SqlCommand command)
        {
            command.Connection = connection;

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            List<Schema> schemas = new List<Schema>();
            try
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        schemas.Add(new Schema
                        {
                            SchemaId = (long)reader["SchemaId"],
                            Name = reader["Name"].ToString(),
                            Definition = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader["Definition"].ToString()),
                            DraftDefinition = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader["DraftDefinition"].ToString()),
                            CreatedBy = reader["CreatedBy"].ToString(),
                        });
                    }
                }

                return (IEnumerable<Schema>)schemas;
            }
            catch
            {
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public override object ExecuteScalar(SqlCommand command)
        {
            command.Connection = connection;

            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                return command.ExecuteScalar();
            }
            catch
            {
                return 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
