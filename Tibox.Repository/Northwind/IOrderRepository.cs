using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Northwind
{
    public interface IOrderRepository : IRepository<Order>
    {

        Order OrderByOrderNumber(string orderNumber);

        Order OrderWithOrderItems(int orderid);
    }
}
