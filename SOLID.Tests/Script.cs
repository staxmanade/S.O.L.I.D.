













/* 
 * 
 * 
 * Some BAD code...
 * http://vimeo.com/9981123
 * 
 * 
 * 
 * 
 * ?:\Mesh\Personal\Presentations\S.O.L.I.D\artifacts
 * 
 * 
 */

































/*
 * 
 * 
 *  .d8888b.   .d88888b.  888      8888888 8888888b.  
 * d88P  Y88b d88P" "Y88b 888        888   888  "Y88b 
 * Y88b.      888     888 888        888   888    888 
 *  "Y888b.   888     888 888        888   888    888 
 *     "Y88b. 888     888 888        888   888    888 
 *       "888 888     888 888        888   888    888 
 * Y88b  d88P Y88b. .d88P 888        888   888  .d88P 
 *  "Y8888P"   "Y88888P"  88888888 8888888 8888888P"  
                                                   
 * 
 * 
 *      S.O.L.I.D.
 *          S - (SRP) - Single Responsibility Principle
 *          O - (OCP) - Open Closed Principle
 *          L - (LSP) - Liskov Substitution Principle
 *          I - (ISP) - Inversion Segregation Principle
 *          D - (DIP) - Dependency Inversion Principle
 * 
 */

















// Who am I?


















/*
 * 
 *     J.A.S.O.N.
 *         J - July
 *         A - August
 *         S - September
 *         O - October
 *         N - November
 * 
 * 
 * 
 *         ´$$$$`                             ,,, 
 *        ´$$$$$$$`                         ´$$$`
 *         `$$$$$$$`      ,,        ,,       ´$$$$´
 *          `$$$$$$$`    ´$$`     ´$$`    ´$$$$$´
 *           `$$$$$$$` ´$$$$$` ´$$$$$`  ´$$$$$$$´
 *            `$$$$$$$ $$$$$$$ $$$$$$$ ´$$$$$$$´ 
 *             `$$$$$$ $$$$$$$ $$$$$$$`´$$$$$$´ 
 *    ,,,,,,      `$$$$$$ $$$$$$$ $$$$$$$ $$$$$$´ 
 *  ´$$$$$`    `$$$$$$ $$$$$$$ $$$$$$$ $$$$$$´ 
 * ´$$$$$$$$$`´$$$$$$$ $$$$$$$ $$$$$$$ $$$$$´ 
 * ´$$$$$$$$$$$$$$$$$$ $$$$$$$ $$$$$$$ $$$$$´ 
 *    `$$$$$$$$$$$$$$$ $$$$$$$ $$$$$$ $$$$$$´ 
 *       `$$$$$$$$$$$$$ $$$$$  $$ $$$$$$ $$´ 
 *        `$$$$$$$$$$$$,___,$$$$,____,$$$$$´ 
 *          `$$$$$$$$$$$$$$$$$$$$$$$$$$$$$´ 
 *           `$$$$$$$$$$$$$$$$$$$$$$$$$$$´ 
 *             `$$$$$$$$$$$$$$$$$$$$$$$$´ 
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 *   Jason Jarrett
 *        - @staxmanade
 *        - http://elegantcode.com
 *        - http://github.com/staxmanade
 *        -
 *        - Vertigo - http://vertigo.com
 */







































































// This real code - so we have real 'usings' :P
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using NUnit.Framework;







namespace SOLID
{
















    namespace SingleResponsibilityPrinciple
    {
        /*
         * 
         *       .d8888b.  
         *      d88P  Y88b 
         *      Y88b.      
         *       "Y888b.   
         *          "Y88b. 
         *            "888 
         *      Y88b  d88P 
         *       "Y8888P"  
         * 
         * 
         * 
         * 
         * 
         * S.R.P.
         * Single Responsibility Principle
         * 
         * An object/module/class/component should only have one
         * reason to change.
         * 
         * 
         * 
         * 
         * Which is better?
         * 
         *  a. The tool that can do it all (but none of them 
         *     really well)? It's awkard to hold, not very 
         *     strong and difficult to use?
         *                                                                http://www.globalnerdy.com/wordpress/wp-content/uploads/2009/07/single_responsibility_principle.jpg
         *
         *  b. Or the toolbox where each tool is designed to 
         *     do one specific thing, and do it well?
         *                                                                https://lh3.googleusercontent.com/-n5Fsp8AYfeQ/TBTbnhd4TkI/AAAAAAAAFU8/OG5_OxcLh34/s720/TK12_RV_100-PC_A%26P_TOOL_SET_COMP.jpg
         * 
         */







        // Let's build an object that can send messages 
        // to some social media sites... (all in theory of course)


