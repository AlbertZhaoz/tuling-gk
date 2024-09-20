<Query Kind="Program" />

private Semaphore sema = new Semaphore(1,1);

void Main()
{
	var inputs = Enumerable.Range(1,100).ToArray();
	
	var arr = inputs.AsParallel().AsOrdered().Select(i => HeavyJob(i)).ToArray();
	
	string.Join(',',arr).Dump();
}

private int HeavyJob(int num){
	sema.WaitOne();
	
	Thread.Sleep(20);
	
	sema.Release();

	return num*num;
}

