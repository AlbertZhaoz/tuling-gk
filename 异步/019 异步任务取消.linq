<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var cts = new CancellationTokenSource();
	
	try
	{
		var task = Task.Delay(10000, cts.Token);

		Thread.Sleep(2000);
		cts.Cancel();

		// 检查到 task 会立马开始切换线程执行，
		// 在执行过程中主线程刚开始还在 Sleep
		// 等 Sleep 结束，cts 取消，异步任务收到
		// 取消令牌则会直接取消
		await task;
	}
	catch (TaskCanceledException ex)
	{
		ex.Message.Dump();
	}
	finally{
		cts.Dispose();
	}		
}

