set fdir=%WINDIR%\Microsoft.NET\Framework64

if not exist %fdir% (
	set fdir=%WINDIR%\Microsoft.NET\Framework
)

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer/Raven.Serializer40.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net40\Raven.Serializer"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithJil/Raven.Serializer.WithJil40.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net40\Raven.Serializer.WithJil"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithMsgPack/Raven.Serializer.WithMsgPack40.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net40\Raven.Serializer.WithMsgPack"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithProtobuf/Raven.Serializer.WithProtobuf40.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net40\Raven.Serializer.WithProtobuf"

set msbuild=C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe
%msbuild% ../src/Raven.Serializer.WithNewtonsoft/Raven.Serializer.WithNewtonsoft40.csproj /t:Clean;Rebuild /p:Configuration=Release;VisualStudioVersion=12.0;OutputPath="..\..\output\net40\Raven.Serializer.WithNewtonsoft"
pause