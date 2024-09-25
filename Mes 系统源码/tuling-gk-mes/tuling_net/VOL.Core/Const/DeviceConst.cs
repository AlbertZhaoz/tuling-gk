using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VOL.Core.Const
{
    /// <summary>
    /// 设备常量
    /// </summary>
    public class DeviceConst
    {
        // 设备
        public const string DEV_INIT_OK = "设备已初始化";
        public const string DEV_INIT_NG = "设备未初始化，请先初始化";
        public const string DEV_HEARTBEAT_STOP = "心跳暂停";
        public const string DEV_DISCONNECT = "断开设备";
        public const string DEV_EXIST = "设备已存在，请勿重复添加";
        public const string DEV_STATUS_DISCONNECT = "设备已断开";
        public const string DEV_UPDATE_NG_NODEVICE = "更新失败，无该设备";
        public const string DEV_DELETE_NG_NODEVICE = "删除失败，无该设备";
        public const string DEV_FIND_NG = "未找到该设备";
        public const string DEV_PARAM_LOSS_PLC = "请选择一种 PLC 类型";
        public const string DEV_PARAM_LOSS_IP = "请填写 IP 或者 Port";
        public const string DEV_WRITE_OK = "写成功";
        public const string DEV_WRITE_NG = "写失败";
        public const string DEV_READ_OK = "读成功";
        public const string DEV_READ_NG = "读失败";
        // 工站
        public const string DEV_Station_STOP = "工站暂停";
        public const string DEV_Station_FIND_NG = "未找到该工站";
        public const string DEV_Station_Start = "工站已打开采集，请关闭后再进行";
        // bool
        public const string DEV_TYPE_BOOL = "bool";
        // byte
        public const string DEV_TYPE_BYTE = "byte";
        // short
        public const string DEV_TYPE_SHORT = "short";
        // ushort
        public const string DEV_TYPE_USHORT = "ushort";
        // uint
        public const string DEV_TYPE_UINT = "uint";
        // int
        public const string DEV_TYPE_INT = "int";
        // long
        public const string DEV_TYPE_LONG = "long";
        // ulong
        public const string DEV_TYPE_ULONG = "ulong";
        // float
        public const string DEV_TYPE_FLOAT = "float";
        // double
        public const string DEV_TYPE_DOUBLE = "double";
        // string
        public const string DEV_TYPE_CHARARR = "chararr";
        public const string DEV_TYPE_STRING = "string";
    }
}