        namespace BadExample
        {
            public class MessagePublisher
            {
                // Notice how any facebook/google+ specific 
                // configuration/authentication/message formatting
                // will all be smashed together within this single class.

                public void PublishToFacebook(Message message)
                {
                    "message [{0}] was sent to Facebook".Log(message.Text);
                }

                public void PublishToGooglePlus(Message message)
                {
                    "message [{0}] was sent to Google+".Log(message.Text);
                }

                // What if I want to add support for Twitter?
                // Now I have to extend this class, risk the chance of 
                // breaking existing implementations
                // and increase the complexity of this one class.
            }


            public class PublishTests
            {
                private Message _message;

                [SetUp]
                public void SetUp()
                {
                    _message = new Message("S.O.L.I.D at NNSDG!");
                }

                [Test]
                public void SendAMessageToGooglePlus()
                {
                    // All I want to do is send a Google+ plus 
                    // a message.
                    // What if facebook configuration causes this 
                    // operation to crash?
                    MessagePublisher messagePublisher = new MessagePublisher();
                    messagePublisher.PublishToGooglePlus(_message);
                }

                [Test]
                public void SendAMessageToFacebook()
                {
                    MessagePublisher messagePublisher = new MessagePublisher();
                    messagePublisher.PublishToFacebook(_message);
                }

                [Test]
                public void SendAMessageToAll()
                {
                    MessagePublisher messagePublisher = new MessagePublisher();
                    messagePublisher.PublishToFacebook(_message);
                    messagePublisher.PublishToGooglePlus(_message);
                }
            }
        }


        /*
                              o         _        _            _
                   _o        /\_      _ \\o     (_)\__/o     (_)
                 _< \_      _>(_)    (_)/<_       \_| \      _|/' \/            wat
                (_)>(_)    (_)           (_)      (_)       (_)'  _\o_
            -------------------------------------------------------------
        */



        namespace BetterExample
        {
            // Replaced a PublishToFaceBook or PublishToGooglePlus
            // with an abstraction that describes the intent.
            public interface IMessagePublisher
            {
                void Publish(Message message);
            }

            // By breaking each publisher implementation into their
            // own class, we can now easily change one without
            // disturbing the other.

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

            public class MessagePublisherFactory
            {
                public static IMessagePublisher[] LoadPublishers()
                {
                    return new IMessagePublisher[]
													 {
															 new FacebookPublisher(),
															 new GooglePlusPublisher(),
													 };
                }
            }


            public class PublishTests
            {
                private Message _message;

                [SetUp]
                public void SetUp()
                {
                    _message = new Message("S.O.L.I.D at NNSDG!");
                }

                [Test]
                public void SendAMessageToGooglePlus()
                {
                    var publisher = new GooglePlusPublisher();
                    publisher.Publish(_message);
                }

                [Test]
                public void SendAMessageToFacebook()
                {
                    var publisher = new FacebookPublisher();
                    publisher.Publish(_message);
                }

                [Test]
                public void SendAMessageToAll()
                {
                    foreach (var publisher in MessagePublisherFactory.LoadPublishers())
                    {
                        publisher.Publish(_message);
                    }
                }
            }
        }






        // SRP sometimes relates to an object's cohesion
        namespace Cohesion
        {
            /* 
             * Cohesion
             *  - A measure of how strongly-related each modules 
             *    functions/methods/properties/fields are in relation to it's purpose
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * Low Cohesion
             * 
             * 
             * 
             *      is difficult to
             *           - maintain
             *           - test
             *           - reuse
             *           - understand
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * 
             * High Cohesion
             * 
             *          - robust
             *          - reliable
             *          - reusable
             *          - understandable
             * 
             * 
             * 
             * 
             * 
             */
        }
    }





























    namespace OpenClosedPrincipal
    {

        /* 
         * 
         *           .d88888b.  
         *          d88P" "Y88b 
         *          888     888 
         *          888     888 
         *          888     888 
         *          888     888 
         *          Y88b. .d88P 
         *           "Y88888P"  
            
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * O.C.P.
         * Open/Closed Principal
         * 
         * 
         * “software entities (classes, modules, functions, etc.) 
         *  should be open for extension, but closed for modification”.
         * 
         * 
         * Bertrand Meyer coined term in 1988 book "Object
         * Oriented Software Construction"
         * 
         * 
         */






        namespace BadExample
        {
            public class MessagePublisherBase
            {
                public string FormatMessage(Message message)
                {
                    string publisherName = GetType().Name
                        .Replace("Publisher", "");

                    return "Message for {0} - {1}"
                        .FormatWith(publisherName, message.Text);
                }
            }

