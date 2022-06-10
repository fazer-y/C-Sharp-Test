using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinPengFeiCon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyClass myClass = new MyClass();
        }
        // 前八章，不考第七章
        // 没星号的或有星号但是讲了的
        // linq
        // 不考winform
    }

    public class MyClass
    {
        public MyClass()
        {
            Console.Write("请输入待排序字符串：");
            string str = Console.ReadLine();
            List<char> l = str.ToList();
            l.Sort();
            foreach (char c1 in l)
            {
                Console.WriteLine(c1);
            }
            Console.Write("请输入待查找字符：");
            char c = (char)Console.Read();
            if (l.Contains(c))
                Console.WriteLine("是！");
            else
                Console.WriteLine("否！");
            while (true)
            {
                Console.Write("输入exit以退出系统：");
                string exStr = Console.ReadLine();
                if (exStr == "exit")
                    return;
            }
        }
    }
}
