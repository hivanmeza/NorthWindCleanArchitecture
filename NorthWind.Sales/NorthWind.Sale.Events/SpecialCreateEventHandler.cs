using NorthWind.Entities.Interfaces;
using NorthWind.Entities.Interfaces.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.Sale.Events
{
    internal class SpecialCreateEventHandler :
        IDomainEventHandler<SpecialOrderCreatedEvent>
    {
        readonly IMailService MailService;

        public SpecialCreateEventHandler(IMailService mailService)
        {
            MailService = mailService;
        }

        public void Handle(SpecialOrderCreatedEvent orderCreated)
        {
            MailService.Send(
                $"Orden {orderCreated.OrderId} con {orderCreated.ProductsCount} productos");
        }
    }
}
