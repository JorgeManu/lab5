# Usa la imagen base de .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Establece el directorio de trabajo en el contenedor
WORKDIR /src

# Copia el archivo Program.cs desde la máquina local al contenedor
COPY . .

# Cambia al directorio de la aplicación
RUN dotnet restore "BlazingPizza.csproj"

RUN dotnet build "BlazingPizza.csproj" -c Release -o /app/build

RUN dotnet publish "BlazingPizza.csproj" -c Release -o /app/public

# Usa una imagen más ligera para el runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0

# Establece el directorio de trabajo en el contenedor final
WORKDIR /app

# Copia los archivos publicados desde la etapa de construcción
COPY --from=build /app/public .

# Configura la variable de entorno
ENV ASPNETCORE_ENVIRONMENT=Development

EXPOSE 5000

# Define el comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "BlazingPizza.dll", "--urls", "http://0.0.0.0:5000"]