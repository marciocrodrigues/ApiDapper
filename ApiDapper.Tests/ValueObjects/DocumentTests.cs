using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiDapper.ValueObjects
{
    

    [TestClass]
    public class DocumentTests
    {
        private Document validDocument;
        private Document invalidDocument;
        public DocumentTests()
        {
            validDocument = new Document("36872835850");
            invalidDocument = new Document("12345678910");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentoInNotValid()
        {
            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
