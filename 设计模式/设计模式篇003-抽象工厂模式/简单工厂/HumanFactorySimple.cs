using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设计模式篇002_工厂方法模式.Skill;

namespace 设计模式篇002_工厂方法模式.简单工厂
{
    public class HumanFactorySimple
    {
        public static T CreateHuman<T>() where T : class, IHuman
        {
            IHuman human = null;
            try
            {
                human = Activator.CreateInstance<T>() as IHuman;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return human as T;
        }
    }
}