            public class FacebookPublisher : MessagePublisherBase
            { }

            public class GooglePlusPublisher : MessagePublisherBase
            { }

            public class MessageFormatterTests
            {
                [Test]
                public void Should_print_a_valid_facebook_formatted_message()
                {
                    Message message = new Message("Hello!");
                    FacebookPublisher publisher = new FacebookPublisher();

                    string formattedMessage = publisher.FormatMessage(message);

                    formattedMessage
                        .ShouldEqual("Message for Facebook - Hello!")
                        .Log();
                }

                [Test]
                public void Should_print_a_valid_GooglePlus_formatted_message()
                {
                    Message message = new Message("Hello!");
                    GooglePlusPublisher publisher = new GooglePlusPublisher();

                    string formattedMessage = publisher.FormatMessage(message);

                    formattedMessage
                        .ShouldEqual("Message for Google+ - Hello!")
                        .Log();

                    // Ut-oh, how does the GooglePlusPublisher fix this?
                }
            }
        }


        namespace BetterExample
        {
            public class MessagePublisherBase
            {
                protected virtual string GetPublisherName
                {
                    get
                    {
                        return GetType().Name.Replace("Publisher", "");
                    }
                }

                public string FormatMessage(Message message)
                {
                    string publisherName = GetPublisherName;
                    return "Message for {0} - {1}"
                        .FormatWith(publisherName, message.Text);
                }
            }

            public class FacebookPublisher : MessagePublisherBase
            { }

            public class GooglePlusPublisher : MessagePublisherBase
            {
                protected override string GetPublisherName
                {
                    get { return "Google+"; }
                }
            }

            public class MessageFormatterTests
            {
                [Test]
                public void Should_print_a_valid_facebook_formatted_message()
                {
                    Message message = new Message("Hello!");
                    FacebookPublisher publisher = new FacebookPublisher();

                    string formattedMessage = publisher.FormatMessage(message);

                    formattedMessage
                        .ShouldEqual("Message for Facebook - Hello!")
                        .Log();
                }

                [Test]
                public void Should_print_a_valid_GooglePlus_formatted_message()
                {
                    Message message = new Message("Hello!");
                    GooglePlusPublisher publisher = new GooglePlusPublisher();

                    string formattedMessage = publisher.FormatMessage(message);

                    formattedMessage
                        .ShouldEqual("Message for Google+ - Hello!")
                        .Log();
                }
            }
        }
    }































    namespace LiskovSubstitutionPrinciple
    {

        /* 
         * 
         *          888      
         *          888      
         *          888      
         *          888      
         *          888      
         *          888      
         *          888      
         *          88888888 
         * 
         * 
         * 
         * 
         * 
         * L.S.P.
         * Liskov Substitution Principal
         * 
         * 
         * 
         * 
         *			“What is wanted here is something like the 
         *			following substitution property: If for each 
         *			object o1 of type S there is an object o2 of 
         *			type T such that for all programs P defined 
         *			in terms of T, the behavior of P is unchanged 
         *			when o1 is substituted for o2 then S is a 
         *			subtype of T.”
         * 
         * 
         * Or in a more understandable version from Uncle 
         * Bob (Robert C. Martin)
         * 
         *			“Functions that use pointers or references 
         *			to base classes must be able to use objects 
         *			of derived classes without knowing it.”
         * 
         */




        namespace LspViolation
        {
            public abstract class TheBasePublisher
            {
                public abstract void PublishMessage(Message message);
                public abstract void PublishPhoto(byte[] photo);
            }


            public class FacebookPublisher : TheBasePublisher
            {
                public override void PublishMessage(Message message)
                {
                    message.Text.Log();
                }

                public override void PublishPhoto(byte[] photo)
                {
                    "Published photo".Log();
                }
            }

            public class TwitterPublisher : TheBasePublisher
            {
                public override void PublishMessage(Message message)
                {
                    message.Text.Log();
                }

                public override void PublishPhoto(byte[] photo)
                {
                    throw new NotSupportedException("Noo Noo.");
                }
            }

            public class PublisherTests
            {
                private void PublishToAll(IEnumerable<TheBasePublisher> publishers, string input, byte[] photo)
                {
                    foreach (var publisher in publishers)
                    {
                        publisher.PublishPhoto(photo);
                        publisher.PublishMessage(new Message(input));
                    }
                }


                [Test]
                public void Should_publish_long_message_to_Facebook()
                {
                    TheBasePublisher[] publishers = new TheBasePublisher[]
					                                	{
					                                		new FacebookPublisher(),
					                                		new TwitterPublisher(),
					                                	};
                    PublishToAll(publishers, Lipsum.LongMessage, new byte[] { 1, 2, 3 });
                }
            }
        }




