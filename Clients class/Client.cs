﻿using System;
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




        /// <summary>
        /// Send message to client.
        /// </summary>
        public void SendMail()
        {
          
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
