### ~/.gitconfig

with NTLM proxy 192.168.2.106:5865

```
[user]
	name = <>
	email = <>
[branch]
	autosetuprebase = always
[http "https://bitbucket.org"]
	proxy = http://192.168.2.106:5865
[http "https://github.com"]
	proxy = http://192.168.2.106:5865
[http "https://chromium.googlesource.com"]
	proxy = http://192.168.2.106:5865
[core]
	autocrlf = True
	editor = notepad++ -multiInst -nosession
	excludesfile = <>\\gitignore_global.txt
	safecrlf = false
[merge]
	tool = vsdiffmerge
[mergetool "kdiff3"]
	path = C:/Program Files/KDiff3/kdiff3.exe
[diff]
	guitool = winmerge
[difftool "kdiff3"]
	path = C:/Program Files/KDiff3/kdiff3.exe
[difftool "winmerge"]
	path = D:/Tools/GNU/WinMerge/WinMergeU.exe
	cmd = \"D:/Tools/GNU/WinMerge/WinMergeU.exe\" -e -u \"$LOCAL\" \"$REMOTE\"
[credential]
	helper = manager
[i18n]
	filesEncoding = windows-1257
[push]
	default = simple
[mergetool]
	prompt = true
[mergetool "vsdiffmerge"]
	cmd = "\"C:/Program Files/Microsoft Visual Studio 12.0/Common7/IDE/vsdiffmerge.exe\" /m \"$REMOTE\" \"$LOCAL\" \"$BASE\" \"$MERGED\" "
	trustexitcode = true
	path = C:/Program Files/Microsoft Visual Studio 12.0/Common7/IDE/vsdiffmerge.exe
[mergetool "vsdiffmerge"]
	keepbackup = false
	
```
