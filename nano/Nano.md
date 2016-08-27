
## https://msdn.microsoft.com/virtualization/windowscontainers/quick_start/quick_start_windows_10

@powershell as Administrator
```
Enable-WindowsOptionalFeature -Online -FeatureName containers -All

Enable-WindowsOptionalFeature -Online -FeatureName Microsoft-Hyper-V -All


[Environment]::SetEnvironmentVariable("Path", $env:Path + ";$env:ProgramFiles\docker\", [EnvironmentVariableTarget]::Machine)

$ $env:ProgramFiles\docker\dockerd.exe --register-service

Once installed, the service can be started.
Start-Service Docker
```