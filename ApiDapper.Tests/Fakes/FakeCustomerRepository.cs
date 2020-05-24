using System;
using System.Collections.Generic;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Queries;
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

    public IEnumerable<ListCustomerQueryResult> Get()
    {
      throw new System.NotImplementedException();
    }

    public GetCustomerQueryResult GetById(Guid id)
    {
      throw new NotImplementedException();
    }

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
      throw new NotImplementedException();
    }

    public void Save(Customer customer)
    {
        
    }
  }
}