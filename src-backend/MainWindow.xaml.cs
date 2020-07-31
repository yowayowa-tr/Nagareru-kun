using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Graph;
using Microsoft.Identity.Client;

namespace src_backend
{

    public partial class MainWindow : Window
    {
        private GraphServiceClient client;
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AuthenticateButton_Click(object sender, RoutedEventArgs e)
        {
            client = await App.GetAuthentication.GetClient();
        }

        private void GetMessageButton_Click(object sender, RoutedEventArgs e)
        {

        }
        private void SetMessageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdatedMessageButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
