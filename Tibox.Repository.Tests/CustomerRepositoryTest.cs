using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Tibox.Repository;
using Tibox.Models;

//namespace Tibox.Repository.Tests
namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        private readonly IRepository<Customer>  _Repository;

        //public CustomerRepositoryTest(IRepository _Repository)
        //{
        //    this._Repository = _Repository;
        //    //_Repository = new Repository.Repository();
        //}
        public CustomerRepositoryTest()
        {
            //_Repository = new Repository.Repository();
            _Repository = new BaseRepository<Customer>();
        }

        [TestMethod]
        public void Get_All_Customers()
        {
            //var result = _Repository.GetAllCustomer();
            //Assert.AreEqual(result.Count() > 0, true);
            var result = _Repository.GetAll();
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
            var result = _Repository.Insert(customer);

        }

        [TestMethod]
        public void Find_Customer()
        {
            //int id = 93;

            var customer = _Repository.GetEntityById(93);
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
                Id=95};
            //var bResult = _Repository.UpdateCustomer(customer);
            var bResult = _Repository.Update(customer);
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
            var bResult = _Repository.Delete(customer);
            Assert.AreEqual(bResult, true);
        }



    }
}
