<Query Kind="Expression" />

private Queue<int> queue = new Queue<int>();
private object obj = new();


void Main()
{
	var producer = new Thread(Producer);
	var consumer1 = new Thread(Consumer);
	var consumer2 = new Thread(Consumer);

	producer.Start();
	consumer1.Start();
	consumer2.Start();

	Thread.Sleep(1000);

	consumer1.Interrupt();
	consumer2.Interrupt();
}

void Producer()
{
	for (int i = 0; i < 20; i++)
	{
		Thread.Sleep(20);

		queue.Enqueue(i);
	}
}

void Consumer()
{
	try
	{
		while (true)
		{
			lock (obj)
			{
				if (queue.TryDequeue(out var result))
				{
					result.Dump();
				}

				Thread.Sleep(10);
			}
		}

	}
	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}

