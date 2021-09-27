rem USING MSVC VER. 19.29.30133 for x86

@echo off

set SRC_DIR= "..\Src\main.c"

if "%1" == "release" GOTO release

rem ----------- DEBUG BUILD ---------------
if not exist "..\DebugBuild" (
    mkdir "..\DebugBuild"
)

set BUILD_DIR= "..\DebugBuild"

pushd %BUILD_DIR%

cl -Od -Z7 -nologo -FC %SRC_DIR% /link /OUT:EstoqueOperacional.exe

popd

EXIT /b 0


rem -------- RELEASE BUILD ---------
:release

if not exist "..\ReleaseBuild" (
    mkdir "..\ReleaseBuild"
)

set BUILD_DIR= "..\ReleaseBuild"

pushd %BUILD_DIR%

cl -nologo %SRC_DIR% /link /OUT:EstoqueOperacional.exe

del *.obj

popd

EXIT /b 0