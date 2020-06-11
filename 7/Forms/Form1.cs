using Forms.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
                return;
            string listString = listBox1.SelectedItem.ToString();
            var items = listString.Split('>');
            textBox1.Text = items[0];
            textBox2.Text = items[1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var client = new WebService1SoapClient();
            listBox1.Items.Clear();
            foreach (Data item in client.GetDict())
            {
                listBox1.Items.Add($"{item.Id}>{item.Name}");
            }

            /*var client = new ServiceReference2.Service1Client("BasicHttpBinding_IService1");
            client.Open();
            foreach (ServiceReference2.Data item in client.GetDict())
            {
                listBox1.Items.Add($"{item.Id}>{item.Name}");
            }*/
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var client = new WebService1SoapClient();
            Data data = new Data();
            data.BDate = DateTime.Now;
            data.Spec = "AUTO";
            data.SYear = 1234;
            data.Name = textBox2.Text;
            data.Id = Int32.Parse(textBox1.Text);
            client.AddDict(data);
            button1_Click(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var client = new WebService1SoapClient();
            Data data = new Data();
            data.Id = Int32.Parse(textBox1.Text);
            client.DelDict(data);
            button1_Click(null, null);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var client = new WebService1SoapClient();
            Data data = new Data();
            data.BDate = DateTime.Now;
            data.Spec = "AUTO";
            data.SYear = 1234;
            data.Name = textBox2.Text;
            data.Id = Int32.Parse(textBox1.Text);
            client.UdpDict(data);
            button1_Click(null, null);
        }
    }
}
