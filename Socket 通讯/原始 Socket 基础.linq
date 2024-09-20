<Query Kind="Program">
  <NuGetReference>Masuit.Tools.Core</NuGetReference>
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

async void Main()
{
	var cts = new CancellationTokenSource();

	var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
	socket.Connect("127.0.0.1", 9999);
	var buffer = new byte[1024];

	try
	{
		var thread = new Thread(() =>
		{
			Thread.Sleep(20*1000);
			cts.Cancel();
		});
		thread.Start();


		while (!cts.Token.IsCancellationRequested)
		{
			await socket.SendAsync(Encoding.UTF8.GetBytes($"Hi Bob {DateTime.Now}"));

			await socket.ReceiveAsync(buffer);

			Encoding.UTF8.GetString(buffer).Dump();

			await Task.Delay(2000);
		}

		socket?.Close();
	}
	catch (Exception ex)
	{
		ex.Message.Dump();
		socket?.Close();
	}
	
}

