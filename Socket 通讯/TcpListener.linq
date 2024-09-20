<Query Kind="Program">
  <Namespace>System.Net.Sockets</Namespace>
  <Namespace>System.Net</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var networkStreams = new List<NetworkStream>();
	
	var tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"),9998);
	tcpListener.Start(10);
	"启动服务 127.0.0.1:9999,等待客户端连接".Dump();
	
	Task.Run(async () => {

		var tcpClient = await tcpListener.AcceptTcpClientAsync();
		$"{tcpClient.Client.RemoteEndPoint}上线了".Dump();
		// 等待客户端连接
		while (true)
		{
			
			var networkStream = tcpClient.GetStream();
			networkStreams.Add(networkStream);

			try
			{
				var buffer = new byte[1024 * 1024];
				var readLen =networkStream.Read(buffer,0,buffer.Length);
				
				if(readLen == 0){
					$"{tcpClient.Client.RemoteEndPoint}下线了".Dump();
					networkStreams.Remove(networkStream);
					networkStream.Close();
					tcpClient.Close();
					return;
				}

				$"{tcpClient.Client.RemoteEndPoint}:{Encoding.UTF8.GetString(buffer,0,readLen)}".Dump();
			}
			catch
			{

			}
		}

	});

	while (true)
	{
		foreach (var element in networkStreams)
		{
			element.Write(Encoding.UTF8.GetBytes($"DateTime is {DateTime.Now}"));
		}
		Thread.Sleep(5000);
	}
}

