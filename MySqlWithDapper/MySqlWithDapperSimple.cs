using System.Collections.Generic;
using Dapper;
using MySql.Data.MySqlClient;

namespace MySqlWithDapper
{
    public struct MySqlWithDapperHanlder
    {
        private static string _mysqlCon = $"DataBase='todorelease';Data Source='localhost';User Id='root';Password='';charset='utf8';pooling=true";

        public static void SetMySqlConnectionString(string mysqlCon)
        {
            _mysqlCon = mysqlCon;
        }
        public static MySqlConnection OpenMySqlConnection()
        {
            var connection = new MySqlConnection(_mysqlCon);
            connection.Open();
            SimpleCRUD.SetDialect(SimpleCRUD.Dialect.MySQL);
            return connection;
        }

        public static bool InsertWithEntity<T>(T entity)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.Insert(entity) > 0;
            }
        }

        public static T GetSingle<T>(int id)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.Get<T>(id);
            }
        }

        public static IEnumerable<T> GetList<T>()
        {
            using (var con = OpenMySqlConnection())
            {
                return con.GetList<T>();
            }
        }

        public static IEnumerable<T> GetListWithCondition<T>(string conditions)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.GetList<T>(conditions);
            }
        }

        public static IEnumerable<T> GetListWithEntity<T>(object entity)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.GetList<T>(entity);
            }
        }

        public static bool DeleteSingle<T>(int id)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.Delete<T>(id) > 0;
            }
        }

        public static bool DeleteListWithCondition<T>(string conditions)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.DeleteList<T>(conditions) > 0;
            }
        }
        public static bool DeleteListWithEntity<T>(object entity)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.DeleteList<T>(entity) > 0;
            }
        }

        public static bool UpdateSingle<T>(T entity)
        {
            using (var con = OpenMySqlConnection())
            {
                return con.Update(entity) > 0;
            }
        }
    }
}