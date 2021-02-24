using System;
using System.Data.SqlClient;
using SqlQueryBuilderCommon.Helper;
using SqlQueryBuilderCommon.Model;
using SqlQueryBuilderCommon.Static;

namespace SqlQueryBuilderCommon.SqlCon
{
    public sealed class SqlConSingleton
    {
        private static SqlConnection _singletonInstance = new SqlConnection();

        public static SqlConnection GetSqlConnection()
        {
            if (Pathes.ExistsFile(EnvPath.EnvFileName))
            {
                var sqlConStr = new XmlHelper<DbConnectionString>(Pathes.GetEnvPath(EnvPath.EnvFileName)).Read();

                var sqlConnectionBuilder = new SqlConnectionStringBuilder()
                {
                    InitialCatalog = sqlConStr.InitialCatalog,
                    DataSource = sqlConStr.DataSource,
                    UserID = sqlConStr.UserName,
                    Password = sqlConStr.PassWord
                };

                _singletonInstance.ConnectionString = sqlConnectionBuilder.ToString();
                return _singletonInstance;
            }

            throw new Exception("Db設定ファイルが見つかりませんでした。");

        }

        private SqlConSingleton()
        {
            
        }
    }
}