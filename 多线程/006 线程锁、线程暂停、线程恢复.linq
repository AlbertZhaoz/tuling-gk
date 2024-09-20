<Query Kind="Program" />

void Main()
{
	var thread = new Thread(() => {
	
	try
	{	        
		for (int i = 0; i < 20000; i++)
		{
			Thread.Sleep(0);
			
			"Thread is still running".Dump();
		}
	}
	catch (Exception ex)
	{
		ex.Dump();
	}
	
	});
	
	thread.Start();
	
	thread.Suspend();
	thread.Resume();
	
	"Main thread,waiting for thread to finish".Dump();
	thread.Interrupt();
	"Main monitor thread is over".Dump();
}

