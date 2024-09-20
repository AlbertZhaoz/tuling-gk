<Query Kind="Program">
  <NuGetReference>S7netplus</NuGetReference>
  <Namespace>S7.Net</Namespace>
</Query>

void Main()
{
	using (var plc = new Plc(CpuType.S71200, "127.0.0.1", 0, 1))
	{
		try
		{
			plc.Open();
			
			if(plc.IsConnected){
				"PLC 已经连接上了".Dump();
				
				bool db1Bool1 = (bool)plc.Read("DB1.DBX0.1");
				
				if(db1Bool1){
					"报警开启了".Dump();
					
					plc.Write("DB1.DBX0.2", true);
				}
				else{
					"报警未开启".Dump();
				}

				var bytes = plc.ReadBytes(DataType.DataBlock, 1, 0, 18);
				Console.WriteLine(bytes);

				var bool1 = bytes[0].SelectBit(0);
				Console.WriteLine("DB1.DBX0.0: " + bool1);
				var bool2 = bytes[0].SelectBit(1);
				Console.WriteLine("DB1.DBX0.0: " + bool2);

				// Int
				int intVariable = S7.Net.Types.Int.FromByteArray(bytes.Skip(2).Take(2).ToArray());
				Console.WriteLine("DB1.DBD2.0: " + intVariable);
				//  Real
				Double realVariable = S7.Net.Types.Double.FromByteArray(bytes.Skip(4).Take(4).ToArray());
				Console.WriteLine("DB1.DBD4.0: " + realVariable);

				// DWord
				uint dWordVariable = S7.Net.Types.DWord.FromByteArray(bytes.Skip(12).Take(4).ToArray());
				Console.WriteLine("DB1.DBD12.0: " + dWordVariable);
				// Word
				var wordVariable = S7.Net.Types.Word.FromByteArray(bytes.Skip(16).Take(2).ToArray());
				Console.WriteLine("DB1.DBW16.0: " + wordVariable);
			}
		}
		catch (Exception)
		{
			Console.WriteLine($"连接到PLC设备失败：IsConnect={plc.IsConnected}");
			return;
		}
	}
}

