using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantHMS.BLL.Helper
{
    internal class DbHelper
    {
        private readonly string _connectionString;

        public DbHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<T> ExecuteReaderAsync<T>(string storedProcedure, Action<SqlParameterCollection> addParameters, Func<SqlDataReader, Task<T>> processReader)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    addParameters?.Invoke(cmd.Parameters);
                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        return await processReader(reader);
                    }
                }
            }
        }

        public async Task<DataSet> ExecuteDataSetAsync(string storedProcedure, Action<SqlParameterCollection> addParameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(storedProcedure, conn))
                {
                    try
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        addParameters?.Invoke(cmd.Parameters);
                        await conn.OpenAsync();

                        using (var adapter = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                  
                            adapter.Fill(ds);
                            return ds;
                        }
                    }
                    finally
                    {
                        await conn.CloseAsync();
                    }
                
                }
            }
        }

        public async Task<int> ExecuteNonQueryAsync(string storedProcedure, Action<SqlParameterCollection> addParameters)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(storedProcedure, conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    addParameters?.Invoke(cmd.Parameters);
                    await conn.OpenAsync();
                    return await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
