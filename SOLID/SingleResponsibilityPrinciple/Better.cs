using System.Collections.Generic;

namespace SOLID.SingleResponsibilityPrinciple
{
    namespace BetterExmaple
    {
        public interface IMessagePublisher
        {
            void Publish(Message message);
        }

        public class MessagePublisherFactory
        {
            public static IEnumerable<IMessagePublisher> LoadPublishers()
            {
                return new IMessagePublisher[]
                           {
                               new FacebookPublisher(),
                               new GooglePlusPublisher(),
                           };
            }
        }

        public class FacebookPublisher : IMessagePublisher
        {
            public void Publish(Message message)
            {
                "message [{0}] was sent to Facebook".Log(message.Text);
            }
        }

        public class GooglePlusPublisher : IMessagePublisher
        {
            public void Publish(Message message)
            {
                "message [{0}] was sent to Google+".Log(message.Text);
            }
        }
    }


}
