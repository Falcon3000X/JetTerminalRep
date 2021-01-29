using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace JetTerminal.Clients_class
{
    [Serializable]
    public class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Product { get; set; }
        public string Link { get; set; }

        public string TextMessage { get; set; }

        /// <summary>
        /// Empty constructor
        /// </summary>
        public Client() { }

        /// <summary>
        /// Constructor for full data input
        /// </summary>
        /// <param name="name"></param>
        /// <param name="email"></param>
        /// <param name="product"></param>
        /// <param name="link"></param>
        public Client(string name, string email, string product, string link)
        {
            this.Name = name;
            this.Email = email;
            this.Link = link;
            this.Product = product;
        }

        /// <summary>
        /// Constructor for data input without client name
        /// </summary>
        /// <param name="email"></param>
        /// <param name="link"></param>
        /// <param name="product"></param>
        public Client(string email, string link, string product)
        {
            this.Email = email;
            this.Name = email;
            this.Link = link;
            this.Product = product;
        }


        public void SetTextForClient()
        {
            if (Name == Email)
            {
                TextMessage = $"Hi help@easysupportnow.com, My name is Mark and I'm Ukrainian. Today I was looking for a product to promote to my subscribers, and I stumbled onto your sales letter." +
"I have to say that I really like what you are offering here," +
"and I can see that you are already seeing so great results with it in the Clickbank Marketplace." +
"Question is, why are you only offering this product to English customers?" +
"I'm a Digital Product Translator, and I would love to convert your product - The 12 Minute Affiliate System" +
"and your selling page into Russian language which I happen to speak and write fluently." +
"So you can tap into the huge consumer base of Russian speaking people." +
"You can literally multiply your revenue overnight by taking your already successful product and making it available" +
"to an international audience." +
"There is little to NO competition in this niche for this audience right now!" +
"Hit the Reply right now and I'll get this done for you for dirt cheap." +
"Waiting To hear back from you..." +
"Mark." +
"P.S.Right now there are Clickbank Super affiliates who are desperately looking for new products they can market for cheaper to foreign traffic sources.By working with me, you'll be able to make your product available to them for promotion very shortly.";
            }

            if (Name != Email)
            {

            }
        }


        /// <summary>
        /// Send message to client.
        /// </summary>
        public void SendMail()
        {
            MailAddress from = new MailAddress("marik.shevchenko@icloud.com", "Mark");

            MailAddress to = new MailAddress("marik.boy0101@gmail.com");

            MailMessage mailMessage = new MailMessage(from, to);

            mailMessage.Subject = "Test";

            mailMessage.Body = "<h2>Welcome to America</h2>";
            mailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

            smtpClient.EnableSsl = true;

            smtpClient.Send(mailMessage);
        }

        /// <summary>
        /// Show info in list box
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Name: {Name} | Product: {Product} | Email: {Email} | Link: {Link}";
        }

    }
}
