using System.Collections.Generic;
using System.Linq;
using ApiDapper.Domain.StoreContext.ValueObjects;

namespace ApiDapper.Domain.StoreContext.Entities
{
    public class Customer
    {
        private readonly IList<Address> _address;

        public Customer(Name name,
                        Document document,
                        Email email,
                        string phone)
        {
            Name      = name;
            Document  = document;
            Email     = email;
            Phone     = phone;
            _address   = new List<Address>();
        }
        
        public Name Name {get; private set;}
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address => _address.ToArray();

        public void AddAddress(Address address)
        {
            // Validar o endereço
            // Adicionar o endereço
            _address.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
        
    }
}