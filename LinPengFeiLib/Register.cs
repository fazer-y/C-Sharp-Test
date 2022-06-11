using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 添加一个类库项目ZhangSanLib，其中一个Register类，记录运动会报名信息，具有以下属性（数据类型自定）： 学号，姓名，性别，学院，项目1，项目2，其中每人可最多报2项（只报一项则项目2为空）。一个静态成员变量public static List<Register> stuList = new List<Register>(); 用来记录报名信息。
//类中包括下列方法：
//（a）．默认及带参数的构造方法。
//（b）．public string ToString() 方法，该方法将一个Register对象的属性值合并为一个字符串并返回，各属性用逗号分隔，如：“20190080001，张三，男，机电学院，100米，跳远”。
//（c）．其它你认为需要使用的方法。
/// </summary>

namespace LinPengFeiLib
{
    
     
    public class Register
    {
        public string stuID { get; set; }       // 学号
        public string stuName { get; set; }     // 姓名
        public string stuGender { get; set; }   // 性别
        public string stuFaculty { get; set; }  // 学院
        // 报名项目
        public List<string> stuProjects = new List<string>();
        // 报名信息列表
        public static List<Register> stuList = new List<Register>();

        // 默认构造
        public Register()
        {
            this.stuID = "";
            this.stuName = "";
            this.stuGender = "";
            this.stuFaculty = "";
        }

        // 有参构造
        public Register(string stuID, string stuName, string stuGender, 
            string stuFaculty, List<string> stuProjects)
        {
            
            this.stuID = stuID;
            this.stuName = stuName;
            this.stuGender = stuGender;
            this.stuFaculty = stuFaculty;
            this.stuProjects = new List<string>(stuProjects);
        }

        public override string ToString()
        {
            // 两个项目
            if (this.stuProjects.Count == 2)
            {
                return $"{stuID}，{stuName}，{stuGender}，{stuFaculty}，{stuProjects[0]}，{stuProjects[1]}";
            }
            // 一个项目
            else
            {
                return $"{stuID}，{stuName}，{stuGender}，{stuFaculty}，{stuProjects[0]}";
            } 
        }
    }
}
