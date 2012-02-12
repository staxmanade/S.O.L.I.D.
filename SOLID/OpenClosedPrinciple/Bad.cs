using SOLID.SingleResponsibilityPrinciple.BadExample;

namespace SOLID.OpenClosedPrinciple
{
    namespace BadExample
    {
        public class MassPublisher
        {
            public void PublishToAll(Message message)
            {
                MessagePublisher messagePublisher = new SingleResponsibilityPrinciple.BadExample.MessagePublisher();

                messagePublisher.PublishToFacebook(message);

                messagePublisher.PublishToGooglePlus(message);

                messagePublisher.PublishToTwitter(message);

                // Notice you have to modify this every time it has to support a new PublishTo***
            }
        }
    }
}