        namespace OnePossibleFixForDesign
        {




            public abstract class TheBasePublisher
            {
                public abstract void PublishMessage(Message message);
            }

            public abstract class PhotoPublisher : TheBasePublisher
            {
                public abstract void PublishPhoto(byte[] photo);
            }





            public class FacebookPublisher : PhotoPublisher
            {
                public override void PublishMessage(Message message)
                {
                    message.Text.Log();
                }

                public override void PublishPhoto(byte[] photo)
                {
                    "Published photo".Log();
                }
            }

            public class TwitterPublisher : TheBasePublisher
            {
                public override void PublishMessage(Message message)
                {
                    message.Text.Log();
                }

                // No need to implement un-supported features
            }









            public class PublisherTests
            {
                private void PublishToAll(IEnumerable<PhotoPublisher> publishers, string input, byte[] photo)
                {
                    foreach (var publisher in publishers)
                    {
                        publisher.PublishPhoto(photo);
                        publisher.PublishMessage(new Message(input));
                    }
                }


                [Test]
                public void Should_publish_long_message_to_Facebook()
                {
                    var publishers = new PhotoPublisher[]
					    {
					        new FacebookPublisher(),
					        //new TwitterPublisher(), //Cannot publish photo to this service:P
					    };
                    PublishToAll(publishers, Lipsum.LongMessage, new byte[] { 1, 2, 3 });
                }
            }




























            public class ExampleOfLSPInDotNet
            {
                [Test]
                public void ThisIsABummer()
                {
                    // ReadOnlyCollection implements the following interfaces
                    //  IList<T>, ICollection<T>, IEnumerable<T>, 
                    //  IList, ICollection, IEnumerable
                    var readOnlyCollection =
                        new ReadOnlyCollection<int>(new[] { 0, 1, 2 });

                    AddItemToList(readOnlyCollection, 1);
                }

                public void AddItemToList(IList<int> list, int item)
                {
                    list.Add(item);
                }
            }
        }
    }






















    // I'm going to switch the order of I.D. in SOLID to D.I.




















    namespace DependencyInversionPrinciple
    {

        /*
         * 
         *          8888888b.  
         *          888  "Y88b 
         *          888    888 
         *          888    888 
         *          888    888 
         *          888    888 
         *          888  .d88P 
         *          8888888P"  
         * 
         * 
         * 
         * 
         * 
         * 
         * D.I.P.
         * Dependency Inversion Principle
         * 
         * 
         * 
         *		A. High-level modules should not depend on 
         *		   low-level modules. Both should depend on abstractions.
         *		   
         *		B. Abstractions should not depend upon details. Details 
         *		   should depend upon abstractions.
         * 
         * 
         * 
         */






        namespace CoupledCodeWithNoAbstraction
        {
            public class NetworkPostHelper
            {
                public void PostToUrl(string url, string data)
                {
                    ("Posted message [" + data + "] to " + url).Log();
                }
            }


            public class FacebookPublisher
            {
                public void Publish(string message)
                {
                    var networkPoster = new NetworkPostHelper();

                    networkPoster.PostToUrl("http://facebook.com/SomeRESTAddresss", message);
                }
            }


            public class FacebookPublisherTests
            {
                [Test]
                public void PublishTest()
                {
                    var facebookPublisher = new FacebookPublisher();
                    facebookPublisher.Publish("Hola!");
                }
            }
        }









        namespace DecoupledCodeWithSomeAbstraction
        {
            public interface INetworkPoster
            {
                string FacebookPostUrl { get; }

                void PostToUrl(string url, string data);
            }

            public class ProductionNetworkPoster : INetworkPoster
            {
                public string FacebookPostUrl
                {
                    get { return "http://facebook.com/SomeUrlIMadeUp"; }
                }

                public void PostToUrl(string url, string data)
                {
                    ("Posted message [" + data + "] to " + url).Log();
                }
            }

            public class TestNetworkPoster : INetworkPoster
            {
                public string FacebookPostUrl
                {
                    get { return "http://localhost/MyTestLocation"; }
                }


                public void PostToUrl(string url, string data)
                {
                    ("Posted message [" + data + "] to " + url).Log();
                }
            }

            public class FacebookPublisher
            {
                private readonly INetworkPoster _networkPoster;

                public FacebookPublisher(INetworkPoster networkPoster)
                {
                    this._networkPoster = networkPoster;
                }

                public void Publish(string message)
                {
                    var postUrl = _networkPoster.FacebookPostUrl;

                    ("Posted message [" + message + "] to " + postUrl).Log();
                }
            }


