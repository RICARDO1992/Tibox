using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Northwind
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public Order OrderByOrderNumber(string orderNumber)
        {
            using (var conecta = new SqlConnection(_connectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@OrderNumber", orderNumber);

                return conecta.QueryFirst<Order>("dbo.OrderByOrderNumber", parametro, commandType: System.Data.CommandType.StoredProcedure);
            }    
        }

        public Order OrderWithOrderItems(int orderid)
        {
            using (var conecta = new SqlConnection(_connectionString))
            {
                var parametro = new DynamicParameters();
                parametro.Add("@OrderId", orderid);

                using (var multipleConsulta = conecta.QueryMultiple("dbo.OrderWithOrderItems", parametro, commandType: System.Data.CommandType.StoredProcedure))
                {
                    var resultadoSet = multipleConsulta.Read<Order>().Single();
                    resultadoSet.OrderItems = multipleConsulta.Read<OrderItem>();
                    return resultadoSet;
                }
                
            }
        }
    }
}
