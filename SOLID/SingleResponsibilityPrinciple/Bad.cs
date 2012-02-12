namespace SOLID.SingleResponsibilityPrinciple
{
    namespace BadExample
    {
        public class MessagePublisher
        {
            // Authentication?
            // Api formatting?


            public void PublishToTwitter(Message message)
            {
                "message [{0}] was sent to Twitter".Log(message.Text);
            }

            public void PublishToFacebook(Message message)
            {
                "message [{0}] was sent to Facebook".Log(message.Text);
            }

            public void PublishToGooglePlus(Message message)
            {
                "message [{0}] was sent to Google+".Log(message.Text);
            }
        }
    }
}
