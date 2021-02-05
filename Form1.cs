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
using System.Net.Mail;
using System.Net;

namespace JetTerminal
{
    public partial class Form1 : MaterialForm
    {
        MaterialSkinManager materialSkinManager = MaterialSkinManager.Instance;
        ClientsList Clients = new ClientsList();

        private string MyName;
        private string MyEmail;
        private string MyPassword;

        public Form1()
        {
            InitializeComponent();

            // Form design
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Blue800, Primary.Blue900, Primary.Blue500, Accent.LightBlue200, TextShade.WHITE);
            // ========================================================================================================================================
            buttonSendMessage.Enabled = false;
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
                if (textBoxEmail.Text != "" && textBoxProduct.Text != "")
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
                else
                {
                    MessageBox.Show("One of important fields is empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void buttonSendMessage_Click(object sender, EventArgs e)
        {

            string smtpAddress = "smtp.gmail.com";
            const int port_number = 587;
            //  bool enable_ssl = true;
            string subject = "I will help you increase your audience!";

            try
            {
                foreach (var person in Clients.Clients)
                {
                    if (person.Email != "" && person.Product != "")
                    {
                        // Формируем текст для письма.
                        person.TextMessage =
                            $"Hello! My name is {MyName} and I'm Ukrainian. Today I was looking for a product to promote to my subscribers, and I stumbled onto your sales letter." +
                            "I have to say that I really like what you are offering here, and I can see that you are already seeing so great results with it in the Clickbank Marketplace. Question is, why are you only offering this product to English customers? " +
                            $"I'm a Digital Product Translator, and I would love to convert your product - {person.Product}  and your selling page into Russian language which I happen to speak and write fluently." +
                            "So you can tap into the huge consumer base of Russian speaking people.\n" +
                            "You can literally multiply your revenue overnight by taking your already successful product and making it available to an international audience.\n" +
                            "There is little to NO competition in this niche for this audience right now!\n" +
                            "Hit the Reply right now and I'll get this done for you for dirt cheap. \n" +
                            "Waiting To hear back from you... \n" +
                            $"{MyName}.\n" +

                            "P.S.Right now there are Clickbank Super affiliates who are desperately looking for new products they can market for cheaper to foreign traffic sources.By working with me, you'll be able to make your product available to them for promotion very shortly.";

                        // -----------------------------------------------------------------------------------
                        // Готовим писмьо к отправке

                        using (MailMessage mail = new MailMessage())
                        {
                            mail.From = new MailAddress(MyEmail);

                            mail.To.Add(person.Email);

                            mail.Subject = subject;

                            mail.IsBodyHtml = true;

                            mail.Body = person.TextMessage;

                            using (SmtpClient smtp = new SmtpClient(smtpAddress, port_number))
                            {
                                smtp.Credentials = new NetworkCredential(MyEmail, MyPassword);

                                //smtp.EnableSsl = enable_ssl;

                                smtp.Send(mail);
                            }


                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            if (textBoxWorkerName.Text != "" && textBoxWorkerEmail.Text != "" && textBoxWorkerPassword.Text != "")
            {
                MyName = textBoxWorkerName.Text;
                MyEmail = textBoxWorkerEmail.Text;
                MyPassword = textBoxWorkerPassword.Text;

                buttonSendMessage.Enabled = true;
            }
            else
            {
                MessageBox.Show("One or more fields is empty!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
