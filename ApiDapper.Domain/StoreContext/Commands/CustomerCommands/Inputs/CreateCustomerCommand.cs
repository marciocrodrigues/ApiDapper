using ApiDapper.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace ApiDapper.Domain.StoreContext.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public string Document { get; set; }
      public string Email { get; set; }
      public string Phone { get; set; }

      // Não é feito a validação no construtor para não ocorrer erro ao receber o json do front
      // Assim após receber o json, chama-se o metodo para fazer a validação
      public bool Valid()
      {
        AddNotifications(new ValidationContract()
          .Requires()
          .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter pelo menos 2 caracteres")
          .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter no máximo 40 caracteres")
          .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
          .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter no máximo 40 caracteres")
          .IsEmail(Email, "Email", "O E-mail é inválido")
          .HasLen(Document, 11, "Document", "CPF inválido")
        );

        return IsValid;
      }

       // Se o usuário existe no banc (Email)
       // Se o usuário existe no banco (CPF)
    }
}