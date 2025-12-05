# ----------------------------------------------------
# Etapa 1: Build (Construcción)
# ----------------------------------------------------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Usamos /source como directorio de trabajo para evitar confusiones
WORKDIR /source

# 1. Copiar archivos de proyecto (.csproj)
# Importante: Copiamos manteniendo la estructura de directorios, 
# pero quitamos el primer "src/" para que en el contenedor quede más limpio.
# Ejemplo: Host "src/API/API.csproj" -> Contenedor "/source/API/API.csproj"

COPY src/API/API.csproj API/
COPY src/Core.Application/Core.Application.csproj Core.Application/
COPY src/Core.Domain/Core.Domain.csproj Core.Domain/
COPY src/Infrastructure/Infrastructure.csproj Infrastructure/

# 2. Restaurar dependencias
# LE INDICAMOS EL PROYECTO PRINCIPAL. Al restaurar este, él sabe buscar 
# los otros proyectos (Domain, Infra, etc) gracias a que mantuvimos la estructura de carpetas.
RUN dotnet restore API/API.csproj

# 3. Copiar el resto del código fuente
# Copiamos todo el contenido de la carpeta 'src' del host a '/source' en el contenedor
COPY src/ .

# 4. Publicar la aplicación
RUN dotnet publish API/API.csproj -c Release -o /app/publish

# ----------------------------------------------------
# Etapa 2: Final (Ejecución)
# ----------------------------------------------------
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final

WORKDIR /app

# Copia los archivos publicados desde la etapa de construcción
COPY --from=build /app/publish .

# Define el punto de entrada
ENTRYPOINT ["dotnet", "API.dll"]