using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tibox.Repository;
using System.Linq;
using Tibox.Models;
using Tibox.UnitOfWork;

namespace Tibox.DataAccess.Tests
{
    [TestClass]
    public class OrderRepositoryTest
    {

        //private readonly IRepository<Order> _Repository;
        private readonly IUnitOfWork _IUnitOfWork;

        public OrderRepositoryTest()
        {
            //_Repository = new BaseRepository<Order>();
            _IUnitOfWork = new TiboxUnitOfWork();
        }




        [TestMethod]
        public void Get_All_Orders()
        {
            var lstOrders = _IUnitOfWork.Orders.GetAll();
            Assert.AreEqual(lstOrders.Count() > 0, true);
        }

        [TestMethod]
        public void Order_By_Number()
        {
            var lstOrder = _IUnitOfWork.Orders.OrderByOrderNumber("542378");
            Assert.AreEqual(lstOrder != null, true);
        }

        [TestMethod]
        public void Order_With_Items()
        {
            var lstOrder = _IUnitOfWork.Orders.OrderWithOrderItems(830);
            Assert.AreEqual(lstOrder != null, true);

            Assert.AreEqual(lstOrder.OrderItems.Any(), true);

        }



    }
}
