<Query Kind="Statements">
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>System.Net.Http</Namespace>
</Query>

public class Demo
{
	async Task FooAsync(CancellationToken cancellationToken)
	{
		await Task.Delay(5000, cancellationToken);
		"Test".Dump();
		var client = new HttpClient();
		await client.GetStringAsync("http://localhost:5000", cancellationToken);
	}

	Task FooAsync()=>FooAsync(CancellationToken.None);
	
	async Task Foo2Async(CancellationToken? cancellationToken = null){
		var token = cancellationToken??CancellationToken.None;
		await Task.Delay(2000,token);
	}

	Task Foo3Async(CancellationToken cancellationToken)
	{
		return Task.Run(() => {
		
			if(cancellationToken.IsCancellationRequested)
				cancellationToken.ThrowIfCancellationRequested();
		
			while (!cancellationToken.IsCancellationRequested)
			{
				Thread.Sleep(3000);
				"Pooling....".Dump();
			}
		
		});
	}

	Task<string> Foo4Async(CancellationToken cancellationToken)
	{
		var task = new Task(() => {});
		
		if(cancellationToken.IsCancellationRequested)
			return Task.FromCanceled<string>(cancellationToken);
			
		return Task.FromResult("Done");
	}
}