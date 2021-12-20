using Hless.Common.Repositories;
using Hless.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Hless.Api.Data
{
    public class SchemaRepository : ISchemaRepository
    {
        private ISchemaDatabaseExtension schemaDatabaseExtension;

        public SchemaRepository(ISchemaDatabaseExtension schemaDatabaseExtension)
        {
            this.schemaDatabaseExtension = schemaDatabaseExtension;
        }

        public Task<Schema> CreateSchemaAsync(Schema schema)
        {
            return Task.Run(() =>
            {
                try
                {
                    string query = "insert into [dbo].[Schema] (Name, Definition, DraftDefinition, CreatedBy, CreatedAt, ApplicationId) values " +  
                    "(@Name, @Definition, @DraftDefinition, @CreatedBy, @CreatedAt, @ApplicationId)";

                    SqlCommand command = new SqlCommand(query);

                    command.Parameters.AddWithValue("@Name", schema.Name);

                    if (schema.Definition == null)
                        command.Parameters.AddWithValue("@Definition", "null");
                    else
                        command.Parameters.AddWithValue("Definition", JsonConvert.SerializeObject(schema.Definition));

                    command.Parameters.AddWithValue("@DraftDefinition", JsonConvert.SerializeObject(schema.DraftDefinition));

                    //For created by, change to logged in user
                    command.Parameters.AddWithValue("@CreatedBy", "1");

                    command.Parameters.AddWithValue("@CreatedAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    //applicationId
                    command.Parameters.AddWithValue("@ApplicationId", schema.ApplicationId.ToString());

                    if (schemaDatabaseExtension.ExecuteNonQuery(command) == 1)
                        return schema;
                    else
                        return null;
                }
                catch
                {
                    return null;
                }
            });
        }

        public Task<Schema> GetSchemaAsync(long schemaId)
        {
            return Task.Run(() =>
            {
                try
                {
                    string query = "select * from [dbo].[Schema] where SchemaId = @SchemaId";
                    SqlCommand command = new SqlCommand(query);

                    command.Parameters.AddWithValue("@SchemaId", schemaId.ToString());

                    List<Schema> result = (List<Schema>)schemaDatabaseExtension.ExecuteReader(command);

                    if (result != null)
                        return result[0];
                    else
                        return null;
                }
                catch
                {
                    return null;
                }
            });
        }

        public Task<IEnumerable<Schema>> GetSchemasAsync()
        {
            string queryString = "select * from [dbo].[Schema]";
            SqlCommand query = new SqlCommand(queryString);

            return Task.FromResult((IEnumerable<Schema>)schemaDatabaseExtension.ExecuteReader(query));
        }

        public Task PublishSchemaAsync(long schemaId)
        {
            return Task.Run(async () => {
                Schema schema = await GetSchemaAsync(schemaId);

                if (schema == null)
                    return -1;

                string queryString = "update [dbo].[Schema] " +
                "set Definition = @Definition, LastModified = @LastModified, FirstPublished = @FirstPublished, LastPublished = @LastPublished " +
                "where SchemaId = @SchemaId";
                SqlCommand cmd = new SqlCommand(queryString);


                cmd.Parameters.AddWithValue("@Definition", JsonConvert.SerializeObject(schema.DraftDefinition));
                cmd.Parameters.AddWithValue("@LastModified", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                if(schema.FirstPublished == null)
                    cmd.Parameters.AddWithValue("@FirstPublished", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                else
                    cmd.Parameters.AddWithValue("@FirstPublished", schema.FirstPublished);

                cmd.Parameters.AddWithValue("@LastPublished", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@SchemaId", schemaId);

                return schemaDatabaseExtension.ExecuteNonQuery(cmd);
            });
        }

        public Task UpdateSchemaAsync(Schema schema)
        {
            return Task.Run(() => {

            });
        }
    }
}
