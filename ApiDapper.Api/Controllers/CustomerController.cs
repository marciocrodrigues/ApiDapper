using System;
using System.Collections.Generic;
using ApiDapper.Domain.StoreContext.CustomerCommands.Inputs;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Queries;
using ApiDapper.Domain.StoreContext.Repositories;
using ApiDapper.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace ApiDapper.Api.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
      private readonly ICustomerRepository _repository;
      public CustomerController(ICustomerRepository repository)
      {
          _repository = repository;
      }

      [HttpGet]
      [Route("")]
      public IEnumerable<ListCustomerQueryResult> Get()
      {
          return _repository.Get();
      }  

      [HttpGet]
      [Route("{id}")]
      public GetCustomerQueryResult GetById(Guid id)
      {
          return _repository.GetById(id);
      }

      [HttpGet]
      [Route("{id}/orders")]
      public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
      {
          return _repository.GetOrders(id);
      }

      [HttpPost]
      [Route("")]
      public Customer Post([FromBody]CreateCustomerCommand customer)
      {
          return null;
      }

      [HttpPut]
      [Route("{id}")]
      public Customer Put(Guid id, [FromBody]CreateCustomerCommand customer)
      {
          return null;
      }

      [HttpDelete]
      [Route("{id}")]
      public object Delete()
      {
          return new { message = "Cliente removido com sucesso" };
      }

    }
}