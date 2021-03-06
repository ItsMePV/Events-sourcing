﻿using System;
using System.Threading.Tasks;
using eCommerce.Messages;
using NServiceBus;

namespace eCommerce.Planner
{
    public class PlanOrderHandler : IHandleMessages<PlanOrderCommand>
    {
        //DO the planning work inside the handling
        public async Task Handle(PlanOrderCommand message, IMessageHandlerContext context)
        {
            Console.WriteLine($"OrderId {message.OrderId} planned");
            //DO e.g : eCommerce.Planner microservice stores the order in its own data store, and supply a web interface for the planner to work with.
            //Sent back to the Saga where the PlannedOrder message came from
            await context.Reply<IOrderPlannedMessage>(messageConstructor: msg => { })
                /*
                  When the planning is done, we use reply method on the context object with an IOrderPlannedMessage, 
                  which will send it to the saga where the planned order message came from. IOrderPlanMessage doesn't 
                  have any properties It is just used to signal the saga it's done. The saga has all the data about the 
                  order anyway, so only if new data was introduced by the planning process, it has to be sent back to the saga
                 */
                // prevent the passing in of the controls thread context into the new
                // thread, which we don't need for sending a message
                .ConfigureAwait(continueOnCapturedContext: false);
        }
    }
}
