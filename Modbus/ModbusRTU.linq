<Query Kind="Program">
  <NuGetReference>HslCommunication</NuGetReference>
</Query>

async void Main()
{
	var modbus = new HslCommunication.ModBus.ModbusRtu();

	modbus.SerialPortInni(sp =>
	{
		sp.PortName = "COM2";
		sp.BaudRate = 9600;
		sp.DataBits = 8;
		sp.StopBits = System.IO.Ports.StopBits.One;
		sp.Parity = System.IO.Ports.Parity.None;
		sp.RtsEnable = false;
	}
	);
	
	modbus.ReceiveTimeOut = 5000;
	// 有些工业设备从 1 开始，将下面的属性变为 false 即可
	modbus.AddressStartWithZero = true;
	modbus.DataFormat = HslCommunication.Core.DataFormat.CDAB;
	modbus.Station = 1;
	modbus.Crc16CheckEnable = true;
	modbus.IsClearCacheBeforeRead = false;
	
	var openResult = modbus.Open();
	
	if(openResult.IsSuccess){
		"Modbus 已经打开通讯上了".Dump();
		
		var result =await modbus.ReadInt16Async("0",10);
		
		if(result.IsSuccess){
			result.Content.Dump();
			
			await modbus.WriteAsync("0",55);
		}
	}
}

