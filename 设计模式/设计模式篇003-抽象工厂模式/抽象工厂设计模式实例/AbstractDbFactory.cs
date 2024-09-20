using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using 设计模式篇002_工厂方法模式.Skill;
using 设计模式篇002_工厂方法模式.抽象工厂设计模式实例;

namespace 设计模式篇002_工厂方法模式.工厂方法设计模式
{
    public abstract class AbstractDbFactory
    {
        public abstract T CreateDB<T>() where T : class, IDbLocator;
    }

    public class DbFactory : AbstractDbFactory
    {
        public override T CreateDB<T>()
        {
            try
            {
                var db = Activator.CreateInstance(typeof(T)) as T;
                return db;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
