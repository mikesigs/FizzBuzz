@echo off
setlocal 
set update=0
:: Parse command line arguments 
:parseArgs
if "%~1"=="" goto :endParseArgs
if /I "%~1"=="-u" goto setUpdateFlag
if /I "%~1"=="/u" goto setUpdateFlag
if /I "%~1"=="--update" goto setUpdateFlag
goto chain

:setUpdateFlag
    set update=1
    shift
    goto parseArgs
    
:chain    
    set fakeParams=%fakeParams% %1%
    shift
    goto parseArgs
    
:endParseArgs

if not exist ".paket\paket.exe" (
    echo Running paket bootstrapper...
    .paket\paket.bootstrapper.exe
    if errorlevel 1 (
        exit /b %errorlevel%
    )
)

if /I %update% equ 1 (
    echo Updating paket bootstrapper...
    .paket\paket.bootstrapper.exe --self
    if errorlevel 1 (
        exit /b %errorlevel%
    )

    echo Running paket bootstrapper...
    .paket\paket.boostrapper.exe    
    if errorlevel 1 (
        exit /b %errorlevel%
    )
)

:: Paket Install/Restore
if not exist paket.lock (
    echo Installing Paket dependencies...
    .paket\paket.exe install
) else (
    echo Restoring Paket dependencies...
    .paket\paket.exe restore
)
if errorlevel 1 (
    exit /b %errorlevel%
)

:: Run FAKE. Parameter is optional. If none specified will run Default task.
echo Starting FAKE
packages\FAKE\tools\Fake.exe %fakeParams%
