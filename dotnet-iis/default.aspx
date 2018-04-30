<%@ Page Language="C#" %>
<%@ Import Namespace="System.Reflection" %>

<a href="load.aspx">load.aspx</a> 
| <a href="netversion.aspx">netversion.aspx</a> 

<%
    Response.Write("Version: " + System.Environment.Version.ToString());
    Response.Write("<br/>AppDomain.BaseDirectory=" + System.AppDomain.CurrentDomain.BaseDirectory);
    Response.Write("<br/>UsingIntegratedPipeline=" + System.Web.HttpRuntime.UsingIntegratedPipeline.ToString());
    try
    {
        var call = typeof(System.Web.HttpRuntime).GetProperty("IISVersion", BindingFlags.Static);
        if (call != null)
            Response.Write(", IISVersion={call.GetValue(null, null)"); // + System.Web.HttpRuntime.IISVersion.ToString());
    }
    catch { }

    Response.Write("<br/>AspInstallDirectory=" + System.Web.HttpRuntime.AspInstallDirectory.ToString());

    Response.Write("<br/>Assemblies=" + System.AppDomain.CurrentDomain.GetAssemblies().Length.ToString());

    foreach (var asm in System.Linq.Enumerable.OrderBy(System.AppDomain.CurrentDomain.GetAssemblies(),
        a => a.IsDynamic ? a.FullName : a.CodeBase))
    {
        try {
            Response.Write("<br/>" + asm.CodeBase.Replace("file:///", ""));
        }
        catch {
            // case: Anonymously Hosted DynamicMethods Assembly
            Response.Write("<br/>" + asm.FullName);
        }
    }

%>