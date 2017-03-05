using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Northwind
{
    public class CostumerRepository : BaseRepository<Customer>, ICostumerRepository
    {
        public Customer CostumerSearhByNames(string firstName, string lastName)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@FISTNAME", firstName);
                parametros.Add("@LASTNAME", lastName);

                return connection.QueryFirst<Customer>("dbo.CustomerSearchByNames", 
                    parametros,
                    commandType: System.Data.CommandType.StoredProcedure);
            }
        }

        public Customer CustomerWithOrders(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var parametros = new DynamicParameters();
                parametros.Add("@customerId", id);

                using (var multipleresultset =
                    connection.QueryMultiple("dbo.CustomerWithOrders",
                    parametros, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var CostumerResult = multipleresultset.Read<Customer>().Single();
                    CostumerResult.Orders = multipleresultset.Read<Order>();
                    return CostumerResult;
                }
            }
        }
    }
}
