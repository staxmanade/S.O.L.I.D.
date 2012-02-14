/*
 * Some BAD code...
 * http://vimeo.com/9981123
 * 
 * also locally in ?:\Mesh\Personal\Presentations\S.O.L.I.D\artifacts
 */

// This real code - so we have real 'usings' :P

using System;
using NUnit.Framework;

namespace SOLID
{
	/*
	 *      S.O.L.I.D.
	 *          S - (SRP) - Single Responsibility Principle
	 *          O - (OCP) - Open Closed Principle
	 *          L - (LSP) - Liskov Substitution Principle
	 *          I - (ISP) - Inversion Segregation Principle
	 *          D - (DIP) - Dependency Inversion Principle
	 * 
	 */














	namespace SingleResponsibilityPrinciple
	{
		/*
		 * S.R.P.
		 * Single Responsibility Principle
		 * 
		 * An object/module/class/component should only have one
		 * reason to change.
		 * 
		 * 
		 * 
		 * 
		 * Which tool would you choose to solve a problem?
		 *  a. The tool that can do it all (but none of them really well)? 
		 *      It's awkard to hold, not very strong and difficult to use?
		 *  b. Or the toolbox where each tool is designed to do one specific 
		 *      thing, and do it well?
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
		 * 
		 * 
		 * 
		 * 
		 * 
		 */


		// SRP sometimes relates to an object's cohesion
		namespace Cohesion
		{
			/* 
			 * Cohesion
			 *  - A measure of how strongly-related each module is
			 * 
			 * 
			 * 
			 * 
			 * 
			 * Low Cohesion
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
			 * is difficult to
			 *      - maintain
			 *      - test
			 *      - reuse
			 *      - understand
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
			 * High Cohesion is
			 * 
			 * 
			 * 
			 * 
			 *      - robust
			 *      - reliable
			 *      - reusable
			 *      - understandable
			 * 
			 * 
			 * 
			 * 
			 * 
			 * 
			 */
		}





		// Let's build an object that can send messages 
		// to some social media sites... (all in theory of course)

		namespace BadExample
		{
			public class MessagePublisher
			{
				// Notice how any facebook/twitter specific 
				// configuration/authentication/message formatting
				// will all be smashed together within a single class.

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
					// All I want to do is send a Google+ plus a message
					// What if facebook configuration causes this operation to crash?
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
					MessagePublisher  messagePublisher = new MessagePublisher();
					messagePublisher.PublishToFacebook(_message);
					messagePublisher.PublishToGooglePlus(_message);
				}
			}
		}

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
	}






	namespace OpenClosedPrincipal
	{

		/* 
		 * OCP
		 * Open/Closed Principal
		 * 
		 * 
		 * “software entities … should be open for extension, but closed for modification”.
		 * 
		 * 
		 * Term originally coinded by Bertrand Meyer in 1988 book "Object Oriented Software Construction"
		 * 
		 * 
		 * 
		 */






		namespace BadExample
		{
			public class MessagePublisherBase
			{
				public string FormatMessage(Message message)
				{
					return "Message for {0} - {1}".FormatWith(GetType().Name.Replace("Publisher", ""), message.Text);
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

					formattedMessage.ShouldEqual("Message for Facebook - Hello!").Log();
				}
				
				[Test]
				public void Should_print_a_valid_GooglePlus_formatted_message()
				{
					Message message = new Message("Hello!");
					GooglePlusPublisher publisher = new GooglePlusPublisher();

					string formattedMessage = publisher.FormatMessage(message);

					formattedMessage.ShouldEqual("Message for Google+ - Hello!").Log();

					// Ut-oh, how does the GooglePlusPublisher fix this?
				}
			}
		}


		namespace BetterExample
		{
			public class MessagePublisherBase
			{
				protected virtual string GetPublisherName { get { return GetType().Name.Replace("Publisher", ""); } }

				public string FormatMessage(Message message)
				{
					return "Message for {0} - {1}".FormatWith(GetPublisherName, message.Text);
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

					formattedMessage.ShouldEqual("Message for Facebook - Hello!").Log();
				}

				[Test]
				public void Should_print_a_valid_GooglePlus_formatted_message()
				{
					Message message = new Message("Hello!");
					GooglePlusPublisher publisher = new GooglePlusPublisher();

					string formattedMessage = publisher.FormatMessage(message);

					formattedMessage.ShouldEqual("Message for Google+ - Hello!").Log();

					// Ut-oh, how does the GooglePlusPublisher fix this?
				}
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

