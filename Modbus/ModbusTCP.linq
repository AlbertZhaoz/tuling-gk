<Query Kind="Program">
  <NuGetReference>HslCommunication</NuGetReference>
</Query>

async void Main()
{
	var modbus = new HslCommunication.ModBus.ModbusTcpNet();
	
	modbus.IpAddress = "127.0.0.1";
	modbus.Port = 502;
	modbus.ConnectTimeOut = 10000;
	modbus.ReceiveTimeOut = 5000;
	modbus.Station = 1;
	modbus.AddressStartWithZero = true;
	modbus.IsCheckMessageId = true;
	modbus.IsStringReverse = false;
	modbus.DataFormat = HslCommunication.Core.DataFormat.CDAB;
	
	var connectResult = await modbus.ConnectServerAsync();
	
	if(connectResult.IsSuccess){
		var contentResult = await modbus.ReadInt16Async("0",8);
		
		if(contentResult.IsSuccess){
			contentResult.Content.Dump();
			
			await modbus.WriteAsync("9",88);
		}
	}
}

