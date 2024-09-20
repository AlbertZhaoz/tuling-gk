<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var task = Task.Run(async () =>
	{
		Environment.CurrentManagedThreadId.Dump("Task 进入前线程");
		await Task.Delay(1500);
		Environment.CurrentManagedThreadId.Dump("Task 延迟后线程");
		return "Done";
	});
	Environment.CurrentManagedThreadId.Dump("主线程");
	task.Status.Dump();
	Thread.Sleep(1000);
	Environment.CurrentManagedThreadId.Dump("线程-1");
	task.Status.Dump();
	Thread.Sleep(2000);
	Environment.CurrentManagedThreadId.Dump("线程-2");
	task.Status.Dump();
	task.Result.Dump("Result");
}

// You can define other methods, fields, classes and namespaces here
