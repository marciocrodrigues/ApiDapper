using System;
using ApiDapper.Shared.Commands;

namespace ApiDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
  // Classe para receber o retorno do Handle criado
  public class CreateCustomerCommandResult : ICommandResult
  {
    
    public CreateCustomerCommandResult(){}
    
    // Overload do construtor
    public CreateCustomerCommandResult(Guid id, string name, string email)
    {
      this.Id = id;
      this.Name = name;
      this.Email = email;

    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
  }
}