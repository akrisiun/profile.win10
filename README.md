## profile.win10
Setup tasks for empty Windows 10

1. install/reset windows  
2. download chrome  

### 3. install choco from https://chocolatey.org/install 

run cmd as admin  
```
PowerShell.exe -ExecutionPolicy Unrestricted
@powershell 
iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
```

### 4. choco install tasks  

`choco install -y conemu`
finally open real console conemu 
```
choco install -y git kdiff3
choco install -y git-credential-manager-for-windows
```
gitextensions install manually, no visual studio plugins please

### 5. setup PATH, TEMP

PATH=c:\bin;c:\System;c:\Program Files\Git\bin\;d:\tools;%USERPROFILE%\AppData\Local\Microsoft\WindowsApps;C:\Program Files\kdiff3
TEMP=c:\Temp

### 6. Visual Studio

```
choco install -y notepadplusplus.install visualstudiocode
choco install -y netfx-4.5.1-devpack netfx-4.5.2-devpack
 
choco install -y visualstudiocommunity2013
choco install -y vsredist2013 windows-sdk-8.1 

choco install -y windows-sdk-10.0
choco install -y dotnet4.6-targetpack microsoft-build-tools 
choco install -y dotnet4.6.1-devpack

```

### 7. SQL Server 

Sqlserver 1.04 GB, SSME 2012 825MB :( 
```
choco install -y mssqlserver2012express
// only ssme ??? 
choco install -y sql-server-management-studio
```