@REM nuget push local nuget package sample

echo %USERPROFILE%

nuget add -source %USERPROFILE%\.nuget\packages -Expand ./bin/Debug/System.Web.Mvc.5.5.0.0.nupkg
