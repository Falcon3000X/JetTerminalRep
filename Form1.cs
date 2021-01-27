using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using JetTerminal.Clients_class;

namespace JetTerminal
{
    public partial class Form1 : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        ClientsList Clients = new ClientsList();

        public Form1()
        {
            InitializeComponent();

            // Form design
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
            // ===========================================================================================================================================

            
            Clients.WriteFromXml(); // Download all files from .xml 
            SyncListBoxWithList(); // Synchronize List<Clients> with list box
        }

        /// <summary>
        /// Button for adding new client
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {

                // If client without name than give email value to name
                if (textBoxEmail.Text != "" && textBoxLink.Text != "" && textBoxProduct.Text != "" && textBoxName.Text == "")
                {
                    Client client = new Client();

                    // Receive info from text boxes to new client
                    client.Email = textBoxEmail.Text;
                    client.Link = textBoxLink.Text;
                    client.Product = textBoxProduct.Text;
                    client.Name = textBoxEmail.Text;

                    // Add new client to list
                    Clients.AddClient(client);

                    // Syncronize list with list box
                    SyncListBoxWithList();

                    // Clear all text boxes
                    ClearTextBoxes();
                } // If we have client name than add full info
                else if (textBoxEmail.Text != "" && textBoxLink.Text != "" && textBoxProduct.Text != "" && textBoxName.Text != "")
                {
                    Client client = new Client();

                    // Receive info from text boxes to new client
                    client.Email = textBoxEmail.Text;
                    client.Link = textBoxLink.Text;
                    client.Product = textBoxProduct.Text;
                    client.Name = textBoxName.Text;

                    // Add new client to list
                    Clients.AddClient(client);

                    // Syncronize list with list box
                    SyncListBoxWithList();

                    // Clear all text boxes
                    ClearTextBoxes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Clear list box and than synchronize it with list.
        /// </summary>
        public void SyncListBoxWithList()
        {
            // Clear list box
            listBoxClients.Items.Clear();

            // Add all items from list to list box
            foreach (var item in Clients.Clients)
            {
                listBoxClients.Items.Add(item);
            }
        }

        /// <summary>
        /// Clear all text boxes
        /// </summary>
        public void ClearTextBoxes()
        {
            textBoxEmail.Text = "";
            textBoxLink.Text = "";
            textBoxName.Text = "";
            textBoxProduct.Text = "";
        }

        private void loadClientsToFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clients.WriteToXml();
        }
    }
}
