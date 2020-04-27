using FluentValidator;
using FluentValidator.Validation;

namespace ApiDapper.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O E-mail é invalido")
            );
        }
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}