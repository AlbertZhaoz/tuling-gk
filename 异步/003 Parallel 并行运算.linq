<Query Kind="Program" />

void Main()
{
	var inputs = Enumerable.Range(1, 100).ToArray();
	var sw = Stopwatch.StartNew();
	inputs.ToList().Select(i => HeavyJob(i)).Dump();
	
	//inputs.AsParallel().AsOrdered().Select(i => HeavyJob(i)).Dump();
	sw.ElapsedMilliseconds.Dump();
}

// You can define other methods, fields, classes and namespaces here
int HeavyJob(int input)
{
	Thread.Sleep(100);
	return input * input;
}