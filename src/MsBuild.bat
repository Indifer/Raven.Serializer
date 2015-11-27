set fdir=%WINDIR%\Microsoft.NET\Framework64

if not exist %fdir% (
	set fdir=%WINDIR%\Microsoft.NET\Framework
)

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% Raven.Serializer.Jil/Raven.Serializer.Jil.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.Jil"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% Raven.Serializer.MsgPack/Raven.Serializer.MsgPack.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.MsgPack"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% Raven.Serializer.Protobuf/Raven.Serializer.Protobuf.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.Protobuf"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% Raven.Serializer.Newtonsoft/Raven.Serializer.Newtonsoft.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.Newtonsoft"
pause