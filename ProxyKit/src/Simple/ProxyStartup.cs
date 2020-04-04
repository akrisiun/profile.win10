using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyKit.Recipe.Simple
{
    public class ProxyStartup
    {
        public static string Host { get; set; }
        public static string WsHost { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            Run.Add(services); // AddProxy();
        }

        public void Configure(IApplicationBuilder app)
        {
             // must first be able to handle incoming websocket requests
            app.UseWebSockets();

            // websockets proxy is non-terminating
            app.RunWebSocketProxy(
                context => new Uri(WsHost ?? "ws://localhost:8080/"),
                // optionally add X-ForwardedHeaders to websocket client.
                options => options.AddXForwardedHeaders());

            app.Proxy( // RunProxy
                context => context
                .ForwardTo(Host)
                // .Add
                .AddXForwardedHeaders()
                // .Send()
                .SendAsync()
                );



        }
    }

    public static class SendClient 
    { 

        /// <summary>
        /// Sends the upstream request to the upstream host.
        /// </summary>
        /// <returns>An <see cref="HttpResponseMessage"/> the represents the proxy response.</returns>
        public static async Task<HttpResponseMessage> SendAsync(this ForwardContext @this)
        {
            try
            {
                var _httpClient = @this.HttpClient;
                return await _httpClient
                    .SendAsync(
                        @this.UpstreamRequest,
                        HttpCompletionOption.ResponseHeadersRead,
                        @this.HttpContext.RequestAborted)
                    .ConfigureAwait(false);
            }
            catch (TaskCanceledException ex) when (ex.InnerException is IOException)
            {
                return new HttpResponseMessage(HttpStatusCode.GatewayTimeout);
            }
            catch (OperationCanceledException)
            {
                // Happens when Timeout is low and upstream host is not reachable.
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
            catch (HttpRequestException ex)
                when (ex.InnerException is IOException || ex.InnerException is SocketException)
            {
                // Happens when server is not reachable
                return new HttpResponseMessage(HttpStatusCode.ServiceUnavailable);
            }
        }
    }
}