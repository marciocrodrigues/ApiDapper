using System;
using System.Collections.Generic;
using ApiDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using ApiDapper.Domain.StoreContext.CustomerCommands.Inputs;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Handlers;
using ApiDapper.Domain.StoreContext.Queries;
using ApiDapper.Domain.StoreContext.Repositories;
using ApiDapper.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace ApiDapper.Api.Controllers
{
    public class CustomerController : Controller
    {
      private readonly ICustomerRepository _repository;
      private readonly CustomerHandler _handler;
      public CustomerController(ICustomerRepository repository,
                                CustomerHandler handler)
      {
          _repository = repository;
          _handler = handler;
      }

      [HttpGet]
      [Route("v1/customers")]
      [ResponseCache(Duration = 30)]
      public IEnumerable<ListCustomerQueryResult> Get()
      {
          return _repository.Get();
      }  

      [HttpGet]
      [Route("v1/customers/{id}")]
      public GetCustomerQueryResult GetById(Guid id)
      {
          return _repository.GetById(id);
      }

      [HttpGet]
      [Route("v1/customers/{id}/orders")]
      public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
      {
          return _repository.GetOrders(id);
      }

      [HttpPost]
      [Route("v1/customers")]
      public ICommandResult Post([FromBody]CreateCustomerCommand customer)
      {
          var result = (CommandResult)_handler.Handle(customer);
          return result;
      }

      [HttpPut]
      [Route("v1/customers/{id}")]
      public ICommandResult Put(Guid id, [FromBody]CreateCustomerCommand customer)
      {
          var result = (CommandResult)_handler.HandleUpdate(id, customer);
          return result;
      }

      [HttpDelete]
      [Route("v1/customers/{id}")]
      public ICommandResult Delete(Guid id)
      {
          return _handler.HandleDelete(id);
      }

    }
}