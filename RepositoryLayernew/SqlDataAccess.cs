﻿
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace RepositoryLayer
{
    public class SqlDataAccess : ISqlDataAccess
    {

        private readonly IConfiguration _config;
        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }
        //public static string GetConnectionString(string connectionName = "MVCDemoDB")
        //{
        //    return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        //}

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {    //this code for web api
            string connectionString = _config.GetConnectionString(connectionStringName);

            using IDbConnection connection = new SqlConnection(connectionString);

            var rows = await connection.QueryAsync<T>(storedProcedure,
                parameters,
                commandType: CommandType.StoredProcedure);

            return rows.ToList();

            //using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            //{
            //    return await cnn.QueryAsync<T>(storedProcedure,
            //    parameters,
            //    commandType: CommandType.StoredProcedure);


            //}


        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectionString = _config.GetConnectionString(connectionStringName);

            using IDbConnection connection = new SqlConnection(connectionString);

            await connection.ExecuteAsync(storedProcedure,
               parameters,
               commandType: CommandType.StoredProcedure);

            //using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            //{
            //   // return cnn.Execute(sql, data);
            //    await cnn.ExecuteAsync(storedProcedure,
            //   parameters,
            //   commandType: CommandType.StoredProcedure);
            //}
        }
    }
}
