namespace VOL.Core.Const
{
    public class CacheConst
    {
        #region DeviceCache
        public const string StopStation = "工站停止采集";
        public const string RfidUp = "开始读取托盘";
        public const string RfidDown = "结束读取托盘";
        public const string RfidReadFinishOk = "托盘读取完毕，托盘号为：";
        public const string RfidReadFinishError = "托盘查询为空，发 100，托盘号为：";
        public const string RfidIsUse = "托盘被占用，直接发 4，如需重试请点击恢复占用";
        public const string RfidStationAllow = "工站是否允许工作，值为：";
        public const string RfidReadFail = "托盘读取异常，托盘号为空或为 0，请检查";
        public const string FindDataFirstByRfidError = "未根据托盘绑定的产品码查询到相关数据，请检查，托盘和产品码分别为：";
        public const string FindDataFirstByRfidOK = "根据托盘产品码查询到产品，产品上一站结果为 OK";
        public const string FindDataFirstByRfidNG = "根据托盘产品码查询到产品，产品上一站结果为 NG";
        public const string FindRfidLastStationOK = "上一站是指定工站";
        public const string FindRfidLastStationNG = "上一站不是指定工站";
        public const string SaveDataUp = "开始保存数据";
        public const string SaveDataDown = "结束保存数据";
        public const string SaveDataReturnError = "该站无防错直接返回，不读取数据";
        public const string SaveDataReturnRework = "该站无返工直接返回，不读取数据";
        public const string SaveDataNGOfRfidNull = "保存数据失败，托盘为空";
        public const string SaveDataNGOfException = "保存数据失败，出现异常";
        public const string SaveDataNotLastNG = "上一站结果为 NG，不保存数据";
        public const string ProductCodeError = "测试站给的码是错码";
        public const string SaveDataProductCodeIsNullFromPlc = "来自于 PLC 扫码为空，请联系电气检查";
        public const string CollectTorqueData = "开始采集压机数据,地址为 DB50.1600.0";
        public const string CollectTorqueDataFail = "采集压机数据失败,地址为 DB50.1600.0";
        public const string InErrorPrevent = "进入防错分支";
        public const string InErrorPreventData = "进入防错保存数据分支";
        public const string InRework = "进入返工分支";
        public const string InReworkData = "进入返工保存数据分支";
        public const string InNormal = "进入正常分支";
        public const string InNormalData = "进入正常保存数据分支";
        public const string EPFindDataNG = "未根据托盘防错码查询到防错数据，请检查，托盘和防错码分别为：";
        public const string SingleErrorData = "进入单独防错采集，开始保存防错数据";
        public const string SingleErrorDataStop = "单工站防错暂停采集";
        public const string NG_RESAON_TORQUE = "扭矩 NG";
        public const string NG_RESAON_CLEAN = "清料 NG";
        public const string NG_RESAON_ANGLE = "角度 NG";
        public const string NG_RESAON_IV = "IV3 NG";
        public const string NG_RESAON_DISPLACE = "位移 NG";
        public const string NG_RESAON_HAI = "氦检 NG";
        public const string NG_RESAON_GAO = "高品 NG";
        #endregion

        #region RedisConst
        public const string VOL_RFID_DATA = "Vol:Rfid:";
        public const string VOL_DATA_PRODUCT = "Vol:Data:";
        public const string VOL_PLC_ONLINE = "Vol:PlcOnline:";
        public const string PRODUCT_FUNC = "ProductFunc";
        public const string MESSAGE_STREAM_KEY = "streamProducts";
        public const string MESSAGE_STREAM_ISDELETE = "isDelete";
        public const string MESSAGE_STREAM_PRODUCTCODE = "productCode";
        public const string LOCK_PRODUCT = "lock:product:";
        #endregion
    }
}
