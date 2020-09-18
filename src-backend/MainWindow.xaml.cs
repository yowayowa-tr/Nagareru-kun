using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using Microsoft.Graph;

namespace src_backend
{

    public partial class MainWindow : Window
    {
        public string receiveData = "BULL";
        public MainWindow()
        {
            InitializeComponent();
            //cdw = new CommentDisplay();
            CommentDisplay.GetInstance().formMain = this;
            //cdw.formMain = this;
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
           receiveData = message.Text;
           CommentDisplay.GetInstance().ReceivedComment();
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


        private void CommnetOFF_Click(object sender, RoutedEventArgs e)
        {
            CommentDisplay.GetInstance().Hide();
        }

        private void CommentON_Click(object sender, RoutedEventArgs e)
        {
            CommentDisplay.GetInstance().Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            CommentDisplay.GetInstance().Close();
        }

        // SetMessageのテキストボックスでEnterを押したとき
        private async void message_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            await App.messageHandler.SetMessage(App.client, url.Text, message.Text);
            receiveData = message.Text;
            CommentDisplay.GetInstance().ReceivedComment();
            message.Text = string.Empty;
        }
    }
}
