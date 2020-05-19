using System;
using ApiDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using ApiDapper.Domain.StoreContext.CustomerCommands.Inputs;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.ValueObjects;
using ApiDapper.Shared.Commands;
using FluentValidator;

namespace ApiDapper.Domain.StoreContext.Handlers
{
  public class CustomerHandler : 
    Notifiable, 
    ICommandHandler<CreateCustomerCommand>,
    ICommandHandler<AddAddressCommand>
  {
    public ICommandResult Handle(CreateCustomerCommand command)
    {
      // Verificar se o CPF já existe na base

      // Verificar se o E-mail já existe na base
      
      // Criar os VOs
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document);
      var email = new Email(command.Email);
      
      // Criar a entidade
      var customer = new Customer(name, document, email, command.Phone);

      // Validar entidade e VOs
      AddNotifications(name.Notifications);
      AddNotifications(document.Notifications);
      AddNotifications(email.Notifications);
      AddNotifications(customer.Notifications);

      // Persistir o cliente
      
      // Enviar um E-mail de boas vindas
      
      // Retornar o resultado para tela
      
      return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
    }

    public ICommandResult Handle(AddAddressCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}