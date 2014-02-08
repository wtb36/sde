SDEConsole.exe:	SDELib.dll SDEConsole/*.cs
	gmcs -r:SDELib.dll -recurse:SDEConsole/*.cs -out:$@

SDELib.dll:	SDELib/*.cs
	gmcs -recurse:SDELib/*.cs -target:library -out:$@
