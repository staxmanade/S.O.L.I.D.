using System;
using SOLID.LiskovSubstitutionPrinciple.BadExample;

namespace SOLID.LiskovSubstitutionPrinciple
{
    namespace BadExample
    {
        public class TwitterPublisher : TheBasePublisher
        {
            public override Message CreateASomewhatLongMessage(string message)
            {
                if (message.Length > 140)
                    throw new Exception("Twitter can't handle a really long message. Too bad, so sad.");

                return new Message {Text = message};
            }
        }

        public class FaceBookPublisher : TheBasePublisher
        {
            public override Message CreateASomewhatLongMessage(string message)
            {
                return new Message {Text = message};
            }
        }
    }

    public abstract class TheBasePublisher
    {
        public abstract Message CreateASomewhatLongMessage(string message);
    }


    public class MessagePublisher
    {
        public void Publish(string messageFromUserInput)
        {
            TheBasePublisher[] publishers = new TheBasePublisher[]
                                                {
                                                    new FaceBookPublisher(), 
                                                    new TwitterPublisher(), 
                                                };

            foreach (TheBasePublisher publisher in publishers)
            {
                Message aSomewhatLongMessage = publisher.CreateASomewhatLongMessage(messageFromUserInput);

                // publisher.Publish(aSomewhatLongMessage);
            }
        }
    }

}
