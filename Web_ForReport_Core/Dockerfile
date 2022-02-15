#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
RUN apt-get update && apt-get install -y libgdiplus

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Web_ForReport_Core/ReportViewerCore.Sample.AspNetCore.csproj", "Web_ForReport_Core/"]
COPY ["Microsoft.ReportViewer.NETCore/Microsoft.ReportViewer.NETCore.csproj", "Microsoft.ReportViewer.NETCore/"]
COPY ["Microsoft.ReportViewer.DataVisualization/Microsoft.ReportViewer.DataVisualization.csproj", "Microsoft.ReportViewer.DataVisualization/"]
COPY ["Microsoft.ReportViewer.ProcessingObjectModel/Microsoft.ReportViewer.ProcessingObjectModel.csproj", "Microsoft.ReportViewer.ProcessingObjectModel/"]
COPY ["Microsoft.ReportViewer.Common/Microsoft.ReportViewer.Common.csproj", "Microsoft.ReportViewer.Common/"]
RUN dotnet restore "Web_ForReport_Core/ReportViewerCore.Sample.AspNetCore.csproj"
COPY . .
WORKDIR "/src/Web_ForReport_Core"
RUN dotnet build "ReportViewerCore.Sample.AspNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ReportViewerCore.Sample.AspNetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ReportViewerCore.Sample.AspNetCore.dll"]