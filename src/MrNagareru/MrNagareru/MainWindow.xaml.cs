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

            //テキストをバインドする
            CopyClass Data = new CopyClass();
            Data.CopyText = "メッセージを入力してください。";
            DataContext = Data;
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //バインドするためのクラス
        public class CopyClass
        {
            public string CopyText { get; set; }
        }
<<<<<<< HEAD

        double tomei;
        private void Text_MouseEnter(object sender, MouseEventArgs e)
        {
            tomei = textbox1.Opacity;
            textbox1.Opacity = 0.5;
        }
        private void Text_MouseLeave(object sender, MouseEventArgs e)
        {
            textbox1.Opacity = tomei;
        }
=======
>>>>>>> dev-window-hojo
    }
}
