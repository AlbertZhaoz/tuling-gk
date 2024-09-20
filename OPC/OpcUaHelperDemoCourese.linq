<Query Kind="Program">
  <NuGetReference>OpcUaHelper</NuGetReference>
  <Namespace>OpcUaHelper</Namespace>
  <Namespace>Opc.Ua</Namespace>
  <Namespace>Opc.Ua.Client</Namespace>
</Query>

async void Main()
{
	try
	{
		var opcUaClient = new OpcUaClient();
		// 匿名登录，无需用户名和密码
		// opcUaClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());
		// 用户名密码方式
		opcUaClient.UserIdentity = new UserIdentity("Tuling","Tuling");
		
		var serverAddress = "opc.tcp://127.0.0.1:49320/Kepware.KEPServerEX.V6";
		await opcUaClient.ConnectServer(serverAddress);
		
		"OPC UA 连接成功".Dump();
		
		// 读取数据
		var address1 = "ns=2;s=ModbusRtu.ModbusRtuOne.温度数据";
		var addressValue1 = await opcUaClient.ReadNodeAsync<ushort>(address1);
		addressValue1.Dump("温度数据");
		
		// 批量读取
		var address2 = "ns=2;s=ModbusRtu.ModbusRtuOne.压力数据";
		var tags = new List<string>();
		tags.Add(address1);
		tags.Add(address2);
		var valueList = await opcUaClient.ReadNodesAsync<ushort>(tags.ToArray());
		valueList.Dump("批量读取的值");
		
		// 如果批量读取的类型不一样
		//var nodeIds = new List<NodeId>();
		//nodeIds.Add(new NodeId(address1));
		//nodeIds.Add(new NodeId(address2));
		//var dataValues = await opcUaClient.ReadNodesAsync(nodeIds.ToArray());
		
		// 单点写入
		var random = new Random();
		var randomValue = random.Next(1,10);
		await opcUaClient.WriteNodeAsync(address1,(ushort)randomValue);

		// 批量写入
		var isWriteSuccess = opcUaClient.WriteNodes(
		new string[] {
			address1,address2
		}, new object[] {(ushort)22,(ushort)23}
		);
		
	    if(isWriteSuccess){
			"批量写入成功".Dump();
		}

		// 订阅模式
		opcUaClient.AddSubscription("A",address1,SubCallBack);

		// 读取历史 History Data Access
		var valueHistroyList = opcUaClient.ReadHistoryRawDataValues<ushort>(address1,
		new DateTime(2024, 7, 2), new DateTime(2024, 7, 13), 2).ToList();
		valueHistroyList.Dump("历史数据");

	}

	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}

void SubCallBack(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args)
{
	if(key == "A"){
		var notification = args.NotificationValue as MonitoredItemNotification;
		
		if(notification != null){
			notification.Value.WrappedValue.Value.ToString().Dump("来自订阅的温度数据");
		}
	}
}


