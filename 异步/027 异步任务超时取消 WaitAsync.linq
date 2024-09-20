<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

var cts = new CancellationTokenSource();

try
{	        
	await FooAsync(cts.Token).WaitAsync(TimeSpan.FromSeconds(2));
}
catch (TimeoutException ex)
{
	cts.Cancel();
	"Timeout...".Dump();
}
finally{
	cts.Dispose();
}



async Task FooAsync(CancellationToken token)
{
	try
	{
		"Foo Started...".Dump();
		await Task.Delay(5000, token);
		"Foo End...".Dump();
	}
	catch (OperationCanceledException ex)
	{
		ex.Dump("Foo canceled....");
	}
}