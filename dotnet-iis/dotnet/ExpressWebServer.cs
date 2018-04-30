using System;
using System.Collections.Generic;

namespace Dotnet.IISTest
{
    using System.Threading;
    using System.Diagnostics;
    using System.Net;

    // http://www.michael-whelan.net/testing-mvc-application-with-iis-express-webdriver/

    public class ExpressWebServer : IDisposable
    {
        public static ExpressWebServer Instance { get; private set; }

        public IDictionary<string, object> Env { get; set; }
        public string WwwRoot { get;  set; }
        public string Args { get; set; }
        public int PortNumber { get; set; } = 9000;

        public Process IIS;

        public ExpressWebServer(string wwwRoot, string args = null,
            IDictionary<string, object> env = null)
        {
            Args = args;
            WwwRoot = wwwRoot;
            Env = env;
        }

        public bool IsOpen()
        {
            var host = "localhost";
            var port = PortNumber;

            var req = System.Net.WebRequest.Create($"http://{host}:{port}/");
            // length of time, in milliseconds, before the request times out.
            req.Timeout = 1000 * 120; // 1h
            HttpWebResponse resp = null;

            bool alive = false;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
                alive = resp.StatusCode >= HttpStatusCode.OK;
            }
            catch (WebException) { }

            resp?.Dispose();
            req.Abort();
            req = null;
            return alive;
        }

        public void Start()
        {
            if (Instance == null || Instance.IIS == null)
                Instance = this;

            WwwRoot = WwwRoot ?? Environment.CurrentDirectory;
            var args = Args ?? $@"/port:{PortNumber} /clr:4.0 /systray:true /path:{WwwRoot}";
            if (args.EndsWith("/path:"))
                args += WwwRoot;
            
            Console.WriteLine($"\nIIS: {args} ");

            var webHostStartInfo = InitializeIISExpress(WwwRoot, args, PortNumber, Env);

            webHostStartInfo.RedirectStandardError = true;
            webHostStartInfo.RedirectStandardOutput = true;

            webHostStartInfo.UseShellExecute = false;
            webHostStartInfo.RedirectStandardError = true;

            IIS = Process.Start(webHostStartInfo);

            if (IIS.HasExited || IIS.Threads.Count == 0)
            {
                string errors = IIS.StandardError.ReadToEnd();
                string output = errors ?? "" + IIS.StandardOutput.ReadToEnd();
                Console.WriteLine(output);
                return;
            }

            IIS.OutputDataReceived += this.IIS_OutputDataReceived;
            IIS.BeginOutputReadLine();
            IIS.BeginErrorReadLine();

            //error = new AsyncStreamReader(this, s, new UserCallBack(this.ErrorReadNotifyUser), standardError.CurrentEncoding);
            // _webHostProcess.TieLifecycleToParentProcess();

            var thread = IIS.Threads[0] as ProcessThread;

            // check:
            Thread.Sleep(200); // 0.2 sec
            IsOpen();
        }

        void IIS_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (Debugger.IsAttached)
                Debugger.Log(0, "", e.Data);
            Console.WriteLine(e.Data ?? "");
        }

        public void Stop() { Dispose(); }

        public void Dispose()
        {
            if (IIS == null)
                return;
            if (!IIS.HasExited)
                IIS.Kill();
            IIS.Dispose();
            IIS = null;
        }

        public string BaseUrl {
            get { return string.Format("http://localhost:{0}", PortNumber); }
        }

        static ProcessStartInfo InitializeIISExpress(string wwwroot, string args,  
            int PortNumber = 9000,
            IDictionary<string, object> env = null)
        {
            var key = Environment.Is64BitOperatingSystem ? "programfiles(x86)" : "programfiles";
            var programfiles = Environment.GetEnvironmentVariable(key);

            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Normal,
                ErrorDialog = true,
                LoadUserProfile = true,
                CreateNoWindow = false,
                UseShellExecute = false,
                Arguments = args,
                FileName = $"{programfiles}\\IIS Express\\iisexpress.exe"
            };
            
            Console.WriteLine($"\n{programfiles}\\IIS Express\\iisexpress.exe");

            if (env != null)
            {
                foreach (var variable in env)
                    if (!string.IsNullOrWhiteSpace(variable.Value as string))
                        startInfo.EnvironmentVariables.Add(variable.Key, variable.Value as string);
            }

            return startInfo;
        }
    }

}