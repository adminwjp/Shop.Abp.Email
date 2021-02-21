#package 自定义的 麻烦 路劲 同一目录 根级下操作 可行. 自定义 nuget 服务器 配置地址 单机器 内存吃不起 打开 gitlab nutex 内存爆炸 
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
#WORKDIR /src
#COPY ["Shop.Abp.Email.Api.csproj", "./"]
#
#RUN dotnet restore "./Shop.Abp.Email.Api.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "Shop.Abp.Email.Api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "Shop.Abp.Email.Api.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "Shop.Abp.Email.Api.dll"]


#使用 publish 包 运行  项目多话 自动化操作 
#好像只能用小写 自动 转小写 
#docker build -t ShopAbpEmailApiv1 .
#docker run -t -d -p 80:5000 ShopAbpEmailApi:v1
#down 
#FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
#WORKDIR /app

#linux docker It was not possible to find any compatible framework version
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
#端口不能一致 
EXPOSE 801


FROM base AS final
WORKDIR /app
COPY  . /app/out/ShopAbpEmailApi
WORKDIR /app/out/ShopAbpEmailApi 
ENTRYPOINT ["dotnet", "Shop.Abp.Email.Api.dll"]