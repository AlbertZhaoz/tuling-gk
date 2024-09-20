<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

// 两个收费站，一次可以过两个人
var sem = new SemaphoreSlim(2, 2);

var inputs = Enumerable.Range(1, 10).ToArray();

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


async Task<int> HeavyJob(int input){
	await sem.WaitAsync();

	await Task.Delay(1000);
	
    sem.Release();
	
	return input*input;
}
