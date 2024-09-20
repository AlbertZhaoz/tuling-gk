<Query Kind="Program" />

void Main()
{
	var th = new Thread(obj =>
	{
		obj.Dump();

		for (int i = 0; i < 20; i++)
		{
			Thread.Sleep(200);
			"Thread is still running....".Dump();
		}
	})
	{
		IsBackground = true,
		Priority = ThreadPriority.Highest
	};

	th.Start(123);
	"Main thread,waiting for thread to finish...".Dump();
	th.Join();
	"Done.".Dump();
}