
# dotnetcore-sdk.3.0.100-preview6-012264.nupkg

# https://chocolatey.org/packages/dotnetcore-sdk
$packageName = 'dotnetcore-sdk'
$exe = 'dotnet-sdk-3.0.100-preview6-012264-win-x64.exe'

$url64 = 'https://download.visualstudio.microsoft.com/download/pr/4d2dfaa1-4f9c-4526-bb6f-117d9d8bbd0e/a9fc9994c1b4d485ab41632b81bf4f56/dotnet-sdk-3.0.100-preview6-012264-win-x64.exe'
# $checksum64 = 'D53279FD8D6D816E65C134F52C2211E27D6C5BBBD8A8AE9A1D7008CFD1A9143A97A033676B9CDB9B86CC1CF50F430D6BD5A7646250AD1DC4A18D3FCD75AD4D8B'

$silentArgs = "/install /quiet /norestart /log `"$env:TEMP\$($packageName)\$($packageName).MsiInstall.log`""

Invoke-WebRequest $url64 -o $exe