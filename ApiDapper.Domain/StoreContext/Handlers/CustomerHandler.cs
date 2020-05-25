using System;
using ApiDapper.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using ApiDapper.Domain.StoreContext.CustomerCommands.Inputs;
using ApiDapper.Domain.StoreContext.Entities;
using ApiDapper.Domain.StoreContext.Repositories;
using ApiDapper.Domain.StoreContext.Services;
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
    private readonly ICustomerRepository _repository;
    private readonly IEmailService _emailService;
    public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
    {
      _repository   = repository;
      _emailService = emailService;
    }
    public ICommandResult Handle(CreateCustomerCommand command)
    {
      // Verificar se o CPF já existe na base
      if(_repository.CheckDocument(command.Document))
        AddNotification("Document", "Este CPF já está em uso");
      
      // Verificar se o E-mail já existe na base
      if(_repository.CheckEmail(command.Email))
        AddNotification("Email", "Este E-mail já está em uso");
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

      if(Invalid)
        return new CommandResult(
          false,
          "Não foi possivel inserir novo cliente",
          Notifications
        );

      // Persistir o cliente
      _repository.Save(customer);

      // Enviar um E-mail de boas vindas, implementar com algum serviço de envio
      //_emailService.Send(email.Address, "hello@teste.com.br", "Bem vindo", "Seja bem vindo");
      
      // Retornar o resultado para tela
      return new CommandResult(true, "Bem vindo", new { Id = customer.Id, Name = name, Email = email.Address });
    }

    public ICommandResult HandleUpdate(Guid id, CreateCustomerCommand command)
    {
      var name = new Name(command.FirstName, command.LastName);
      var document = new Document(command.Document);
      var email = new Email(command.Email);

      var customer = new Customer(name, document, email, command.Phone);

      if(Invalid)
        return new CommandResult(
          false,
          "Não foi possivel alterar o cliente",
          Notifications
        );

      _repository.Update(id, customer);
      return new CommandResult(
        true, 
        "Alterado com sucesso", 
        new { 
          Id = customer.Id, 
          Name = name, 
          Document = document,
          Email = email.Address, 
          Phone = customer.Phone 
        }
      );
    }

    public ICommandResult HandleDelete(Guid id)
    {
      _repository.Delete(id);
      var result = _repository.GetById(id);

      if(result != null)
        return new CommandResult(
          false,
          "Erro ao tentar remover cliente.",
          new { Id = id }
        );
      
      return new CommandResult(
        true,
        "Cliente removido com sucesso",
        new { Id = id }
      );

    }

    public ICommandResult Handle(AddAddressCommand command)
    {
      throw new System.NotImplementedException();
    }
  }
}