::@echo %~1>%~dp0DevEnvDir
::@echo %~2>%~dp0TargetPath

::@set /p DevEnvDir=<%~dp0DevEnvDir
::@set /p TargetPath=<%~dp0TargetPath

:: Create event in task scheduler.
schtasks /create /sc DAILY /tn "Desktop\EmailList" /tr "\"%~dp0ScheduleTest.bat\"" /st 16:00 /f /rl HIGHEST

:: ========
:: Reference: docs.microsoft.com/en-us/windows-server/administration/windows-commands/schtasks
:: ========
:: /sc DAILY
::	Daily task.
:: /tn "Desktop/EmailList"
::	Name of task (root is "Task Scheduler Library").
:: /tr "\"%~dp0ScheduleTest.bat\""
::	Task to be run (batch file).
:: /st 00:00
::	Start at midnight.
:: /f
::	Ignore errors and overwrite existing task.
:: /rl HIGHEST
::	Run with highest privileges.
:: ========