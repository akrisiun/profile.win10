### configure_docker_daemon

https://msdn.microsoft.com/en-us/virtualization/windowscontainers/docker/configure_docker_daemon

>@powershell
```
New-Item -Type Directory -Path 'C:\Program Files\docker\'

// Invoke-WebRequest https://aka.ms/tp5/b/dockerd -OutFile $env:ProgramFiles\docker\dockerd.exe
Download the Docker client.
// Invoke-WebRequest https://aka.ms/tp5/b/docker -OutFile $env:ProgramFiles\docker\docker.exe

// Add the Docker directory to the system path. When complete, restart the PowerShell session so that the modified path is recognized.
[Environment]::SetEnvironmentVariable("Path", $env:Path + ";C:\Program Files\Docker", [EnvironmentVariableTarget]::Machine)

// To install Docker as a Windows service, run the following.
dockerd --register-service

Program 'dockerd.exe' failed to run: The specified executable is not a valid application for this OS platform.At
line:1 char:1

Start-Service Docker
```

Get-EventLog -LogName Application -After (Get-Date).AddMinutes(-50) | Sort-Object Time