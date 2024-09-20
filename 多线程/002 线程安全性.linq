<Query Kind="Program" />

int count;

void Main()
{
	var thread1 = new Thread(ThreadMethodSafe);
	var thread2 = new Thread(ThreadMethodSafe);
	
	thread1.Start();
	thread2.Start();
	
	thread1.Join();
	thread2.Join();
	
	count.Dump();
}


void ThreadMethodNotSafe(){
	for (int i = 0; i < 1000_000; i++)
	{
		count++;
	}
}

void ThreadMethodSafe()
{
	for (int i = 0; i < 1000_000; i++)
	{
		Interlocked.Increment(ref count);
	}
}
