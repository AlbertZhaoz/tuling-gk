<Query Kind="Program">
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var tcpClient = new TcpClient();
	
	try
	{
		tcpClient.Connect(IPAddress.Parse("127.0.0.1"), 9998);
		"连接成功".Dump();
		var networkStream = tcpClient.GetStream();

		// 连接上后首先给服务端发送一条消息
		if (networkStream.CanWrite)
		{

			var buffer = Encoding.UTF8.GetBytes("Hi Server,I'm tcp client");
			networkStream.Write(buffer);
		}

		Task.Run(async () =>
		{
			while (networkStream.CanRead)
			{
				var buffer = new byte[1024 * 1024];
				var readLen = networkStream.Read(buffer, 0, buffer.Length);

				if (readLen == 0)
				{
					"断开连接".Dump();
					networkStream.Close();
				}

				Encoding.UTF8.GetString(buffer).Dump();
			}

		});
	}
	catch (Exception ex)
	{
		tcpClient?.Close();
		tcpClient?.Dispose();
	}
}

