namespace ApiDapper.Domain.StoreContext.ValueObjects
{
    public class Email
    {
        public Email(string address)
        {
            Address = address;
        }
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}