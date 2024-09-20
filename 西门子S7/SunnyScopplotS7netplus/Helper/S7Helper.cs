using Sunny.UI;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System;
using System.ComponentModel;
using S7.Net;
using System.Linq;

namespace SunnyScopplotS7netplus
{
    public class S7Helper
    {
        Plc _plc;
        List<Type> _S7structType = new List<Type>();
        List<S7structmatch> _S7structmatch = new List<S7structmatch>();
        S7structmatch _structmatch;
        private CpuType _plcType;
        private string _plcIp;

        public static List<string> GetPlcTypes()
        {
            return EnumHelper.GetAllItemsNames<CpuType>();
        }

        public bool Connected
        {
            get;
            private set;
        }
        /// <summary>
        /// 定义PLC
        /// </summary>
        /// <param name="S7TypeStr">S7200 S7300 S7400 S71200 S71500 </param>
        /// <param name="IP">IP地址</param>
        public S7Helper(string S7TypeStr, string IP)
        {
            _plcType = S7TypeStr.ToEnum<CpuType>();
            _plcIp = IP;
        }

        public bool ConnectPLC(int port, short rack, short slot)
        {
            Connected = false;
            try
            {
                _plc = new Plc(_plcType, _plcIp, port, rack, slot);
                _plc.WriteTimeout = 2000;
                _plc.ReadTimeout = 2000;
                _plc.Open();
                Connected = true;
            }
            catch (Exception ex)
            {
                HLog.Error($"PLC[IP={_plcIp} type={_plcType}]Connect Error", ex);
            }

            return Connected;
        }
        public bool DisconnectPLC()
        {
            try
            {
                if (_plc.IsConnected) _plc.Close();
                Connected = false;
                return true;
            }
            catch (Exception ex)
            {
                HLog.Error($"PLC[IP={_plcIp} type={_plcType}]Disonnect Error", ex);
                return false;
            }
        }

        public float ReadSingleData_Float(int DBindex, int Startindex, int location, PlcDataType type)
        {
            var obj = ReadSingleData(DBindex, Startindex, location, type);
            if (type == PlcDataType.Bool)
            {
                return ((bool)obj) ? 1f : 0f;
            }
            else
            {
                return (float)obj;
            }
        }

