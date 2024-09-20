<Query Kind="Program" />

void Main()
{
	var thread1 = new Thread(ThreadMetho1);
	thread1.Start();
	
	var thread2 = new Thread(ThreadMethod2);
	thread2.Start(2);

	var thread3 = new Thread(() =>
	{
		"66".Dump();
	})
	{
		IsBackground = false,
		Priority = ThreadPriority.Normal
	};
	
	thread3.Start();
}

void ThreadMetho1(){
	"11".Dump();
}

void ThreadMethod2(object? num){
	num.Dump();
}
