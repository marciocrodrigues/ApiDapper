using System;
using ApiDapper.Shared.Commands;

namespace ApiDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
  // Classe para receber o retorno do Handle criado
  public class CreateCustomerCommandResult : ICommandResult
  {
    public CreateCustomerCommandResult(bool success, string message, object data)
    {
      this.Success = success;
      this.Message = message;
      this.Data = data;

    }
    public bool Success { get; set; }
    public string Message { get; set; }
    public object Data { get; set; }
  }
}