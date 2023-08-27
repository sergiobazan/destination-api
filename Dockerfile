FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

# COPY ./*.csproj ./
COPY ["PC2.API/si730pc2u201624050.API.csproj", "PC2.API/"]
COPY ["PC2.Domain/si730pc2u201624050.Domain.csproj", "PC2.Domain/"]
COPY ["PC2.Infraestructure/si730pc2u201624050.Infraestructure.csproj", "PC2.Infraestructure/"]
COPY ["PC2.Shared/PC2.Shared.csproj", "PC2.Shared/"]
RUN dotnet restore "PC2.API/si730pc2u201624050.API.csproj"

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final-env
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT [ "dotnet", "si730pc2u201624050.API.dll" ]