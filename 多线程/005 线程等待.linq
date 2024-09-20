<Query Kind="Program" />

void Main()
{
	var thread = new Thread(() => {
		Thread.Sleep(2000);
		"Active".Dump();
	});
	
	thread.Start();
	
	thread.Join();
	
	"Main".Dump();
}

