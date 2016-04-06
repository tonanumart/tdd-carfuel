@echo off

Packages\xunit.runner.console.2.1.0\tools\xunit.console ^
	CarFuelFacts\bin\Debug\CarFuelFacts.dll ^
	-parallel all ^
	-html Result.html ^
	-nologo  
pause