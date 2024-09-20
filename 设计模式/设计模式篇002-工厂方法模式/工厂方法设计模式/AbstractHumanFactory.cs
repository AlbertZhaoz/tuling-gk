using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using 设计模式篇002_工厂方法模式.简单工厂;

namespace 设计模式篇002_工厂方法模式.工厂方法设计模式
{
    // 八卦炉的精髓方法
    public abstract class AbstractHumanFactory
    {
        public abstract T CreateHuman<T>() where T : class, IHuman;
    }

    // 萧炎用的炉子
    public class HumanFactory : AbstractHumanFactory
    {
        public override T CreateHuman<T>()
        {
            try
            {
                var human = Activator.CreateInstance(typeof(T)) as T;
                return human;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }

    // 需求：通过字符串来获取人种
    // 1. 写一个特性（狗皮膏药）
    public class TypeNameToInstance : Attribute
    {
        public string TypeName { get; }

        public TypeNameToInstance(string s)
        {
            this.TypeName = s;
        }
    }

    // 2. 编写工厂延迟加载
    public class FactoryDelay
    {
        private static Dictionary<string, IHuman> dic = new Dictionary<string, IHuman>();

        public IHuman GetHuman(string typeName)
        {
            if (dic.ContainsKey(typeName))
            {
                return dic[typeName];
            }

            return null;
        }

        public FactoryDelay()
        {
            // 1. 拿到正在运行的程序集并获取所有类型（里面包含了三大人种类型）
            Assembly assembly = Assembly.GetExecutingAssembly();

            foreach (var item in assembly.GetTypes())
            {
                // 2. 对这个 item ，进行一个判断，判断是否实现了 IHuman 的接口，并且不是 Ihuman 本身
                if (typeof(IHuman).IsAssignableFrom(item) && !item.IsInterface)
                {
                    // 3. 获取 item 上面特性的名字属性
                    var typeNameToInstance = item.GetCustomAttribute<TypeNameToInstance>();
                    if (!string.IsNullOrEmpty(typeNameToInstance.TypeName))
                    {
                        dic[typeNameToInstance.TypeName] = Activator.CreateInstance(item) as IHuman;
                    }
                }
            }

        }
    }
}
