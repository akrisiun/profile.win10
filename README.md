## profile.win10
Setup tasks for empty Windows 10

1. install/reset windows  
2. download chrome  
### 3. install choco  

https://chocolatey.org/install 

```
PowerShell.exe -ExecutionPolicy Unrestricted
run cmd as admin
@powershell 
iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))
```

### 4. choco install tasks  

```
choco install -y conemu
choco install -y git kdiff3
```

### 5 setup PATH  

