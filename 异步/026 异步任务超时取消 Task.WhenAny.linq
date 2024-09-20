<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>


try
{	        
	await FooAsync(CancellationToken.None).TimeoutAfter(TimeSpan.FromSeconds(2));
}
catch (Exception ex)
{
	"Timeout".Dump();
}



async Task FooAsync(CancellationToken token){
	try
	{	        
		"Foo Started...".Dump();
		await Task.Delay(5000,token);
		"Foo End...".Dump();
	}
	catch (OperationCanceledException ex)
	{
		ex.Dump("Foo canceled....");
	}
}

static class AsyncExtensions{
	public static async Task<TResult> TimeoutAfter<TResult>(this Task<TResult> task,
	TimeSpan timeout){
		using var cts = new CancellationTokenSource();
		var completedTask = await Task.WhenAny(task,Task.Delay(timeout,cts.Token));
		
		if(completedTask != task){
			cts.Cancel();
			throw new TimeoutException();
		}
		
		return await task;
	}

	public static async Task TimeoutAfter(this Task task,
	TimeSpan timeout)
	{
		using var cts = new CancellationTokenSource();
		var completedTask = await Task.WhenAny(task, Task.Delay(timeout, cts.Token));

		if (completedTask != task)
		{
			cts.Cancel();
			throw new TimeoutException();
		}
		
		await task;
	}
}