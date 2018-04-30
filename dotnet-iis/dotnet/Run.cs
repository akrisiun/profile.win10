using System;
using System.Diagnostics;

namespace Dotnet
{
    using Dotnet.IISTest;

    public class Run
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var pwd = Environment.CurrentDirectory;
            var host = ExpressWebServer.Instance ?? new ExpressWebServer(pwd);
            host.WwwRoot = pwd;
            host.PortNumber = 8000;

            string[] parms = args ?? Environment.GetCommandLineArgs();
            // if (parms.Length > 0) Console.WriteLine($"Args: {string.Join(" ", parms)}");

            for(int posPrm = 0; posPrm < parms.Length; posPrm++)
            {
                var segment = parms[posPrm] as string ?? "";

                // Console.WriteLine($"segment {segment}");
                if (segment.StartsWith("port") 
                    || segment.StartsWith("-port")
                    || segment.StartsWith("/port"))
                {
                    posPrm++;
                    if (posPrm >= parms.Length)
                        break;
                    int port = 0;
                    segment = parms[posPrm] as string ?? "";

                    if (Int32.TryParse(segment, out port) && port > 0)
                        host.PortNumber = port;
    
                    Console.WriteLine($"segment {segment} port={port}");
                }

                if (segment.StartsWith("debug") )
                {
                    Debugger.Launch();
                    Debugger.Break();
                }
            }

            Console.WriteLine($"Pwd={pwd} Port={host.PortNumber}");
            // if (!System.Diagnostics.Debugger.IsAttached)
            //     Console.ReadKey();

            host.Start();

            // if (host.IsOpen())
            host.IsOpen();
            host.IIS.WaitForExit();
            host?.Dispose();
            
            Console.WriteLine($"Exited");
            Console.ReadKey();
        }
    }
}