            public class FacebookPublisherTests
            {
                [Test]
                public void PublishTest()
                {
                    //var networkPoster = new Settings();
                    var settings = new TestNetworkPoster();

                    var facebookPublisher = new FacebookPublisher(settings);

                    facebookPublisher.Publish("Hola!");
                }
            }
        }
    }













    namespace InterfaceSegregationPrinciple
    {
        /*
         *          8888888 
         *            888   
         *            888   
         *            888   
         *            888   
         *            888   
         *            888   
         *          8888888 
         * 
         * 
         * 
         * 
         * 
         * 
         * I.S.P.
         * Interface Segregation Principle
         * 
         * 
         * 
         *		"Clients should not be forced to depend upon 
         *		 interfaces that they don't use."
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         * 
         */


        namespace BadExample
        {
            public interface IList<T>
            {
                T this[int index] { get; set; }
                int IndexOf(T item);
                void Insert(int index, T item);
                void RemoveAt(int index);


                // ICollection<T> methods below
                int Count { get; }
                bool IsReadOnly { get; }
                void Add(T item);
                void Clear();
                bool Contains(T item);
                void CopyTo(T[] array, int arrayIndex);
                bool Remove(T item);

                // Ignoring IEnumerable and IEnumerable<T> for this example
            }
        }


        namespace PossiblyBetterInterfaces
        {
            public interface IListView<T>
            {
                T this[int index] { get; set; }
                int IndexOf(T item);
                int Count { get; }
                bool Contains(T item);
                void CopyTo(T[] array, int arrayIndex);
            }

            public interface IList<T> : IListView<T>
            {
                void Add(T item);
                void Clear();
                bool Remove(T item);
                void Insert(int index, T item);
                void RemoveAt(int index);
            }


            // Good historical context as to why the .net 
            // library didn't do something like this 
            // http://www.infoq.com/news/2011/10/ReadOnly-WInRT
        }
    }





















    namespace OtherPrinciplesYouShouldKnow
    {
        /* 
         * 
         * D.R.Y.
         * 
         * K.I.S.S.
         * 
         * Y.A.N.G.I.
         * 
         * Law of Demeter - Each unit should only talk to it's friends; don't talk to strangers.
         * 
         * Principle of least surprise
         * 
         * 
         * 
         * 
         * What other good ones are out there?
         * 
         * 
         */
    }


































    /*
     *      S.O.L.I.D.
     *          S - (SRP) - Single Responsibility Principle
     *          O - (OCP) - Open Closed Principle
     *          L - (LSP) - Liskov Substitution Principle
     *          I - (ISP) - Inversion Segregation Principle
     *          D - (DIP) - Dependency Inversion Principle
     * 
     */
































































    /*
     * Below is just some code I leveraged above.
     * 
     */



    public class Lipsum
    {
        public static string LongMessage
        {
            get
            {
                return @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis nec blandit augue. Pellentesque metus purus, pellentesque at imperdiet sit amet, tempus at massa. Pellentesque sagittis faucibus ornare. Pellentesque interdum sem vel nisl interdum vestibulum pulvinar at neque. Sed pellentesque, elit id tempus accumsan, arcu augue dapibus nisi, vel sollicitudin ligula eros eu sem. Ut nec urna vel massa commodo rhoncus ac in est. Sed pulvinar justo vitae nisi malesuada porta. Aliquam sed dignissim metus. Cras a pulvinar nulla. Aliquam convallis mollis scelerisque. Nulla facilisi. Aenean sed tortor in velit facilisis blandit sed nec augue.

In diam nisi, tincidunt at bibendum eget, tempor sit amet nisi. Duis sollicitudin, lacus ac lacinia feugiat, nunc leo bibendum mauris, at pulvinar lorem ipsum in justo. Vivamus faucibus congue velit, in congue ligula congue in. Praesent vel metus quis dui viverra mattis. Donec aliquam est nec nisi rhoncus tristique. Phasellus porttitor leo in leo volutpat fermentum. Nullam viverra egestas lectus eu tempus. Etiam ultrices risus vitae nulla tincidunt convallis. Sed egestas tempus imperdiet. Cras consequat varius tempor. Nam sit amet velit eget mauris rhoncus iaculis ut eu tellus. Donec vehicula blandit auctor. Donec et congue quam. Curabitur luctus fringilla quam ut semper.";
            }
        }
    }



    // This represents an object that contains the
    // text we  want to send to our social media site
    public class Message
    {
        public Message(string text = "")
        {
            Text = text;
        }

        public string Text { get; set; }
    }
}
