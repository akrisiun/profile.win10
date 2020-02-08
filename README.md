Other links:  
[powershell](powershell.md)

## Hipernate from command line:
```
shutdown /h /f 
ping -n 7 127.0.0.1 > NUL 2>&1 && shutdown /h /f
```

# Profile.win10
Setup tasks for empty Windows 10

1. install/reset windows  
2. download chrome  

### 3. install choco from https://chocolatey.org/install 

run cmd as admin  
```
PowerShell.exe -ExecutionPolicy Unrestricted
iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
```

### 3b. dotnet + dotnet $env:PATH

```
https://github.com/dotnet/core/blob/master/release-notes/3.1/3.1.0/3.1.0.md
SDK LTS for x64 installer download/run
Core SDK 3.1.100

powershell
new-item -type directory c:\bin
#mkdir c:\bin
$env:PATH="c:\Program files\dotnet;$env:PATH"

refreshenv
write-Host $env:PATH

dotnet --info
```

### 3. choco install tasks  

```
choco feature enable -n allowGlobalConfirmation

choco install -y notepadplusplus
choco install -y conemu

choco feature list
choco feature enable -n=allowGlobalConfirmation

choco install git kdiff3
choco install git-credential-manager-for-windows
```
gitextensions install manually, no visual studio plugins please

## 4. git config

```
# How do I remove files saying “old mode 100755 new mode 100644” 
git config --global core.whitespace nowarn
git config --global core.filemode false

git config core.filemode false
```

### 5. setup PATH, TEMP

```
PATH=c:\bin;c:\System;c:\Program Files\Git\bin\;d:\tools;%USERPROFILE%\AppData\Local\Microsoft\WindowsApps;
C:\Program Files\kdiff3

TEMP=c:\Temp

write-host $env:path
new-item -type directory c:\bin\tools
$env:Path = "c:\bin;c:\bin\tools;" + $env:Path
write-host $env:path
refreshenv
write-host $env:path

ps$>
write-host $env:programfiles
ls $env:Programfiles\git\bin\*
& $env:Programfiles\git\bin\git.exe config --global core.whitespace nowarn
& $env:Programfiles\git\bin\git.exe config --global core.filemode false
```

### 6. Visual Studio

```
choco install notepadplusplus.install visualstudiocode
choco install netfx-4.5.1-devpack netfx-4.5.2-devpack dotnet4.6.1-devpack netfx-4.7.1-devpack

# choco install -f -y netfx-4.5.1-devpack netfx-4.5.2-devpack dotnet4.6-targetpack microsoft-build-tools dotnet4.6.1-devpack

choco install visualstudiocommunity2013
choco install vs2013.5
choco install visualstudio2013-sdk
choco install vsredist2013 windows-sdk-8.1 

choco install windows-sdk-10.0
choco install dotnet4.6-targetpack microsoft-build-tools 
choco install dotnet4.6.1-devpack
choco install dotnet4.7.1
choco install netfx-4.7.1-devpack

choco install dotnetcore-sdk -y
```

### 7. SQL Server 

Sqlserver 1.04 GB,   
SSME  
https://chocolatey.org/packages/sql-server-management-studio  

```
choco install mssqlserver2012express sql-server-management-studio
// only ssme ??? 
choco install sql-server-management-studio
```

### 8. IIS

MVC5 fix:  
C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET MVC 4\Assemblies\  
C:\Program Files (x86)\Microsoft ASP.NET\ASP.NET Web Pages\v2.0\Assemblies\  

### 9. Rdpd/Vnc

```
choco install realvnc
```

### Docker for Win

https://hub.docker.com/?overlay=onboarding - download (https://docs.docker.com/docker-for-windows/install/)
https://docs.docker.com/docker-for-windows/ - docs
Docker: https://github.com/phusion/baseimage-docker#running_startup_scripts - baseimage-docker minimal Ubuntu base image 
