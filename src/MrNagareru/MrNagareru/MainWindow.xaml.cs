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
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

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

        // テキストボックスでEnterキーが押されたとき
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            // 代入
            string textValue = textBox.Text;

            // てすと あとでけす
            CreateTextBox(textValue);

            // TODO: ここで送信を処理する関数にtextValueを渡したい
        }

        // テキストボックスを作る
        private void CreateTextBox(String comm)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                var comment = new TextBlock
                {
                    FontSize = 25,
                    TextWrapping = TextWrapping.NoWrap,
                    Opacity = 0,
                    Text = comm,
                    Foreground = new SolidColorBrush(Colors.White),
                    Background = new SolidColorBrush(Color.FromArgb(1, 0, 0, 0))
                };

                Root.Children.Add(comment);
                Dispatcher.BeginInvoke(new Action(() =>
                  {
                      MoveComment(comment);
                      comment.Opacity = 100;
                  }), DispatcherPriority.Loaded);
            }));
        }

        private void MoveComment(TextBlock comment)
        {
            var random = new Random();
            Canvas.SetTop(comment, random.Next((int)comment.ActualHeight, (int)(Height * 0.9)));
            var moveTime = random.Next(10000, 13000);
            var animation = new DoubleAnimation
            {
                From = Width,
                To = (-1) * comment.ActualWidth - 10,
                Duration=TimeSpan.FromMilliseconds(moveTime)
            };
            var delet = new DispatcherTimer(DispatcherPriority.SystemIdle)
            {
                Interval=TimeSpan.FromMilliseconds(moveTime)
            };
            delet.Tick += (x,y) =>
            {
                delet.Stop();
                Root.Children.Remove(comment);
            };

            comment.BeginAnimation(LeftProperty, animation);
            delet.Start();
        }
    }
}
