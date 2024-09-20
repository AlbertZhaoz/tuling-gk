namespace VOL.Albert.Edge.Mqtt
{
    public class MqttEntity
    {
        public string Description { get; set; }
        public string Company { get; set; }
        public SqlSugarConnect SqlSugarConnect { get; set; }
        public Credentials Credentials { get; set; }
        public WebApiInfo WebApiInfo { get; set; }
        public MqttClientInfo MqttClientInfo { get; set; }
        public List<AlbertEdgeInfoItem> AlbertEdgeInfo { get; set; }
    }
    public class SqlSugarConnect
    {
        public string DbType { get; set; }
        public string DbConnectStr { get; set; }
    }

    public class Credentials
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

    public class WebApiInfo
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
    }

    public class MqttClientInfo
    {
        public string IpAddress { get; set; }
        public int Port { get; set; }
    }

    public class EdgeSubListItem
    {
        public string SubDescription { get; set; }
        public string SubOrder { get; set; }
        public string SubIsUse { get; set; }
        public string SubEdgeType { get; set; }
        public string SubMethod { get; set; }
        public string SubUrl { get; set; }
        public string SubBody { get; set; }
        public string SubDateType { get; set; }
        public string SubDateTypeLength { get; set; }
    }

    public class EdgeTopicProcessItem
    {
        public string Description { get; set; }
        public string Order { get; set; }
        public string IsUse { get; set; }
        public string EdgeType { get; set; }
        public string EdgeMethod { get; set; }
        public string EdgeUrl { get; set; }
        public string EdgeBody { get; set; }
        public List<EdgeSubListItem> EdgeSubList { get; set; }
    }

    public class AlbertEdgeInfoItem
    {
        public string EdgeTopic { get; set; }
        public string EdgeTopicValue { get; set; }
        public List<EdgeTopicProcessItem> EdgeTopicProcess { get; set; }

    }
}
