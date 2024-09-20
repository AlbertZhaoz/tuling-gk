namespace 设计模式篇001_单例设计模式;

public class LazyMan
{
    // 引入标志位
    private static bool isReflection = true;

    // 1. 构造函数私有化
    private LazyMan()
    {
        lock (o)
        {
            if (isReflection)
            {
                isReflection = false;
            }
            else
            {
                throw new Exception("不可以从外界创建");
            }
        }
    }

    // 2. 写一个私有的字段
    private static volatile LazyMan _lazyMan;

    private static object o = new object();

    // 3. 写一个方法暴露给外界这个实例
    public static LazyMan GetLazyMan()
    {
        // lock是一个互斥锁，Monitor.Enter() Monitor.Exit()
        if (_lazyMan == null)
        {
            lock (o)
            {
                if (_lazyMan == null)
                {
                    // new LazyMan()
                    // 1. 开辟一块内存空间
                    // 2. 创建一个对象
                    // 3. 将对象指向内存空间
                    // 123  132 指针重排
                    _lazyMan = new LazyMan();
                    Console.WriteLine($"This is created by {Thread.CurrentThread.ManagedThreadId}");
                }
            }
        }

        return _lazyMan;
    }
}