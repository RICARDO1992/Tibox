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
        public void Insert_Orders()
        {
            var order = new Order { OrderDate = DateTime.Now,
                    OrderNumber = "543207", CustomerId = 65, TotalAmount = 20 };
            var resulta = _IUnitOfWork.Orders.Insert(order);
        }

        [TestMethod]
        public void Find_Order()
        {
            //int id = 93;

            //var customer = _UnitOfWork.GetEntityById(93);
            var order = _IUnitOfWork.Orders.GetEntityById(830);
            Assert.AreEqual(order != null, true);
        }

        [TestMethod]
        public void Update_Orders()
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderNumber = "543207",
                CustomerId = 65,
                TotalAmount = 90,
                Id = 832
            };
            //var bResult = _Repository.UpdateCustomer(customer);
            //var bResult = _UnitOfWork.Update(customer);
            //var bResult = _UnitOfWork.Order.Update(order);
            var bResult = _IUnitOfWork.Orders.Update(order);
            Assert.AreEqual(bResult, true);
        }

        [TestMethod]
        public void Delete_Customer()
        {
            var order = new Order
            {
                OrderDate = DateTime.Now,
                OrderNumber = "543207",
                CustomerId = 65,
                TotalAmount = 20,
                Id = 832
            };
            //var bResult = _Repository.DeleteCustomer(customer);
            //var bResult = _UnitOfWork.Delete(customer);
            //var bResult = _UnitOfWork.Orders.Delete(customer);
            var bresulta = _IUnitOfWork.Orders.Delete(order);
            Assert.AreEqual(bresulta, true);
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
