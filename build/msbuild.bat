::set fdir=%WINDIR%\Microsoft.NET\Framework64

::if not exist %fdir% (
::	set fdir=%WINDIR%\Microsoft.NET\Framework
::)

set msbuild="C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\msbuild.exe"

%msbuild% ../src/Raven.Serializer/Raven.Serializer.csproj /t:Clean;Rebuild /p:Configuration=Release
xcopy ..\src\Raven.Serializer\bin\Release ..\output\Raven.Serializer /i /e /y

%msbuild% ../src/Raven.Serializer.WithNewtonsoft/Raven.Serializer.WithNewtonsoft.csproj /t:Clean;Rebuild /p:Configuration=Release
xcopy ..\src\Raven.Serializer.WithNewtonsoft\bin\Release ..\output\Raven.Serializer.WithNewtonsoft /i /e /y

%msbuild% ../src/Raven.Serializer.WithJil/Raven.Serializer.WithJil.csproj /t:Clean;Rebuild /p:Configuration=Release
xcopy ..\src\Raven.Serializer.WithJil\bin\Release ..\output\Raven.Serializer.WithJil /i /e /y

%msbuild% ../src/Raven.Serializer.WithMessagePack/Raven.Serializer.WithMessagePack.csproj /t:Clean;Rebuild /p:Configuration=Release
xcopy ..\src\Raven.Serializer.WithMessagePack\bin\Release ..\output\Raven.Serializer.WithMessagePack /i /e /y

%msbuild% ../src/Raven.Serializer.WithMsgPackCli/Raven.Serializer.WithMsgPackCli.csproj /t:Clean;Rebuild /p:Configuration=Release
xcopy ..\src\Raven.Serializer.WithMsgPackCli\bin\Release ..\output\Raven.Serializer.WithMsgPackCli /i /e /y

%msbuild% ../src/Raven.Serializer.WithProtobuf/Raven.Serializer.WithProtobuf.csproj /t:Clean;Rebuild /p:Configuration=Release
xcopy ..\src\Raven.Serializer.WithProtobuf\bin\Release ..\output\Raven.Serializer.WithProtobuf /i /e /y

pause