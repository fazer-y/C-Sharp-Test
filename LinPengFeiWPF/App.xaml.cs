using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LinPengFeiWPF
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {

        public static void ExecuteConsoleApp(string arg)
        {
            // exe路径
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            // 完整路径
            path = path.Replace(@"WPF", @"Con");
            // 运行ConsoleApp
            System.Diagnostics.Process.Start(path, arg);
        }
    }
}
