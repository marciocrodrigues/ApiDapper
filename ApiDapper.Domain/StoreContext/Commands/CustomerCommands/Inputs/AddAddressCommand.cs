using System;
using ApiDapper.Domain.StoreContext.Enums;
using ApiDapper.Shared.Commands;
using FluentValidator;

namespace ApiDapper.Domain.StoreContext.CustomerCommands.Inputs
{
  public class AddAddressCommand : Notifiable, ICommand
  {
    public Guid Id { get; set; }
    public string Street { get; set; }
    public string Number { get; set; }
    public string Complement { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string ZipCode { get; set; }
    public EAddressType Type { get; set; }

    public bool Valid()
    {
      return IsValid;
    }
  }
}