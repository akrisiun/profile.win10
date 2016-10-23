d:
cd %~dp0lib\

gacutil /i System.Web.Mvc.dll 
@PAUSE

gacutil /i System.Web.Razor.dll
gacutil /i System.Web.WebPages.dll
gacutil /i System.Web.WebPages.Razor.dll
gacutil /i System.Web.WebPages.Deployment.dll

@PAUSE