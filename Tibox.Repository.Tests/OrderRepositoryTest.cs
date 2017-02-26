using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Repository;
using System.Linq;
using Tibox.Models;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {

        private readonly IRepository<Order> _Repository;

        public OrderRepositoryTest()
        {
            _Repository = new BaseRepository<Order>();
        }




        [TestMethod]
        public void Get_All_Orders()
        {
            var lstOrders = _Repository.GetAll();
            Assert.AreEqual(lstOrders.Count() > 0, true);
        }



    }
}
