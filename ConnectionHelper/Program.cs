using ConnectionHelper.Models;
using Microsoft.AspNetCore.Mvc;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapGet("/info", ([FromServices] IHttpContextAccessor httpContextAccessor) =>
{
    var context = httpContextAccessor.HttpContext;
    var connection = context?.Connection;
    var request = context?.Request;

    return new ConnectionInformation
    {
        IpAddress = connection?.RemoteIpAddress?.ToString(),
        Port = connection?.RemotePort,
        LocalIpAddress = connection?.LocalIpAddress?.ToString(),
        LocalPort = connection?.LocalPort,
        IsLocal = connection?.RemoteIpAddress?.Equals(connection?.LocalIpAddress),
        RequestMethod = request?.Method,
        RequestPath = request?.Path,
        QueryString = request?.QueryString.Value,
        UserAgent = request?.Headers["User-Agent"].FirstOrDefault(),
        Headers = request?.Headers.ToDictionary(h => h.Key, h => h.Value.ToString()),
        Cookies = request?.Cookies.ToDictionary(c => c.Key, c => c.Value),
        Protocol = request?.Protocol,
        Host = request?.Host.Host,
        IsHttps = request?.IsHttps
    };
});

app.MapGet("/", () => Results.Extensions.Html("<a href='/info'>/info</a>"));

app.Run();
