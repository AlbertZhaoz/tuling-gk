<Query Kind="Program" />

private Semaphore sema = new Semaphore(3,3);

void Main()
{
	var inputs = Enumerable.Range(1, 100).ToArray();
	var sw = Stopwatch.StartNew();
	var arr = inputs.AsParallel().AsOrdered().Select(i => HeavyJob(i)).ToArray();
	string.Join(',',arr).Dump();
	sw.ElapsedMilliseconds.Dump();
	sema.Dispose();
}

int HeavyJob(int input)
{
	sema.WaitOne();
	Thread.Sleep(300);
	sema.Release();
	(input*input).Dump();
	return input * input;
}