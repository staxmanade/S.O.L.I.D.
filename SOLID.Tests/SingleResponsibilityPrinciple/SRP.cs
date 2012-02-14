using System.Collections.Generic;
using NUnit.Framework;

namespace SOLID.Tests.SingleResponsibilityPrinciple
{
    public class SRP
    {

        /* What do I have to do to add a new publish destination?
         * 
         *  1. Modify the below test
         *  2. Modify the class implementing this.
         */

        [Test]
        public void ModifyMeToPublishToAll_Bad()
        {
            Message msg = new Message {Text = "Hello SRP!"};

            var messagePublisher = new SOLID.SingleResponsibilityPrinciple.BadExample.MessagePublisher();

            messagePublisher.PublishToFacebook(msg);
            messagePublisher.PublishToGooglePlus(msg);
        }
        









































        [Test]
        public void ModifyMeToPublishToAll_Better()
        {
            Message msg = new Message {Text = "Hello SRP!"};

            IEnumerable<SOLID.SingleResponsibilityPrinciple.BetterExmaple.IMessagePublisher> messagePublishers = 
                SOLID.SingleResponsibilityPrinciple.BetterExmaple.MessagePublisherFactory.LoadPublishers();

            foreach (var messagePublisher in messagePublishers)
            {
                //messagePublisher.Publish(msg);
            }
        }
    }
}