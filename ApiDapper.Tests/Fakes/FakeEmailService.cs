using ApiDapper.Domain.StoreContext.Services;

namespace ApiDapper.Tests.Fakes
{
  public class FakeEmailService : IEmailService
  {
    public void Send(string to, string from, string subject, string body)
    {
      
    }
  }
}