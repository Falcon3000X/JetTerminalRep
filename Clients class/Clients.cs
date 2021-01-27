using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace JetTerminal.Clients_class
{
    public class ClientsList
    {
        public List<Client> Clients = new List<Client>();

        /// <summary>
        /// Check all clients and returns false if client already exist
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public bool IsNewClient(Client client)
        {
            bool is_new = true;

            foreach (var person in Clients)
            {
                // Check new client
                if (person.Email == client.Email && person.Link == client.Link && person.Name == client.Name && person.Product == client.Product)
                {
                    is_new = false;
                }
            }
            return is_new;
        }

        /// <summary>
        /// Add new client if it`s not exist
        /// </summary>
        /// <param name="client"></param>
        public void AddClient(Client client)
        {
            if (IsNewClient(client) == true)
            {
                Clients.Add(client);
            }
            else
            {
                MessageBox.Show("This client already exist!", "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Serialize all clients to xml file 
        /// </summary>
        public void WriteToXml()
        {
            // Formatter for List<Clients>
            XmlSerializer formatter = new XmlSerializer(typeof(List<Client>));

            // Stream wich will write all data to file DataClients.xml
            using (FileStream fs = new FileStream("DataClients.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Clients);
            }
        }

        /// <summary>
        /// Deserialize all clients to List<Clients> when programm start
        /// </summary>
        public void WriteFromXml()
        {
            // Formatter for List<Clients>
            XmlSerializer formatter = new XmlSerializer(typeof(List<Client>));

            // All clients will deserialize from "DataClients.xml" to Clients.
            using (FileStream fs = new FileStream("DataClients.xml", FileMode.OpenOrCreate))
            {
                Clients = (List<Client>)formatter.Deserialize(fs);
            }
        }

    }
}
