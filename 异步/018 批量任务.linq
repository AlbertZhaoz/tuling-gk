<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	var inputs = Enumerable.Range(1,10).ToArray();
	
	// 下面的写法并不会缩短时间，而是会一直等待
	// 当主线程方法执行到 HeavyJob 时，会切换到子线程，子线程发现要等待，
	// 跳转到主线程，主线程又进入，又会切换到子线程，子线程依旧发现要等待
	// 这样子线程就会一直等待。
	//var outputs = new List<int>();
	//
	//foreach (var element in inputs)
	//{
	//	var output = await HeavyJob(element);
	//	outputs.Add(output);
	//}
	//
	//outputs.Dump();
	
	// 并行任务一起运行，批量创建一堆 Task，而不是一个 Task
	var tasks = new List<Task<int>>();
	
	foreach (var element in inputs)
	{
		tasks.Add(HeavyJob(element));
	}
	
	// 等待所有 Task 执行完成，再去获取其值，不要不加这行，直接写下面
	// 获取 Task.Result 值的方式。
	await Task.WhenAll(tasks);
	
	// 最起码等待 1s，我们调用 t.Result 的适合任务并没有完成
	// 会阻塞
	var outputs = tasks.Select(t => t.Result).ToArray();
	outputs.Dump();
}


async Task<int> HeavyJob(int input){
	await Task.Delay(2000);
	
	return input*input;
}
