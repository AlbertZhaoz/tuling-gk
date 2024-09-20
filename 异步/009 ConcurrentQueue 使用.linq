<Query Kind="Program">
  <Namespace>System.Collections.Concurrent</Namespace>
</Query>

private ConcurrentQueue<int> cQueue = new ConcurrentQueue<int>();

void Main()
{
	var producer = new Thread(AddNumbers);
	var consumer1 = new Thread(ReadNumbers);
	var consumer2 = new Thread(ReadNumbers);
	
	producer.Start();
	consumer1.Start();
	consumer2.Start();
	
	producer.Join();
	consumer1.Join();
	consumer2.Join();
	Console.WriteLine("Done");
}

void AddNumbers(){
	for (int i = 0; i < 20; i++)
	{
		Thread.Sleep(20);
		cQueue.Enqueue(i);
	}
}

void ReadNumbers(){
	try
	{	        
		while (true)
		{
			if(cQueue.TryDequeue(out var result)){
				result.Dump();
			}
			
			Thread.Sleep(1);
		}
	}
	catch (ThreadInterruptedException ex)
	{
		ex.Message.Dump();
	}
}