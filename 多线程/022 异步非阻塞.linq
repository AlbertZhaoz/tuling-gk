<Query Kind="Program">
  <Namespace>System.Runtime.CompilerServices</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	Helper.PrintThreadId("Main Before");
	await FooAsync();
	Helper.PrintThreadId("Main After");
}

// You can define other methods, fields, classes and namespaces here
async Task FooAsync(){
	Helper.PrintThreadId("Before");
	// 如果是有同步上下文可以配置 ConfigureAwait(true)
	// 来实现返回到原先的线程
	await Task.Delay(1000);
	Helper.PrintThreadId("After");
}


class Helper{
	private static int index = 1;
	
	public static void PrintThreadId(string? message=null,[CallerMemberName]string? name =null){
		var title = $"{index}:{name}";
		
		if(!string.IsNullOrEmpty(message))
			title+= $"@{message}";
		
		Environment.CurrentManagedThreadId.Dump(title);
		Interlocked.Increment(ref index);
	}
}