        /// <summary>
        /// 西门子读单一数据 bool int16  float
        /// </summary>
        /// <param name="DBindex">DB块索引</param>
        /// <param name="Startindex">字节起始位索引</param>
        /// <param name="type">数据类型</param>
        /// <param name="location">bool时 对应得0-7位地址</param>
        /// <returns></returns>
        public dynamic ReadSingleData(int DBindex, int Startindex, int location, PlcDataType type)
        {

            if (type == PlcDataType.Bool)
            {
                byte[] tempbyte = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, 1);
                bool resultbool = false;
                if (0 <= location && location < 8)
                {
                    if ((tempbyte[0] & (1 << location)) != 0) resultbool = true;
                }
                else
                {
                    if ((tempbyte[0] & (1 << 7)) != 0) resultbool = true;
                }
                return resultbool;
            }
            else if (type == PlcDataType.Byte)
            {
                byte[] tempbyte = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, 1);
                return tempbyte[0];
            }
            else if (type == PlcDataType.Int16)
            {
                byte[] tempbyte1 = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, 2);
                byte[] tempbyte2 = new byte[2];
                tempbyte2[0] = tempbyte1[1];
                tempbyte2[1] = tempbyte1[0];
                Int16 singledata = BitConverter.ToInt16(tempbyte2, 0);
                return singledata;
            }
            else if (type == PlcDataType.Int32)
            {
                byte[] tempbyte1 = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, 4);
                byte[] tempbyte2 = new byte[4];
                tempbyte2[0] = tempbyte1[3];
                tempbyte2[1] = tempbyte1[2];
                tempbyte2[2] = tempbyte1[1];
                tempbyte2[3] = tempbyte1[0];
                Int32 singledata = BitConverter.ToInt32(tempbyte2, 0);
                return singledata;
            }
            else
            {
                byte[] tempbyte1 = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, 4);
                byte[] tempbyte2 = new byte[4];
                tempbyte2[0] = tempbyte1[3];
                tempbyte2[1] = tempbyte1[2];
                tempbyte2[2] = tempbyte1[1];
                tempbyte2[3] = tempbyte1[0];
                Single singledata = BitConverter.ToSingle(tempbyte2, 0);
                return singledata;
            }
        }


        public bool WriteSingleData_Float(int DBindex, int Startindex, float data, int location, PlcDataType type)
        {
            try
            {
                dynamic obj = null;
                switch (type)
                {
                    case PlcDataType.Bool:
                        obj = data > 0;  //0 false  1 true
                        break;
                    case PlcDataType.Byte:
                        obj = (byte)data;
                        break;
                    case PlcDataType.Int16:
                        obj = (short)data;
                        break;
                    case PlcDataType.Int32:
                        obj = (int)data;
                        break;
                    case PlcDataType.Float:
                        obj = data;
                        break;
                }

                return WriteSingleData(DBindex, Startindex, obj, location);
            }
            catch (Exception ex)
            {
                HLog.Error($"WriteSingleData_Float error[db{DBindex} startIndex:{Startindex} dataType{type} data:{data} loc:{location}]", ex);
                return false;
            }
        }
        /// <summary>
        /// 西门子写单一数据bool int16  float
        /// </summary>
        /// <param name="DBindex">DB块索引</param>
        /// <param name="Startindex">字节起始位索引</param>
        /// <param name="data">数据</param>
        /// <param name="location">bool时 对应得0-7位地址</param>
        /// <returns></returns>
        public bool WriteSingleData(int DBindex, int Startindex, object data, int location)
        {
            Type type = data.GetType();
            try
            {
                //HLog.Debug($"WriteSingleData db{DBindex} startIndex:{Startindex} handleName:{hanldname} dataType{type} data:{data} loc:{location}");

                if (type == typeof(Boolean))
                {
                    bool Sendbool = (bool)data;
                    _plc.WriteBit(DataType.DataBlock, DBindex, Startindex, location, Sendbool);

                }
                else if (type == typeof(Byte))
                {
                    byte[] tempbyte = BitConverter.GetBytes((Byte)data);
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte);
                }
                else if (type == typeof(Int16))
                {
                    byte[] tempbyte1 = BitConverter.GetBytes((Int16)data);
                    byte[] tempbyte2 = new byte[2];
                    tempbyte2[0] = tempbyte1[1];
                    tempbyte2[1] = tempbyte1[0];
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte2);
                }
                else if (type == typeof(Int32))
                {
                    byte[] tempbyte1 = BitConverter.GetBytes((Int32)data);
                    byte[] tempbyte2 = new byte[4];
                    tempbyte2[0] = tempbyte1[3];
                    tempbyte2[1] = tempbyte1[2];
                    tempbyte2[2] = tempbyte1[1];
                    tempbyte2[3] = tempbyte1[0];
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte2);
                }
                else
                {
                    byte[] tempbyte1 = BitConverter.GetBytes((Single)data);
                    byte[] tempbyte2 = new byte[4];
                    tempbyte2[0] = tempbyte1[3];
                    tempbyte2[1] = tempbyte1[2];
                    tempbyte2[2] = tempbyte1[1];
                    tempbyte2[3] = tempbyte1[0];
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte2);
                }
                //HLog.Debug("WriteSingleData ok");
                return true;
            }
            catch (Exception ex)
            {
                HLog.Error($"WriteSingleData error[db{DBindex} startIndex:{Startindex} dataType{type} data:{data} loc:{location}]", ex);
                return false;
            }
        }
        //*************西门子读写数组*************
        /// <summary>
        /// 西门子读数组 bool[] int16[]  float[]
        /// </summary>
        /// <param name="DBindex">DB块索引</param>
        /// <param name="Startindex">字节起始位索引</param>
        /// <param name="type">数组类型</param>
        /// <param name="count">数组元素个数</param>
        /// <returns></returns>
        public dynamic ReadArrayData(int DBindex, int Startindex, Type type, int count)
        {
            if (type == typeof(Boolean[]))
            {

                bool[] Arraydata = new bool[count];
                int tempcount = (count / 16) * 2;
                if (count % 16 != 0) tempcount += 2;
                byte[] tempbyte = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, tempcount);
                for (int i = 0; i < count; i++)
                {
                    int bitwith = i % 8;
                    if ((tempbyte[i / 8] & (1 << bitwith)) == (1 << bitwith)) Arraydata[i] = true;
                    else Arraydata[i] = false;
                }
                return Arraydata;
            }
            else if (type == typeof(Byte[]))
            {
                byte[] tempbyte = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, count);
                return tempbyte;
            }
            else if (type == typeof(Int16[]))
            {
                byte[] tempbyte = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, count * 2);
                Int16[] Arraydata = (Int16[])BytesToArray(tempbyte, type);
                return Arraydata;
            }
            else if (type == typeof(Int32[]))
            {
                byte[] tempbyte = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, count * 4);
                Int32[] Arraydata = (Int32[])BytesToArray(tempbyte, type);
                return Arraydata;
            }
            else
            {
                byte[] tempbyte = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, count * 4);
                Single[] Arraydata = (Single[])BytesToArray(tempbyte, type);
                return Arraydata;
            }
        }
        /// <summary>
        /// 西门子写数组 bool[] int16[]  float[]
        /// </summary>
        /// <param name="DBindex">DB块索引</param>
        /// <param name="Startindex">字节起始位索引</param>
        /// <param name="data">数据</param>
        /// <param name="count">数组元素个数</param>
        /// <returns></returns>
        public bool WriteArrayData(int DBindex, int Startindex, object data, int count)
        {
            try
            {
                Type type = data.GetType();

                if (type == typeof(Boolean[]))
                {
                    int tempcount = (count / 16) * 2;
                    if (count % 16 != 0) tempcount += 2;

                    byte[] tempbyte = new byte[tempcount];
                    bool[] tempdata = (bool[])data;
                    for (int i = 0; i < count; i++)
                    {
                        int bitwith = i % 8;
                        if (tempdata[i])
                        {
                            tempbyte[i / 8] = (byte)(tempbyte[i / 8] | (1 << bitwith));
                        }
                    }
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte);

                }
                else if (type == typeof(Byte[]))
                {
                    byte[] tempbyte = (byte[])data;
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte);
                }
                else if (type == typeof(Int16[]))
                {
                    byte[] tempbyte2 = new byte[2 * count];
                    Int16[] tempdata = (Int16[])data;
                    for (int i = 0; i < count; i++)
                    {
                        byte[] tempbyte1 = BitConverter.GetBytes(tempdata[i]);
                        tempbyte2[i * 2] = tempbyte1[1];
                        tempbyte2[i * 2 + 1] = tempbyte1[0];
                    }
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte2);
                }
                else if (type == typeof(Int32[]))
                {
                    byte[] tempbyte2 = new byte[4 * count];
                    Int32[] tempdata = (Int32[])data;
                    for (int i = 0; i < count; i++)
                    {
                        byte[] tempbyte1 = BitConverter.GetBytes(tempdata[i]);
                        tempbyte2[i * 4] = tempbyte1[3];
                        tempbyte2[i * 4 + 1] = tempbyte1[2];
                        tempbyte2[i * 4 + 2] = tempbyte1[1];
                        tempbyte2[i * 4 + 3] = tempbyte1[0];
                    }
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte2);
                }
                else
                {
                    byte[] tempbyte2 = new byte[4 * count];
                    Single[] tempdata = (Single[])data;
                    for (int i = 0; i < count; i++)
                    {
                        byte[] tempbyte1 = BitConverter.GetBytes(tempdata[i]);
                        tempbyte2[i * 4] = tempbyte1[3];
                        tempbyte2[i * 4 + 1] = tempbyte1[2];
                        tempbyte2[i * 4 + 2] = tempbyte1[1];
                        tempbyte2[i * 4 + 3] = tempbyte1[0];
                    }
                    _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte2);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        //**************西门子读写结构体***********
        /// <summary>
        /// 西门子读结构体
        /// </summary>
        /// <param name="DBindex">DB块索引</param>
        /// <param name="Startindex">字节起始位</param>
        /// <param name="hanldname">任意值</param>
        /// <param name="type">结构体类型</param>
        /// <returns></returns>
        public dynamic ReadStruct(int DBindex, int Startindex, string hanldname, Type type)
        {
            int Exist = _S7structType.IndexOf(type);
            List<int[]> tempmatch = new List<int[]>();
            if (Exist != -1) tempmatch = _S7structmatch[Exist]._s7structmatch;
            else
            {
                _structmatch = new S7structmatch();
                _structmatch._s7structmatch = Getstructmatch(type);
                _S7structType.Add(type);
                _S7structmatch.Add(_structmatch);
                tempmatch = _structmatch._s7structmatch;
            }
            int count = Marshal.SizeOf(type);
            for (int i = 0; i < tempmatch.Count; i++)
            {
                if (tempmatch[i][0] == 0)
                {
                    if (tempmatch[i][1] == 0) count += -3;
                    else
                    {
                        int tempbytecount = tempmatch[i][1] / 16;
                        if (tempmatch[i][1] % 16 != 0) tempbytecount++;
                        count += tempbytecount * 2 - tempmatch[i][1] * 4;
                    }
                }
            }

            byte[] tempbyte1 = _plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, count);
            dynamic struct1 = (dynamic)BytesToStuct(tempbyte1, type, tempmatch);
            return struct1;
        }
        /// <summary>
        /// 西门子写结构体
        /// </summary>
        /// <param name="DBindex">DB块索引</param>
        /// <param name="Startindex">字节起始位</param>
        /// <param name="hanldname">任意值</param>
        /// <param name="data">结构体数据</param>
        /// <returns></returns>
        public bool WriteStruct(int DBindex, int Startindex, string hanldname, object data)
        {
            try
            {
                Type type = data.GetType();
                int Exist = _S7structType.IndexOf(type);
                List<int[]> tempmatch = new List<int[]>();
                if (Exist != -1) tempmatch = _S7structmatch[Exist]._s7structmatch;
                else
                {
                    _structmatch = new S7structmatch();
                    _structmatch._s7structmatch = Getstructmatch(type);
                    _S7structType.Add(type);
                    _S7structmatch.Add(_structmatch);
                    tempmatch = _structmatch._s7structmatch;
                }

                byte[] tempbyte = StructToBytes(data, tempmatch);
                _plc.WriteBytes(DataType.DataBlock, DBindex, Startindex, tempbyte);
                return true;
            }
            catch (Exception ex)
            {
                HLog.Error("WriteStruct error", ex);
                return false;
            }
        }

        public byte[] ReadByteArray(int DBindex, int Startindex, int Count)
        {

            return (_plc.ReadBytes(DataType.DataBlock, DBindex, Startindex, Count));
        }


        #region
        public List<int[]> Getstructmatch(Type type)
        {

            List<int[]> format = new List<int[]>();

            FieldInfo[] fieldInfos = type.GetFields();//struect是一个结构体的类型名
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                int[] temp = new int[] { 0, 0 };
                FieldInfo fi = type.GetField(fieldInfos[i].Name);
                string types = fi.FieldType.Name;

                if (types == "Boolean" || types == "Boolean[]")
                {
                    temp[0] = 0;//0代表类型为BOOL
                }
                else if (types == "Byte" || types == "Byte[]")
                {
                    temp[0] = 1;//1代表类型为byte
                }
                else if (types == "Int16" || types == "short" || types == "Int16[]" || types == "short[]")
                {
                    temp[0] = 2;//2代表类型为int16
                }
                else if (types == "Int32" || types == "Single" || types == "Int32[]" || types == "Single[]")
                {
                    temp[0] = 4;//4代表类型为float
                }

                foreach (object ele in fi.GetCustomAttributes(false))
                {
                    MarshalAsAttribute attr = ele as MarshalAsAttribute;
                    if (attr != null)
                    {
                        temp[1] = attr.SizeConst;//相关类型对应的数量
                        format.Add(temp);
                    }
                }
            }
            return format;
        }


        public byte[] StructToBytes(object structObj, List<int[]> condit)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(structObj);
            Type type = structObj.GetType();
            int Exist = _S7structType.IndexOf(type);
            List<int[]> tempmatch = new List<int[]>();
            if (Exist != -1) tempmatch = _S7structmatch[Exist]._s7structmatch;
            else
            {
                _structmatch = new S7structmatch();
                _structmatch._s7structmatch = Getstructmatch(type);
                _S7structType.Add(type);
                _S7structmatch.Add(_structmatch);
                tempmatch = _structmatch._s7structmatch;
            }


            //创建byte数组
            byte[] bytes = new byte[size];
            //分配结构体大小的内存空间
            IntPtr structPtr = Marshal.AllocHGlobal(size);
            //将结构体拷到分配好的内存空间
            Marshal.StructureToPtr(structObj, structPtr, false);
            //从内存空间拷到byte数组
            Marshal.Copy(structPtr, bytes, 0, size);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            List<byte> tempbytes = new List<byte>();
            int temp = 0;
            for (int i = 0; i < condit.Count; i++)
            {
                if (condit[i][1] == 0)//单个数据
                {
                    switch (condit[i][0])
                    {
                        case 0:
                            {
                                byte[] tempbool = new byte[2] { 0, 0 };
                                if (bytes[temp] == 1) tempbool[0] = 1;
                                tempbytes.Add(tempbool[0]);
                                tempbytes.Add(tempbool[1]);
                                temp += 4;
                            }
                            break;
                        case 1:
                            {
                                tempbytes.Add(bytes[temp]);
                                temp += 2;
                            }
                            break;
                        case 2:
                            {
                                tempbytes.Add(bytes[temp + 1]);
                                tempbytes.Add(bytes[temp]);
                                temp += condit[i][0];
                            }
                            break;
                        case 4:
                            {
                                tempbytes.Add(bytes[temp + 3]);
                                tempbytes.Add(bytes[temp + 2]);
                                tempbytes.Add(bytes[temp + 1]);
                                tempbytes.Add(bytes[temp]);
                                temp += condit[i][0];
                            }
                            break;

                    }

                }
                else //数组数据
                {
                    switch (condit[i][0])
                    {
                        case 0:
                            {

                                int boolcount = condit[i][1];
                                int bytecount = (boolcount / 16) * 2;
                                if (boolcount % 16 != 0) bytecount += 2;

                                byte[] tempbyte = new byte[bytecount];

                                int tempnumber = 0;
                                for (int j = 0; j < boolcount; j++)
                                {
                                    if (j % 8 == 0) tempnumber = i / 8;

                                    if (bytes[temp] == 1)
                                    {
                                        int index = j % 8;
                                        tempbyte[j / 8] = (byte)(tempbyte[j / 8] | (1 << index));
                                    }
                                    temp += 4;
                                }
                                for (int j = 0; j < bytecount; j++)
                                {
                                    tempbytes.Add(tempbyte[j]);
                                }

                            }
                            break;
                        case 1:
                            {
                                for (int j = 0; j < condit[i][1]; j++)
                                {
                                    tempbytes.Add(bytes[temp + j]);
                                }
                                temp += condit[i][1];
                                if (condit[i][1] % 2 == 1)
                                {
                                    byte tempbyte = 0;
                                    tempbytes.Add(tempbyte);
                                    temp += 1;
                                }
                            }
                            break;
                        case 2:
                            {
                                for (int j = 0; j < condit[i][1]; j++)
                                {
                                    tempbytes.Add(bytes[temp + j * 2 + 1]);
                                    tempbytes.Add(bytes[temp + j * 2]);
                                }
                                temp += condit[i][0] * condit[i][1];
                            }
                            break;
                        case 4:
                            {
                                for (int j = 0; j < condit[i][1]; j++)
                                {
                                    tempbytes.Add(bytes[temp + j * 4 + 3]);
                                    tempbytes.Add(bytes[temp + j * 4 + 2]);
                                    tempbytes.Add(bytes[temp + j * 4 + 1]);
                                    tempbytes.Add(bytes[temp + j * 4]);
                                }
                                temp += condit[i][0] * condit[i][1];
                            }
                            break;

                    }

                }
            }
            byte[] ArrayBytes = tempbytes.ToArray();
            //返回byte数组
            return ArrayBytes;
        }

        public object BytesToStuct(byte[] bytes, Type type, List<int[]> condit)
        {
            //得到结构体的大小
            int size = Marshal.SizeOf(type);
            int Exist = _S7structType.IndexOf(type);
            List<int[]> tempmatch = new List<int[]>();
            if (Exist != -1) tempmatch = _S7structmatch[Exist]._s7structmatch;
            else
            {
                _structmatch = new S7structmatch();
                _structmatch._s7structmatch = Getstructmatch(type);
                _S7structType.Add(type);
                _S7structmatch.Add(_structmatch);
                tempmatch = _structmatch._s7structmatch;
            }


            IntPtr structPtr = Marshal.AllocHGlobal(size);

            List<byte> tempbytes = new List<byte>();
            int temp = 0;
            for (int i = 0; i < condit.Count; i++)
            {
                int steps = 0;
                if (condit[i][1] == 0)//相关类型都是只有一个
                {
                    byte tempadd = 0;
                    switch (condit[i][0])
                    {
                        case 0://bool变量
                            {

                                tempbytes.Add(bytes[temp]);
                                tempbytes.Add(tempadd);
                                tempbytes.Add(tempadd);
                                tempbytes.Add(tempadd);
                                steps = 2;
                            }
                            break;
                        case 1://byte变量
                            {

                                tempbytes.Add(bytes[temp]);
                                steps = 2;
                            }
                            break;
                        case 2://int16变量
                            {
                                tempbytes.Add(bytes[temp + 1]);
                                tempbytes.Add(bytes[temp]);
                                steps = 2;
                            }
                            break;
                        case 4://float变量
                            {
                                tempbytes.Add(bytes[temp + 3]);
                                tempbytes.Add(bytes[temp + 2]);
                                tempbytes.Add(bytes[temp + 1]);
                                tempbytes.Add(bytes[temp]);
                                steps = 4;
                            }
                            break;

                    }
                    temp += steps;
                }
                else
                {
                    switch (condit[i][0])
                    {
                        case 0:
                            {
                                int byteCount = condit[i][1] / 16;
                                if (condit[i][1] % 16 != 0) byteCount++;
                                byteCount = byteCount * 2;
                                byte[] sultbyte = new byte[2] { 0, 1 };
                                byte tempadd = 0;
                                List<byte> boobyte = new List<byte>();
                                for (int j = 0; j < byteCount; j++)
                                {
                                    if ((bytes[temp + j] & 1) == 1) tempbytes.Add(sultbyte[1]); //第0位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                    if ((bytes[temp + j] & 2) == 2) tempbytes.Add(sultbyte[1]);//第1位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                    if ((bytes[temp + j] & 4) == 4) tempbytes.Add(sultbyte[1]);//第2位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                    if ((bytes[temp + j] & 8) == 8) tempbytes.Add(sultbyte[1]);//第3位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                    if ((bytes[temp + j] & 16) == 16) tempbytes.Add(sultbyte[1]);//第4位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                    if ((bytes[temp + j] & 32) == 32) tempbytes.Add(sultbyte[1]);//第5位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                    if ((bytes[temp + j] & 64) == 64) tempbytes.Add(sultbyte[1]);//第6位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                    if ((bytes[temp + j] & 128) == 128) tempbytes.Add(sultbyte[1]);//第7位
                                    else tempbytes.Add(sultbyte[0]);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);
                                    tempbytes.Add(tempadd);

                                }
                                int count = tempbytes.Count;
                                int diffcount = byteCount * 8 - condit[i][1];
                                tempbytes.RemoveRange(count - diffcount, diffcount);

                                steps = byteCount;
                            }
                            break;
                        case 1://byte变量
                            {
                                for (int j = 0; j < condit[i][1]; j++)
                                {
                                    tempbytes.Add(bytes[temp]);
                                }
                                if (condit[i][1] % 2 == 0)
                                {
                                    steps = condit[i][1];
                                }
                                else
                                {
                                    steps = condit[i][1] + 1;
                                }
                            }
                            break;
                        case 2:
                            {
                                for (int j = 0; j < condit[i][1]; j++)
                                {
                                    tempbytes.Add(bytes[temp + j * 2 + 1]);
                                    tempbytes.Add(bytes[temp + j * 2]);
                                }
                                steps = condit[i][0] * condit[i][1];
                            }
                            break;
                        case 4:
                            {
                                for (int j = 0; j < condit[i][1]; j++)
                                {
                                    tempbytes.Add(bytes[temp + j * 4 + 3]);
                                    tempbytes.Add(bytes[temp + j * 4 + 2]);
                                    tempbytes.Add(bytes[temp + j * 4 + 1]);
                                    tempbytes.Add(bytes[temp + j * 4]);
                                }
                                steps = condit[i][0] * condit[i][1];
                            }
                            break;

                    }
                    temp += steps;
                }
            }
            byte[] ArrayBytes = tempbytes.ToArray();

            //将byte数组拷到分配好的内存空间
            Marshal.Copy(ArrayBytes, 0, structPtr, size);
            //将内存空间转换为目标结构体
            object obj = Marshal.PtrToStructure(structPtr, type);
            //释放内存空间
            Marshal.FreeHGlobal(structPtr);
            //返回结构体
            return obj;
        }

        public float ToSingleData_Float(byte[] bytes, int Startindex, int location, PlcDataType type)
        {
            switch (type)
            {
                case PlcDataType.Bool:
                    var b = ToBool(bytes, Startindex, location);
                    return b ? 1f : 0f;
                case PlcDataType.Byte:
                    return bytes[Startindex];
                case PlcDataType.Int16:
                    return ToInt16(bytes, Startindex);
                case PlcDataType.Int32:
                    return ToInt32(bytes, Startindex);
                case PlcDataType.Float:
                    return ToFloat(bytes, Startindex);
                default:
                    return 0f;
            }
        }
        public float ToFloat(byte[] bytes, int start)
        {
            var arr = new byte[4];
            Array.Copy(bytes, start, arr, 0, 4);
            float[] fArr = (Single[])BytesToArray(arr, typeof(Single[]));
            return fArr[0];
        }

        public float ToInt16(byte[] bytes, int start)
        {
            var arr = new byte[2];
            Array.Copy(bytes, start, arr, 0, 2);
            Int16[] shorts = (Int16[])BytesToArray(arr, typeof(Int16[]));
            return shorts[0];
        }

        public float ToInt32(byte[] bytes, int start)
        {
            var arr = new byte[4];
            Array.Copy(bytes, start, arr, 0, 4);
            Int32[] ints = (Int32[])BytesToArray(arr, typeof(Int32[]));
            return ints[0];
        }

        public bool ToBool(byte[] datas, int byteIndex, int bitIndex)
        {
            var data = datas[byteIndex];
            return (data & (1 << bitIndex)) != 0;
        }

        public object BytesToArray(byte[] bytes, Type type)
        {
            int count = bytes.Length;
            if (type == typeof(Boolean[]))
            {
                bool[] Arraydata = new bool[count];
                for (int i = 0; i < count; i++)
                {
                    Arraydata[i] = BitConverter.ToBoolean(bytes, i);
                }
                return Arraydata;
            }
            else if (type == typeof(Byte[]))
            {
                return bytes;
            }
            else if (type == typeof(Int16[]))
            {
                count = count / 2;
                Int16[] Arraydata = new Int16[count];
                byte[] tempbytes = new byte[2];
                for (int i = 0; i < count; i++)
                {
                    tempbytes[0] = bytes[i * 2 + 1];
                    tempbytes[1] = bytes[i * 2];
                    Arraydata[i] = BitConverter.ToInt16(tempbytes, 0);
                }
                return Arraydata;

            }
            else if (type == typeof(Int32[]))
            {
                count = count / 4;
                Int32[] Arraydata = new Int32[count];
                byte[] tempbytes = new byte[4];
                for (int i = 0; i < count; i++)
                {
                    tempbytes[0] = bytes[i * 4 + 3];
                    tempbytes[1] = bytes[i * 4 + 2];
                    tempbytes[2] = bytes[i * 4 + 1];
                    tempbytes[3] = bytes[i * 4];
                    Arraydata[i] = BitConverter.ToInt32(tempbytes, 0);
                }
                return Arraydata;
            }
            else
            {
                count = count / 4;
                Single[] Arraydata = new Single[count];
                byte[] tempbytes = new byte[4];
                for (int i = 0; i < count; i++)
                {
                    tempbytes[0] = bytes[i * 4 + 3];
                    tempbytes[1] = bytes[i * 4 + 2];
                    tempbytes[2] = bytes[i * 4 + 1];
                    tempbytes[3] = bytes[i * 4];
                    Arraydata[i] = BitConverter.ToSingle(tempbytes, 0);
                }
                return Arraydata;
            }
        }


        private byte ReverseBits(byte c)
        {
            c = (byte)(((byte)((byte)(c & 0x55) << 1)) | ((byte)((byte)(c & 0xAA) >> 1)));
            c = (byte)(((byte)((byte)(c & 0x33) << 2)) | ((byte)((byte)(c & 0xCC) >> 2)));
            c = (byte)(((byte)((byte)(c & 0x0F) << 4)) | ((byte)((byte)(c & 0xF0) >> 4)));
            return c;
        }
        #endregion

    }


    public static class Common
    {
        public static dynamic ToPlcSendData(this float data, PlcDataType dataType)
        {
            switch (dataType)
            {
                case PlcDataType.Bool:
                    return data == 1;
                case PlcDataType.Byte:
                    return (byte)data;
                case PlcDataType.Int16:
                    return (short)data;
                case PlcDataType.Int32:
                    return (int)data;
                case PlcDataType.Float:
                    return data;
                default:
                    return null;
            }
        }
    }

    public enum PlcDataType
    {
        [Description("布尔量")]
        Bool = 0,
        [Description("字节")]
        Byte = 1,
        [Description("16位有符号整型")]
        Int16 = 2,
        [Description("32位有符号整型")]
        Int32 = 3,
        [Description("浮点数")]
        Float = 4,
    }

    public class S7structmatch
    {
        public List<int[]> _s7structmatch;
    }

    public static class EnumHelper
    {
        public static string Description(this Enum em)
        {
            var des = em.ToString();//默认为枚举字符串
            var type = em.GetType();
            var fd = type.GetField(em.ToString());
            if (fd == null)
            {
                return des;
            }
            var attrs = fd.GetCustomAttributes(typeof(DescriptionAttribute), false);
            foreach (DescriptionAttribute item in attrs)
            {
                des = item.Description;
            }
            return des;
        }

        public static T ToEnum<T>(this string enumStr) where T : Enum
        {
            return (T)Enum.Parse(typeof(T), enumStr);
        }

        public static T DescriptionToEnum<T>(this string enumDesStr) where T : Enum
        {
            var items = GetAllItems<T>();
            foreach (var item in items)
            {
                if (item.Description() == enumDesStr)
                {
                    return item;
                }
            }
            throw new KeyNotFoundException($"{typeof(T)} 中未找到描述为{enumDesStr}的枚举");
        }

        public static IEnumerable<T> GetAllItems<T>(IEnumerable<T> filters = null) where T : Enum
        {
            var hasFilters = filters != null && filters.Count() > 0;
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var itemT = (T)item;
                if (hasFilters && filters.Contains(itemT))
                {
                    continue;
                }
                yield return itemT;
            }
        }

        public static List<string> GetAllItemsNames<T>(IEnumerable<T> filters = null) where T : Enum
        {
            var items = GetAllItems<T>(filters);
            var ls = new List<string>();
            foreach (var item in items)
            {
                ls.Add(item.ToString());
            }

            return ls;
        }

        public static List<string> GetAllItemsDescriptions<T>(IEnumerable<T> filters = null) where T : Enum
        {
            var items = GetAllItems<T>(filters);
            var ls = new List<string>();
            foreach (var item in items)
            {
                ls.Add(item.Description());
            }

            return ls;
        }
    }
}