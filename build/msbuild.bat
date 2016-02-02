set fdir=%WINDIR%\Microsoft.NET\Framework64

if not exist %fdir% (
	set fdir=%WINDIR%\Microsoft.NET\Framework
)

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer/Raven.Serializer.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithJil/Raven.Serializer.WithJil.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.WithJil"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithMsgPack/Raven.Serializer.WithMsgPack.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.WithMsgPack"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithProtobuf/Raven.Serializer.WithProtobuf.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.WithProtobuf"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithNewtonsoft/Raven.Serializer.WithNewtonsoft.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net45\Raven.Serializer.WithNewtonsoft"
pause