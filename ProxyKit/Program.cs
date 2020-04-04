using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace ProxyKit.Recipe.Simple
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            int hostPort = 5000;
            if (args.Length > 0 && args[0].StartsWith(":"))
            {
                ProxyStartup.Host = $"http://localhost{args[0]}";
                ProxyStartup.WsHost = $"ws://localhost{args[0]}/";

                if (args.Length > 1 && args[1].StartsWith(":"))
                    hostPort = int.Parse(args[1].Substring(1));

            } else
            {
                ProxyStartup.Host = "http://localhost:8090";
                ProxyStartup.WsHost = "ws://localhost:8090/";
                // ProxyStartup.Host = "http://localhost:9009";
            }
            Console.WriteLine($"Host {ProxyStartup.Host}");

            var upstreamHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<UpstreamHostStartup>()
                .UseUrls("http://localhost:5001")
                .Build();

            var proxyHost = WebHost.CreateDefaultBuilder(args)
                .UseStartup<ProxyStartup>()
                .UseUrls($"http://localhost:{hostPort}")
                .Build();

            await upstreamHost.StartAsync();

            proxyHost.Run();
        }
    }
}