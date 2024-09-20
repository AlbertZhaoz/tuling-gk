namespace WpfTulingGkMes.Models;

public class WebResponseContent
{
    public bool Status { get; set; }
    public string Code { get; set; }
    public string Message { get; set; }
    public dynamic Data { get; set; }
}