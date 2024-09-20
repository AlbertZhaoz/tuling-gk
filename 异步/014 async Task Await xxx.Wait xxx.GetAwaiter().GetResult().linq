<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async Task Main()
{
	try
	{
		// InnerException
		//await VoidAsync();
		
		// AggregationException
		//VoidAsync().Wait();
		
		// InnerException sync
		VoidAsync().GetAwaiter().GetResult();
	}
	catch (Exception ex)
	{
		ex.Dump();
	}
}

// You can define other methods, fields, classes and namespaces here
async Task VoidAsync()
{
	await Task.Delay(1000);
	throw new Exception("something was wrong");
}