using ApiDapper.Domain.StoreContext.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiDapper.Tests
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void SouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Marcio";
            command.LastName = "Costa Rodrigues";
            command.Document = "12345678909";
            command.Email = "teste@teste.com.br";
            command.Phone = "14999999999";

            Assert.AreEqual(true, command.Valid());
        }
        
    }
}