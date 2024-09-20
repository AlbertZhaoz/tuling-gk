using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 设计模式篇002_工厂方法模式.工厂方法设计模式;

namespace 设计模式篇002_工厂方法模式.Skill
{
    public interface IHuman
    {
        void GetColor();
        void Talk();
    }

    [TypeNameToInstance("Yellow")]
    public class YellowMan : IHuman
    {
        public void GetColor()
        {
            Console.WriteLine("Yellow");
        }

        public void Talk()
        {
            Console.WriteLine("Yellow Talk");
        }
    }

    [TypeNameToInstance("White")]
    public class WhiteMan : IHuman
    {
        public void GetColor()
        {
            Console.WriteLine("White");
        }

        public void Talk()
        {
            Console.WriteLine("White Talk");
        }
    }

    [TypeNameToInstance("Black")]
    public class BlackMan : IHuman
    {
        public void GetColor()
        {
            Console.WriteLine("Black");
        }

        public void Talk()
        {
            Console.WriteLine("Black Talk");
        }
    }
}
