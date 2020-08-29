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

            foreach(var message in messages)
                Console.WriteLine(message);
        }

        private async void SetMessageButton_Click(object sender, RoutedEventArgs e)
        {
           await App.messageHandler.SetMessage(App.client, url.Text, message.Text);
           message.Text = string.Empty;
        }

        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            if (url.Text != string.Empty)
            {
                App.messageHandler.GetMessage(App.client, url.Text);
            }
        }

        //for demo
        private void AddMessageButton_Click(object sender, RoutedEventArgs e)
        {
            var time = DateTimeOffset.Now;
            App.messageHandler.rep.AddReply(time, message.Text + " (" + time + ")");
            message.Text = string.Empty;
        }

    }
}
