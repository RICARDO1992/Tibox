using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Repository;

namespace Tibox.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {

        protected readonly string _connectionString;

        public BaseRepository()
        {
            _connectionString = ConfigurationManager.
            ConnectionStrings["NorthwindConnectionString"].ConnectionString;
        }


        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                //return connection.Delete<T>(entity);
                return connection.Delete(entity);
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.GetAll<T>();
            }
        }

        public T GetEntityById(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Get<T>(id);
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return (int)connection.Insert<T>(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Update(entity);
            }
        }
    }
}
