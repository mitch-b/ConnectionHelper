namespace ConnectionHelper.Models;

public class ConnectionInformation
{
    public string? IpAddress { get; set; }
    public int? Port { get; set; }
    public string? LocalIpAddress { get; set; }
    public int? LocalPort { get; set; }
    public bool? IsLocal { get; set; }
    public string? RequestMethod { get; set; }
    public string? RequestPath { get; set; }
    public string? QueryString { get; set; }
    public string? UserAgent { get; set; }
    public object? Headers { get; set; } // Scalar bug with serializing Dictionary<string, string>? type
    public object? Cookies { get; set; } // Scalar bug with serializing Dictionary<string, string>? type
    public string? Protocol { get; set; }
    public string? Host { get; set; }
    public bool? IsHttps { get; set; }
}
