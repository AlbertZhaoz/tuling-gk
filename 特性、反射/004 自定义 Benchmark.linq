<Query Kind="Program" />

void Main()
{
	BenchmarkRunner<SimpleTester>();
	BenchmarkRunner(typeof(SimpleTester));
}

void BenchmarkRunner<T>(int count = 10_000_000) where T:new(){
	var obj = new T();
	
	var methods = typeof(T)
		.GetMethods()
		.Where(o => o.GetCustomAttribute<BenchmarkAttribute>() is not null);
		
	foreach (var method in methods)
	{
		var sw = Stopwatch.StartNew();
		
		for(int i=0;i < count;i++){
			method.Invoke(obj,null);
		}
		
		sw.ElapsedMilliseconds.Dump(method.Name);
	}
}

void BenchmarkRunner(Type type,int count = 10_000_000)
{
	var obj = Activator.CreateInstance(type);

	var methods = type
		.GetMethods()
		.Where(o => o.GetCustomAttribute<BenchmarkAttribute>() is not null);

	foreach (var method in methods)
	{
		var sw = Stopwatch.StartNew();

		for (int i = 0; i < count; i++)
		{
			method.Invoke(obj, null);
		}

		sw.ElapsedMilliseconds.Dump(method.Name);
	}
}

public class SimpleTester{
	private IEnumerable<int> testList = Enumerable.Range(1,10).ToArray();
	
	[Benchmark]
	public int CalcMinByLinq(){
		return testList.Min();
	}

	[Benchmark]
	public int CalcManByLinq()
	{
		return testList.Max();
	}
}

[AttributeUsage(AttributeTargets.Method)]
public class BenchmarkAttribute:Attribute{
	
}