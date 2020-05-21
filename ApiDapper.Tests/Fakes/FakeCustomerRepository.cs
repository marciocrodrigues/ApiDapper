using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Repositories;

namespace ApiDapper.Tests.Fakes
{
  public class FakeCustomerRepository : ICustomerRepository
  {
    public bool CheckDocument(string document)
    {
      return false;
    }

    public bool CheckEmail(string email)
    {
      return false;
    }

    public void Save(Customer customer)
    {
        
    }
  }
}