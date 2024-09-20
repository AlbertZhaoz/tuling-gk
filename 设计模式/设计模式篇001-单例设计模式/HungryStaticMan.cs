namespace 设计模式篇001_单例设计模式;

public class HungryStaticMan
{
    private HungryStaticMan(){}

    public static class InnerClass
    {
        public static HungryStaticMan _HungryStaticMan = new HungryStaticMan();
    }

    public static HungryStaticMan GetHungryStaticMan()
    {
        return InnerClass._HungryStaticMan;
    }
}