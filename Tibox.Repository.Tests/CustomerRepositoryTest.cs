using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Repository;
using Tibox.Models;
using Tibox.Repository.Northwind;
using Tibox.UnitOfWork;

//namespace Tibox.Repository.Tests
namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        //private readonly IRepository<Customer>  _Repository;
        /// <summary>
        /// CLASE 05/03/2017
        /// </summary>
        //private readonly ICostumerRepository _Repository;

        private readonly IUnitOfWork _UnitOfWork;

        //private readonly ICostumerRepository _ICostumerRepository;
        //public CustomerRepositoryTest(IRepository _Repository)
        //{
        //    this._Repository = _Repository;
        //    //_Repository = new Repository.Repository();
        //}
        public CustomerRepositoryTest()
        {
            //_Repository = new Repository.Repository();
            //_Repository = new BaseRepository<Customer>(); CLASE 26/02/2017
            //_Repository = new CostumerRepository(); // CLASE 05/03/2017
            _UnitOfWork = new TiboxUnitOfWork(); // CLASE 05/03/2017
        }


        [TestMethod]
        public void Get_All_Customers()
        {
            //var result = _Repository.GetAllCustomer();
            //Assert.AreEqual(result.Count() > 0, true);
            //var result = _UnitOfWork.GetAll();
            var result = _UnitOfWork.Customers.GetAll();
            Assert.AreEqual(result.Count() > 0, true);
            /// Count hace referencia del linq
        }

        [TestMethod]
        public void Insert_Customer()
        {
            //var customer = new Customer { FirstName = "Joel", LastName = "Guerreros", City = "Lima", Country = "Perú", Phone = "94477787" };
            //var result = _Repository.InsertCustomer(customer);
            //Assert.AreEqual(result > 0, true);
            var customer = new Customer { FirstName = "Joel", LastName = "Guerreros", City = "Lima", Country = "Perú", Phone = "94477787" };
            //var result = _UnitOfWork.Insert(customer);
            var result = _UnitOfWork.Customers.Insert(customer);

        }

        [TestMethod]
        public void Find_Customer()
        {
            //int id = 93;

            //var customer = _UnitOfWork.GetEntityById(93);
            var customer = _UnitOfWork.Customers.GetEntityById(93);
            Assert.AreEqual(customer != null, true);
        }

        [TestMethod]
        public void Update_Customer()
        {
            var customer = new Customer {
                FirstName = "Joel",
                LastName = "Guerreros",
                City = "Lima",
                Country = "Bolivia",
                Phone = "922222222",
                Id=96};
            //var bResult = _Repository.UpdateCustomer(customer);
            //var bResult = _UnitOfWork.Update(customer);
            var bResult = _UnitOfWork.Customers.Update(customer);
            Assert.AreEqual(bResult, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var customer = new Customer
            {
                FirstName = "Joel",
                LastName = "Guerreros",
                City = "Lima",
                Country = "Bolivia",
                Phone = "922222222",
                Id = 95
            };
            //var bResult = _Repository.DeleteCustomer(customer);
            //var bResult = _UnitOfWork.Delete(customer);
            var bResult = _UnitOfWork.Customers.Delete(customer);
            Assert.AreEqual(bResult, true);
        }


        [TestMethod]
        public void Costumer_By_NamesTest()
        {
            //var result = _UnitOfWork.CostumerSearhByNames("Maria", "Anders");
            var result = _UnitOfWork.Customers.CostumerSearhByNames("Maria", "Anders");
            //Assert.AreEqual(result.Count() > 0, true);
            Assert.AreEqual(result != null, true);
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.FirstName, "Maria");
            Assert.AreEqual(result.LastName, "Anders");
        }

        [TestMethod]
        public void Costumer_With_Orders()
        {
            var costumer = _UnitOfWork.Customers.CustomerWithOrders(1);
            Assert.AreEqual(costumer != null, true);

            Assert.AreEqual(costumer.Orders.Any(), true);
        }


    }
}

