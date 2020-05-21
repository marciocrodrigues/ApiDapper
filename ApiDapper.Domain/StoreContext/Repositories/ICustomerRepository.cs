using ApiDapper.Domain.StoreContext.Entities;

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
    }
}