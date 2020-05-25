using System;
using System.Collections.Generic;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Queries;

namespace ApiDapper.Domain.StoreContext.Repositories
{
    // Sempre usar interface, pois se mudar o acesso ao banco
    // Dapper para EF ou Mongo etc.. só mudar na classe que
    // executar a query
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult GetById(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
        void Update(Guid id, Customer customer);
        void Delete(Guid id);
    }
}