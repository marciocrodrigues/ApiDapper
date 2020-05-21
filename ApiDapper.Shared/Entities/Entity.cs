using System;
using FluentValidator;

namespace ApiDapper.Shared.Entities
{
    // Abstract pois ela não vai ser instanciada, só herdada
    public abstract class Entity : Notifiable
    {
    public Entity()
    {
      Id = Guid.NewGuid();
    }

    public Guid Id { get; set; }
    }
}