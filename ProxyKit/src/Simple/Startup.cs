// the startup class  add a IUrlRewriter service and ProxyMiddleware.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProxyKit
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        static string Host => "http://127.0.0.1:8090/$1";
        public IConfiguration Conf => _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IUrlRewriter>(
            new SingleRegexRewriter(@"^/POC/(.*)", Host));
        }

        public void Configure(IApplicationBuilder app) //, IHostingEnvironment env)
        {
            app.UseRewriter(new RewriteOptions());
            // .AddRedirectToHttps());
            app.UseMiddleware<ProxyMiddleware>();
        }

        // In Startup.cs
        public void ConfigureServices2(IServiceCollection services)
        {
            /*
            services.AddSingleton<IUrlRewriter>(new MergeRewriter()
                .Add(new PrefixRewriter("/POC/API", "http://localhost:1234"))
                .Add(new SingleRegexRewriter(@"^/POC/(.*)", "http://192.168.7.73:3001/$1")));
            */
        }
        // I found a project to do same but with way more other feature https://github.com/damianh/ProxyKit as a nuget package
        
        public void Configure3(IApplicationBuilder app)
        {
                var ipNetwork = IPNetwork.Parse("10.0.0.1", "255.255.255.0");

                app.RunProxy(context =>
                {
                    // If the source IP is outside the specified range then return Forbidden.
                    // This uses the IPNetwork2 package from https://github.com/lduchosal/ipnetwork
                    if (!ipNetwork.Contains(context.Connection.RemoteIpAddress))
                    {
                        var response = new HttpResponseMessage(HttpStatusCode.Forbidden);
                        return Task.FromResult(response);
                    }
               });
       }

    }
}