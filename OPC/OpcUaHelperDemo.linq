<Query Kind="Program">
  <NuGetReference>OpcUaHelper</NuGetReference>
  <Namespace>OpcUaHelper</Namespace>
  <Namespace>Opc.Ua</Namespace>
  <Namespace>Opc.Ua.Client</Namespace>
</Query>

async void Main()
{
	OpcUaClient m_OpcUaClient = new OpcUaClient();
	m_OpcUaClient.UserIdentity = new UserIdentity(new AnonymousIdentityToken());

	// connect to server, this is a sample
	try
	{
		await m_OpcUaClient.ConnectServer("opc.tcp://127.0.0.1:49320/Kepware.KEPServerEX.V6");
		
		// 读取值
		var address = "ns=2;s=ModbusRtu.ModbusRtuOne.温度数据"; 
		var addressPressure = "ns=2;s=ModbusRtu.ModbusRtuOne.压力数据"; 
		// ns=2;s=Devices/分厂一/车间二/ModbusTcp客户端/温度
		var value1 = m_OpcUaClient.ReadNode<ushort>(address);
		
		value1.Dump("温度-1数据");
		
		ushort value2 = await m_OpcUaClient.ReadNodeAsync<ushort>( address);
		value2.Dump("温度-2数据");
		
		m_OpcUaClient.WriteNode(address, (ushort)58);

		// 批量读取
		//List<NodeId> nodeIds = new List<NodeId>();
		//nodeIds.Add(new NodeId(address));
		//nodeIds.Add(new NodeId(addressPressure));
		//// dataValues按顺序定义的值，每个值里面需要重新判断类型
		//List<DataValue> dataValues = m_OpcUaClient.ReadNodes(nodeIds.ToArray());

		// 如果你批量读取的值的类型都是一样的，比如float，那么有简便的方式
		List<string> tags = new List<string>();
		tags.Add(address);
		tags.Add(addressPressure);

		// 按照顺序定义的值
		List<ushort> values = m_OpcUaClient.ReadNodes<ushort>(tags.ToArray());
		values.Dump();

		// //此处演示写入一个short，2个float类型的数据批量写入操作
		//bool success = m_OpcUaClient.WriteNodes(new string[] {
		//"ns=2;s=Devices/分厂一/车间二/ModbusTcp客户端/温度",
		//"ns=2;s=Devices/分厂一/车间二/ModbusTcp客户端/风俗",
		//"ns=2;s=Devices/分厂一/车间二/ModbusTcp客户端/转速"},
		//	new object[] {
		//	(short)1234,
		//	123.456f,
		//	123f
		//	});
		//if (success)
		//{
		//	 写入成功
		//}
		//else
		//{
		//	 写入失败，一个失败即为失败
		//}
		
		m_OpcUaClient.AddSubscription( "A", address, SubCallback );
		
		
	}
	catch (Exception ex)
	{
		ex.Message.Dump();
	}
}

void SubCallback(string key, MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs args )
{
	if (key == "A")
	{
		// 如果有多个的订阅值都关联了当前的方法，可以通过key和monitoredItem来区分
		MonitoredItemNotification notification = args.NotificationValue as MonitoredItemNotification;
		if (notification != null)
		{
			notification.Value.WrappedValue.Value.ToString().Dump("订阅");
		}
	}
}

