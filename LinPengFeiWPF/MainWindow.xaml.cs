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

namespace LinPengFeiWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        Button lastButton = null;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void btn_console_Click(Object sender, RoutedEventArgs e)
        {
            App.ExecuteConsoleApp("LinPengFeiCon.Program");
            Button btn = e.Source as Button;
            textBlock_title.Text = btn.Content.ToString();
        }

        public void my_btn_Click(Object sender, RoutedEventArgs e)
        {
            if (lastButton != null)
            {
                lastButton.Foreground = Brushes.HotPink;
            }
            Button btn = e.Source as Button;
            btn.Foreground = Brushes.Red;
            textBlock_title.Text = btn.Content.ToString();
            Uri uri = new Uri(btn.Tag.ToString(), UriKind.Relative);
            object obj = null;
            try
            {
                obj = Application.LoadComponent(uri);
            }
            catch
            {
                MessageBox.Show("未找到 " + uri.OriginalString, "出错了");
                return;
            }
            frame_test.Source = uri;
            if (lastButton == btn)
            {
                frame_test.Refresh();
            }
            lastButton = btn;
        }
    }
}
