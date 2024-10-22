<Query Kind="Statements">
  <Namespace>System.Collections.Concurrent</Namespace>
</Query>

var queue = new BlockingCollection<Message>(new ConcurrentQueue<Message>());

var sendThread1 = new Thread(SendMessageThread);
var receiveThread1 = new Thread(ReceiveMessageThread);

sendThread1.Start(1);
receiveThread1.Start(1);

sendThread1.Join();
// make sure all messages are received
Thread.Sleep(100);
receiveThread1.Interrupt();
receiveThread1.Join();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

void SendMessageThread(object? arg)
{
	int id = (int)arg!;

	for (int i = 1; i <= 20; i++)
	{
		queue.Add(new Message(id, i.ToString()));
		Console.WriteLine($"Thread {id} sent {i}");
		Thread.Sleep(100);
	}
}

void ReceiveMessageThread(object? id)
{
	try
	{
		while (true)
		{
			var message = queue.Take();
			Console.WriteLine($"Thread {id} received {message.Content} from {message.FromId}");
			Thread.Sleep(1);
		}
	}
	catch (ThreadInterruptedException)
	{
		Console.WriteLine($"Thread {id} interrupted");
	}
}

record Message(int FromId, string Content);