using System.Collections.Generic;
using ApiDapper.Domain.StoreContext.ValueObjects;

namespace ApiDapper.Domain.StoreContext.Entities
{
    public class Customer
    {
        public Customer(Name name,
                        Document document,
                        Email email,
                        string phone)
        {
            Name      = name;
            Document  = document;
            Email     = email;
            Phone     = phone;
            Address   = new List<Address>();
        }
        
        public Name Name {get; private set;}
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Address { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
        
    }
}