<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var task = new Task<string>(() => {
		Thread.Sleep(1500);
		return "Done";
	});
	
	task.Status.Dump();
	task.Start();
	task.Status.Dump();
	Thread.Sleep(1000);
	task.Status.Dump();
	Thread.Sleep(2000);
	task.Status.Dump();
	task.Result.Dump("Result");
}