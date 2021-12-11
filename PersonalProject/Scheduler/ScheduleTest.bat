:: Get macros from files saved during build and store in variables.
@set /p DevEnvDir=<%~dp0DevEnvDir
@set /p TargetPath=<%~dp0TargetPath

"%DevEnvDir%CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "%TargetPath%""