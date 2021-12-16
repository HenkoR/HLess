using Hless.Common.Repositories;
using Hless.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
                    StringBuilder query = new StringBuilder("insert into [dbo].[Schema] (Name, Definition, DraftDefinition, CreatedBy, CreatedAt, ApplicationId) values (");

                    query.Append("'" + schema.Name.ToString() + "',");

                    if (schema.Definition == null)
                        query.Append("'" + "null',");
                    else
                    {
                        query.Append("'" + JsonConvert.SerializeObject(schema.Definition) + "',");
                    }
                    
                    query.Append("'" + JsonConvert.SerializeObject(schema.DraftDefinition) + "',");

                    //For created by, change to logged in user
                    query.Append("1,");

                    query.Append("'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +"',");
                    //applicationId
                    query.Append(schema.ApplicationId+")");

                    if (schemaDatabaseExtension.ExecuteNonQuery(query.ToString()) == 1)
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
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Schema>> GetSchemasAsync()
        {
            string queryString = "select * from [dbo].[Schema]";

            return Task.FromResult((IEnumerable<Schema>)schemaDatabaseExtension.ExecuteReader(queryString));
        }

        public Task PublishSchemaAsync(long schemaId)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateSchemaAsync(Schema schema)
        {
            throw new System.NotImplementedException();
        }
    }
}
