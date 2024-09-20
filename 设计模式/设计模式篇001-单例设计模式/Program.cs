
// 有且只有一个实例

using System.Reflection;
using 设计模式篇001_单例设计模式;

HungryMan hungryMan1 = HungryMan.GetHungryMan();
HungryMan hungryMan2 = HungryMan.GetHungryMan();
HungryMan hungryMan3 = HungryMan.GetHungryMan();

Console.WriteLine(hungryMan1.GetHashCode());
Console.WriteLine(hungryMan2.GetHashCode());
Console.WriteLine(hungryMan3.GetHashCode());

Console.WriteLine("==================");

//LazyMan lazyMan1 = LazyMan.GetLazyMan();
//LazyMan lazyMan2 = LazyMan.GetLazyMan();

//Console.WriteLine(lazyMan1.GetHashCode());
//Console.WriteLine(lazyMan2.GetHashCode());

//for (int i = 0; i < 10; i++)
//{
//    new Thread(()=>LazyMan.GetLazyMan()).Start();
//}

Console.WriteLine("xxxxxx");
Type type = Type.GetType("设计模式篇001_单例设计模式.LazyMan");
var cons = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
var lazyMan1 = (LazyMan)cons[0].Invoke(null);
var lazyMan2 = (LazyMan)cons[0].Invoke(null);
Console.WriteLine(lazyMan1.GetHashCode());
Console.WriteLine(lazyMan2.GetHashCode());
Console.WriteLine("xxxxxxx");

for (int i = 0; i < 10; i++)
{
    new Thread(() =>
    {
        var sample = SampleLazyClass.GetLazyClass();
        Console.WriteLine(sample.GetHashCode());
    }).Start();
}
