<Query Kind="Program" />

void Main()
{
	var inputs = Enumerable.Range(1,100).ToArray();
	
	var sw = Stopwatch.StartNew();
	
	// 100*100 =10s
	//inputs.ToList().Select(i => HeavyJob(i)).Dump();
	inputs.AsParallel().AsOrdered().Select(i => HeavyJob(i)).Dump();
	
	sw.ElapsedMilliseconds.Dump();
}

int HeavyJob(int input){
	Thread.Sleep(100);
	
	return input*input;
}

