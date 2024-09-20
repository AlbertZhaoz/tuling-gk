<Query Kind="Program" />

void Main()
{
	var th = new Thread(obj =>
	{
		obj.Dump();

		try
		{
			for (int i = 0; i < 20; i++)
			{
				Thread.Sleep(200);
				"Thread is still running....".Dump();
			}
		}
		catch (ThreadInterruptedException ex)
		{
			ex.Message.Dump();
		}
		finally
		{
			"关闭某些资源".Dump();
		}

	})
	{
		IsBackground = true,
		Priority = ThreadPriority.Highest
	};

	th.Start(123);
	"Main thread,waiting for thread to finish...".Dump();
	Thread.Sleep(1000);
	th.Interrupt();
	"Done.".Dump();
}