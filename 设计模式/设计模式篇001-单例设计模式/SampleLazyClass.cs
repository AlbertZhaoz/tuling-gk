namespace 设计模式篇001_单例设计模式;

public class SampleLazyClass
{
    private SampleLazyClass(){}

    private static readonly Lazy<SampleLazyClass> Lazy = new Lazy<SampleLazyClass>(() => new SampleLazyClass());

    public static SampleLazyClass GetLazyClass()
    {
        return Lazy.Value;
    }
}