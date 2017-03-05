using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tibox.Models;

namespace Tibox.Repository.Northwind
{
    public interface ICostumerRepository: IRepository<Customer>
    {

        Customer CostumerSearhByNames(string firstName, string lastName);

        Customer CustomerWithOrders(int id);

    }

    ///open close:  abierto para extensiones y cerrado para modificaiones
}
