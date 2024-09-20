<Query Kind="Program" />

void Main()
{
	const string MutexName = "CSharp";
	Mutex m;
	bool firstInstance;
	using (m = new Mutex(false, MutexName, out firstInstance))
	{
		if (!firstInstance)
		{
			//非第一次调用
			Console.WriteLine("程序已经在执行，等待两秒将直接退出本程序");
			Thread.Sleep(2000);
			return;
		}
		Console.WriteLine("程序正在启动....\n");
		Console.WriteLine("程序运行中....\n");
		Console.WriteLine("请按回车键退出运行");
		Console.ReadLine();
		//非必要，出了using就销毁了资源
		m.Close();
		return;
	}
}