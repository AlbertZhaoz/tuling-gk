<Query Kind="Program" />

void Main()
{
	var thread = new Thread(() => {
		"Start...".Dump();
		
		Thread.Sleep(5000);
		
		"Active".Dump();
	});
	
	thread.Start();
	thread.Join(2000);
	"Main".Dump();
}

