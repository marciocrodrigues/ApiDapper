using System.Linq;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Enums;
using ApiDapper.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiDapper.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _teclado;
        private Product _monitor;
        private Product _memoria;
        private Customer _customer;
        private Order _order;

        public OrderTests()
        {
            var name = new Name("Marcio", "Costa Rodrigues");
            var document = new Document("36872835850");
            var email = new Email("marciodeath@hotmail.com");
            _customer = new Customer(name, document, email, "14996365289");
            _order = new Order(_customer);

            _mouse = new Product("Mouse", "Mouse", "", 20M, 10);
            _teclado = new Product("Teclado", "Teclado", "", 50M, 10);
            _monitor = new Product("Monitor", "Monitor", "", 500M, 10);
            _memoria = new Product("Memoria", "Memoria", "", 300M, 10);
        }

        // Consigo criar um novo pedido
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // Ao adicionar um novo item, a quantidade de itens deve mudar
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoItens()
        {
            _order.AddItem(_mouse, 5);
            _order.AddItem(_teclado, 5);

            Assert.AreEqual(2, _order.Items.Count);
        }

        // Ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenPurshasedFiveItens()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(5, _mouse.QuantityOnHand);
        }

        // Ao confirmar pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreEqual(false, string.IsNullOrEmpty(_order.Number));
        }

        // Ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Dados 10 produtos deve haver duas entregas
        [TestMethod]
        public void ShouldTwoShippingsWhenPurshasedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // Ao cancelar o pedido, o status dever ser CANCELADO
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // Ao cancelar o pedido, deve cancelar as entregas
        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {   
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.AddItem(_mouse, 5);
            _order.Ship();
            _order.Cancel();
            
            foreach (var item in _order.Deliveries)
            {
                Assert.AreEqual(EDeliveryStatus.Canceled, item.Status);
            }

        }
    }
}