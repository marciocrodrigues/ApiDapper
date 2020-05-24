using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Queries;
using ApiDapper.Domain.StoreContext.Repositories;
using ApiDapper.Infra.DataContexts;
using Dapper;

namespace ApiDapper.Infra.StoreContext.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    private readonly ApiDapperDataContext _context;
    public CustomerRepository(ApiDapperDataContext context)
    {
        _context = context;
    }

    public bool CheckDocument(string document)
    {
      return _context
        .Connection
        .Query<bool>(
            "spCheckDocument",
            new { Document = document },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }

    public bool CheckEmail(string email)
    {
      return _context
        .Connection
        .Query<bool>(
            "spCheckEmail",
            new { Email = email },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }

    public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
    {
      return _context
        .Connection
        .Query<CustomerOrdersCountResult>(
            "spGetCustomerOrdersCount",
            new { Document = document },
            commandType: CommandType.StoredProcedure)
        .FirstOrDefault();
    }

    public IEnumerable<ListCustomerQueryResult> Get()
    {
      return _context
        .Connection
        .Query<ListCustomerQueryResult>(
          @"SELECT [Id], 
                  CONCAT([FirstName], ' ', [LastName]) AS Name, 
                  [Document], [Email] 
            FROM [Customer]",
          new { },
          commandType: CommandType.Text
        ).ToList();
    }

    public void Save(Customer customer)
    {
      _context.Connection.Execute("spCreateCustomer",
      new 
      {
          Id = customer.Id,
          FirstName = customer.Name.FirstName,
          LastName = customer.Name.LastName,
          Document = customer.Document.Number,
          Email = customer.Email.Address,
          Phone = customer.Phone,
      }, commandType: CommandType.StoredProcedure);

      foreach (var address in customer.Address)
      {
          _context.Connection.Execute("spCreateAddress",
          new
          {
             Id = address.Id,
             CustomerId = customer.Id,
             Number = address.Number,
             Complement = address.Complement,
             District = address.District,
             City = address.City,
             State = address.State,
             Country = address.Country,
             ZipCode = address.ZipCode,
             Type = address.Type,           
          }, commandType: CommandType.StoredProcedure);
      }
    }

    public GetCustomerQueryResult GetById(Guid id)
    {
      return _context
        .Connection
        .Query<GetCustomerQueryResult>(
          @"SELECT [Id], 
                   CONCAT([FirstName], ' ', [LastName]) AS Name, 
                   [Document], 
                   [Email] 
            FROM [Customer]
            WHERE [Id] = @Id",
          new { Id = id },
          commandType: CommandType.Text
        ).FirstOrDefault();
    }

    public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id)
    {
      return _context
        .Connection
        .Query<ListCustomerOrdersQueryResult>(@"SELECT Customer.Id,
                                                       CONCAT(FirstName, ' ', LastName) AS Name,
                                                       Document,
                                                       Email,
                                                       [Order].Id AS Number,
                                                       OrderItem.Price
                                                FROM Customer
                                                     INNER JOIN [Order] ON [Order].[CustomerId] = [Customer].[Id]
                                                     INNER JOIN OrderItem ON OrderItem.OrderId = [Order].Id
                                                WHERE Customer.Id = @Id",
        new {Id = id},
        commandType: CommandType.Text);
    }
  }
}