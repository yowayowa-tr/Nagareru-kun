using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace src_backend
{
    /// <summary>
    /// CommentDisplay.xaml の相互作用ロジック
    /// </summary>
    public partial class CommentDisplay : Window
    {
        public MainWindow formMain;

        private static CommentDisplay _Instance;
        public static CommentDisplay GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new CommentDisplay();
            }
            return _Instance;
        }

        public void ReceivedComment()
        {
            CreateTextBox(formMain.receiveData);
        }

        public CommentDisplay()
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
                Duration = TimeSpan.FromMilliseconds(moveTime)
            };
            var delet = new DispatcherTimer(DispatcherPriority.SystemIdle)
            {
                Interval = TimeSpan.FromMilliseconds(moveTime)
            };
            delet.Tick += (x, y) =>
            {
                delet.Stop();
                Root.Children.Remove(comment);
            };

            comment.BeginAnimation(LeftProperty, animation);
            delet.Start();
        }
    }
}