// See https://aka.ms/new-console-template for more information

using CloneExtensions;

var myclass1 = new myClass();
myclass1.SetStudent("曹操");
myclass1.ClassName = "三国一班";
var myclass2 = (myClass)myclass1.Clone();
myclass2.SetStudent("小乔");
// 使用 Nuget 包进行深拷贝（表达式目录树）
var myclass3 = myclass1.GetClone();
myclass3.SetStudent("周瑜");
// 改变了引用类型的 student的值了
myclass1.GetName();
myclass2.GetName();
myclass3.GetName();

class student
{
    public string Name { get; set; } 
}

class myClass:ICloneable
{
    private student _student = new student();
    public string ClassName { get; set; }

    public void SetStudent(string name)
    {
        _student.Name = name;
    }
    
    public void GetName()
    {
        Console.WriteLine($"教室名字{ClassName},学生名字{_student.Name}");
    }

    public object Clone()
    {
        return this.MemberwiseClone();
    }
}