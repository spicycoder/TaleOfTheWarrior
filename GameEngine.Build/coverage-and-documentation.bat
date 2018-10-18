REM Create a 'CodeCoverage' folder if it does not exist
if not exist "%~dp0CodeCoverage" mkdir "%~dp0CodeCoverage"

REM Remove any previous test execution files to prevent issues overwriting
IF EXIST "%~dp0Testreport.trx" del "%~dp0Testreport.trx%"

REM Remove any previously created test output directories
CD %~dp0
FOR /D /R %%X IN (%USERNAME%*) DO RD /S /Q "%%X"

REM - Run Code Coverage
Call :RunCodeCoverage

Rem - Generate & Launch Coverage Report
Call :GenerateAndLaunchCoverageReport

Rem - Generate & Launch Pickles Documents
Call :GenerateAndlaunchPicklesDocuments

:RunCodeCoverage
"%~dp0..\packages\OpenCover.4.6.519\tools\OpenCover.Console.exe" ^
-register:user ^
-target:"%VS140COMNTOOLS%\..\IDE\mstest.exe" ^
-targetargs:"/testcontainer:\"%~dp0..\GameEngine.Specs\bin\Debug\GameEngine.Specs.dll\" /resultsfile:\"%~dp0Testreport.trx\"" ^
-filter:"+[GameEngine*]* -[*]*Steps" ^
-mergebyhash ^
-skipautoprops ^
-output:"%~dp0CodeCoverage\GameEngine.Specs.xml"
exit /b %errorlevel%

:GenerateAndLaunchCoverageReport
"%~dp0..\packages\ReportGenerator.3.1.2\tools\ReportGenerator.exe" ^
-reports:"%~dp0CodeCoverage\GameEngine.Specs.xml" ^
-targetdir:"%~dp0CodeCoverage\ReportGenerator Output"

start "report" "%~dp0\CodeCoverage\ReportGenerator Output\index.htm"
exit /b %errorlevel%

:GenerateAndlaunchPicklesDocuments
"%~dp0..\packages\pickles.commandline.2.20.0\tools\pickles.exe" ^
-f:"%~dp0..\GameEngine.Specs" ^
-o:"%~dp0GeneratedReports\Html" ^
--trfmt:"mstest" ^
--lr:"%~dp0Testreport.trx" ^
--df:"Html"

start "document" "%~dp0\GeneratedReports\Html\index.html"
exit /b %errorlevel%