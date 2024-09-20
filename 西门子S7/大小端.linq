<Query Kind="Program">
  <NuGetReference>HslCommunication</NuGetReference>
  <Namespace>HslCommunication.Core</Namespace>
</Query>

void Main()
{
	////C# 获取字节数组
	//BitConverter.GetBytes((short)-100).Dump();
	//BitConverter.GetBytes((short)100).Dump();
	//BitConverter.GetBytes((ushort)100).Dump();
	//BitConverter.GetBytes((int)100).Dump();

	// 0x64 0x32 0x024 0x16
	// 小端：从低位到高位排布 0x16 0x024 0x32 0x64,典型代表 C# 语言、三菱 PLC
	// 大端：从高位到地位排布 0x64 0x32 0x024 0x16,典型代表 西门子 PLC
	// 不规则：典型代表 Modbus 设备
	byte[] buffer = new byte[4] { 0x64, 0x00, 0x00, 0x00 };
	HslCommunication.Core.RegularByteTransform regular = new HslCommunication.Core.RegularByteTransform(); // 小端
	int data_regular = regular.TransInt32(buffer, 0);   // 这样就是100
	data_regular.Dump();

	HslCommunication.Core.ReverseBytesTransform reverse = new HslCommunication.Core.ReverseBytesTransform(); // 大端
	int data_reverse = reverse.TransInt32(buffer, 0);   // 这样就是1677721600
	data_reverse.Dump();


	HslCommunication.Core.ReverseWordTransform reverseWord = new ReverseWordTransform();
	reverseWord.DataFormat = DataFormat.ABCD;
	int data_abcd = reverseWord.TransInt32(buffer, 0);  // 1677721600
	data_abcd.Dump();
	BitConverter.GetBytes((int)1677721600).Dump();

	reverseWord.DataFormat = DataFormat.BADC;
	int data_badc = reverseWord.TransInt32(buffer, 0);  // 6553600
	data_badc.Dump();
	BitConverter.GetBytes((int)6553600).Dump();

	reverseWord.DataFormat = DataFormat.CDAB;
	int data_cdab = reverseWord.TransInt32(buffer, 0);  // 25600
	data_cdab.Dump();
	BitConverter.GetBytes((int)25600).Dump();

	reverseWord.DataFormat = DataFormat.DCBA;
	int data_dcba = reverseWord.TransInt32(buffer, 0);  // 100
}

// You can define other methods, fields, classes and namespaces here