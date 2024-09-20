<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	try
	{	        
		VoidAsync();
	}
	catch (Exception ex)
	{
		// 无法捕获异常，根本就不在同一个线程上了
		ex.Message.Dump();
	}
}

// You can define other methods, fields, classes and namespaces here
async void VoidAsync(){
	await Task.Delay(1000);
	throw new Exception("something was wrong");
}
