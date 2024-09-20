<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var cts = new CancellationTokenSource();
var token = cts.Token;
var sw = Stopwatch.StartNew();

try
{
	var cancelTask = Task.Run(async() =>
	{
		await Task.Delay(2000);
		cts.Cancel();
	});
	var delayTask = Task.Delay(5000, token);
	await delayTask;

	await Task.WhenAll(cancelTask, delayTask);
}
catch (TaskCanceledException ex)
{
	ex.Dump();
}
finally{
    // 如果在一个作用域内可以使用 using var cts = new xxx
	cts.Dispose();
}

$"Task completed in {sw.ElapsedMilliseconds}".Dump();