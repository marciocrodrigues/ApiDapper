using System;
using ApiDapper.Domain.StoreContext.Enums;
using ApiDapper.Shared.Entities;

namespace ApiDapper.Domain.StoreContext.Entities
{
    public class Delivery : Entity
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate            = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status                = EDeliveryStatus.Waiting;
        }
        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            Status = EDeliveryStatus.Canceled;
        }
    }
}