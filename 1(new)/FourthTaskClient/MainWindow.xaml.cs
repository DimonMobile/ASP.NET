using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FourthTaskClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int x = Int32.Parse(TextBoxSource1.Text);
            int y = Int32.Parse(TextBoxSource2.Text);

            HttpClient client = new HttpClient();
            KeyValuePair<string, string> paramX = new KeyValuePair<string, string>("x", x.ToString());
            KeyValuePair<string, string> paramY = new KeyValuePair<string, string>("y", y.ToString());

            List<KeyValuePair<string, string>> query = new List<KeyValuePair<string, string>>();
            query.Add(paramX);
            query.Add(paramY);

            FormUrlEncodedContent content = new FormUrlEncodedContent(query);

            HttpResponseMessage resp = await client.PostAsync("http://localhost:64506/api", content);
            TextBoxResult.Text = await resp.Content.ReadAsStringAsync();
        }
    }
}
