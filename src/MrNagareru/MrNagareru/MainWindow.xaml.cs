using System;
using System.Collections.Generic;
using System.Linq;
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

namespace MrNagareru
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // 全画面表示にする
            this.WindowStyle = WindowStyle.None;
            this.WindowState = WindowState.Maximized;

            // 画面を透明にする
            this.AllowsTransparency = true;
            this.Background = new SolidColorBrush(Colors.Transparent);

            // 最前面に表示する
            this.Topmost = true;
        }


        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        // ウィンドウが開いた時
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // 終わるボタン
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        // 設定を開くボタン
        private void OpenSettingWindow_Click(object sender, EventArgs e)
        {

        }

        // テキストボックスがクリックされたとき
        private void textBox_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (textBox.Text == "チャットを入力してください")
            {
                textBox.Text = String.Empty;
            }
        }
    }
}
