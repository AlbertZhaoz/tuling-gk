<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));

// 也能实现超时取消
//cts.CancelAfter(3000); 

var token = cts.Token;
var sw = Stopwatch.StartNew();

try
{
	var delayTask = Task.Delay(5000, token);
	await delayTask;
}
catch (TaskCanceledException ex)
{
	ex.Dump();
}
finally
{
	// 如果在一个作用域内可以使用 using var cts = new xxx
	cts.Dispose();
}

$"Task completed in {sw.ElapsedMilliseconds}".Dump();