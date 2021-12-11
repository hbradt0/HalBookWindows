::@set /p DevEnvDir=<%~dp0DevEnvDir
::@set /p TargetPath=<%~dp0TargetPath

"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" "C:\Users\hbradt\source\repos\PersonalProject\PersonalProject\bin\Debug\net472\MyProject.dll" /TestCaseFilter:"(TestCategory=sanity)"