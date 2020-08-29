using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Graph;

namespace src_backend
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void AuthenticateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                App.client = await App.auth.GetClient();
            }
            catch (ServiceException ex)
            {
                Console.WriteLine(ex.StatusCode);
            }

        }

        private void GetMessageButton_Click(object sender, RoutedEventArgs e)
        {   
            var messages = App.messageHandler.GetMessage(App.client, url.Text);
            foreach (string message in messages)
            {
                Console.WriteLine(message);
            }
        }

        private void SetMessageButton_Click(object sender, RoutedEventArgs e)
        {
           App.messageHandler.SetMessage(App.client, url.Text, message.Text);
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            var time = DateTimeOffset.Now;
            App.messageHandler.rep.AddReply(time, "New content " + time);
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            if (url.Text != "")
            {
                App.messageHandler.GetMessage(App.client, url.Text);
            }
        }

    }
}
