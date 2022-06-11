using System;
using System.Collections.Generic;
using System.IO;
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
using LinPengFeiLib;
using Microsoft.Win32;

namespace LinPengFeiWPF
{
    /// <summary>
    /// RegisterPage.xaml 的交互逻辑
    /// </summary>
    public partial class RegisterPage : Page
    {
        private string stuId { get; set; }
        private string stuName { get; set; }
        private string stuGender { get; set; }
        private string stuFaculty { get; set; }
        private List<string> stuProjects = new List<string>();
        private int projectCount = 0;
        private string fileName = "山东大学（威海）2022年春季运动会报名表.txt";
        public RegisterPage()
        {
            InitializeComponent();
            stuGender = "男";
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            // 获取报名信息
            stuId = textBox_stuID.Text;
            stuName = textBox_stuName.Text;
            stuFaculty = comboBox__faculty.Text;

            if (stuId != "" && stuName != "" && stuProjects.Count() != 0)
            {
                // 查询学号是否已存在
                IEnumerable<string> idQuery =
                    from stu in Register.stuList
                    where stu.stuID == this.stuId
                    select stuId;
                // 已存在，则拒绝添加
                if (idQuery.Count() > 0)
                {
                    MessageBox.Show($"学号为{stuId}的同学已完成报名，请检查学号后重试！");
                }
                else
                {
                    // 添加学生报名信息
                    Register newRegister = new Register(stuId, stuName, stuGender, stuFaculty, stuProjects);
                    Register.stuList.Add(newRegister);

                    MessageBox.Show("添加成功！");
                }
            }
            else 
            {
                if(stuId == "")
                    MessageBox.Show("学号为空，请完善报名信息！");
                else if(stuName == "")
                    MessageBox.Show("姓名为空，请完善报名信息！");
                else if(stuProjects.Count() == 0)
                    MessageBox.Show("暂未选择参赛项目，请选择后再添加！");
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            // 打开文件选择对话框
            var open = new OpenFileDialog
            {
                InitialDirectory = System.IO.Path.GetDirectoryName(fileName),
                Filter = "文本文件（*.txt）|*.txt|所有文件（*.*）|*.*",
                FileName = fileName
            };
            if (open.ShowDialog() == true)
            {
                // 获取保存文件名
                fileName = open.FileName;
            }

            try
            {
                // 转化为字符串
                string[] registerList = new string[Register.stuList.Count];
                for (int i = 0; i < Register.stuList.Count; i++)
                {
                    registerList[i] = Register.stuList[i].ToString();
                }

                // 写入文件
                File.WriteAllLines(fileName,
                    registerList, Encoding.Default);
                MessageBox.Show("保存成功!");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "保存文件失败!");
            }
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)
        {
            // 搜索结果置空
            textBox_searchResult.Text = "";
            string searchText = textBox_searchFaculty.Text;
            if (searchText != "")
            {
                // 查找符合学生报名信息
                IEnumerable<Register> registersQuery = 
                    from register in Register.stuList
                    where stuFaculty == searchText
                    select register;
                // 添加到查找结果
                foreach(Register r in registersQuery)
                {
                    textBox_searchResult.Text += r.ToString() + Environment.NewLine;
                }
            }
            else
            {
                MessageBox.Show("学院名为空，输入学院名以查询报名情况！");
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = e.Source as CheckBox;
            // 选中项目
            if (cb.IsChecked == true)
            {
                if (projectCount < 2)
                {
                    // 添加项目
                    stuProjects.Add(cb.Content.ToString());
                    projectCount++;
                }
                else  // 项目数超限
                {
                    cb.IsChecked = false;
                    MessageBox.Show("每人最多参加两种运动会项目！");
                }
            }
            else
            {
                // 移除项目
                stuProjects.Remove(cb.Content.ToString());
                projectCount--;
            }
        }

        private void wp_gender_Checked(object sender, RoutedEventArgs e)
        {
            // 性别单选
            RadioButton r = e.Source as RadioButton;
            if (r.IsChecked == true)
            {
                stuGender = r.Content.ToString();
            }
        }


    }
}
