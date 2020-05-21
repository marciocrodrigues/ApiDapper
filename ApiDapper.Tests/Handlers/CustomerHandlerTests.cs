using ApiDapper.Domain.StoreContext.CustomerCommands.Inputs;
using ApiDapper.Domain.StoreContext.Handlers;
using ApiDapper.Tests.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiDapper.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Marcio";
            command.LastName = "Costa Rodrigues";
            command.Document = "12345678909";
            command.Email = "teste@teste.com.br";
            command.Phone = "14999999999";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}