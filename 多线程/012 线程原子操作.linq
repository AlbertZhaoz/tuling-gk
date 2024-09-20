<Query Kind="Program" />

using System.Threading;

const int total = 100_000;
int count = 0;

void Main()
{
	// 这边会造成 Count 实际算出的值没办法变为 2*100_000;
	// var thread1 = new Thread(ThreadMethodNotSafe);
	// var thread2 = new Thread(ThreadMethodNotSafe);

	var thread1 = new Thread(ThreadMethodSafe);
	var thread2 = new Thread(ThreadMethodSafe);

	thread1.Start();
	thread2.Start();
	
	thread1.Join();
	thread2.Join();
	
	$"Not Safe Count:{count}".Dump();
	
}

public void ThreadMethodNotSafe()
{
	for (int i = 0; i < total; i++)
	{
		// xxx++ 非原子操作
		count++;
	}
}

public void ThreadMethodSafe(){
	for (int i = 0; i < total; i++)
	{
		Interlocked.Increment(ref count);
	}
}