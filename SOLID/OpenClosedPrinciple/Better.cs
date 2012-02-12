using System;
using System.Collections.Generic;
using System.Linq;
using SOLID.SingleResponsibilityPrinciple.BetterExmaple;

namespace SOLID.OpenClosedPrinciple
{
    namespace BetterExmaple
    {
        public class MassPublisher
        {
            public void PublishToAll(Message message)
            {
                IEnumerable<IMessagePublisher> allPublisherTypes = GetAllPublisherTypes();

                foreach (IMessagePublisher messagePublisher in allPublisherTypes)
                {
                    messagePublisher.Publish(message);
                }
            }

            private IEnumerable<IMessagePublisher> GetAllPublisherTypes()
            {
                Type messagePublisherType = typeof (IMessagePublisher);

                return GetType()
                    .Assembly
                    .GetTypes()
                    .Where(messagePublisherType.IsAssignableFrom)
                    .Select(s => Activator.CreateInstance(s) as IMessagePublisher);
            }
        }
    }
}
