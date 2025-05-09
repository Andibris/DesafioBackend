# Etapa 1: build com SDK do .NET 8
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o csproj e restaura as dependências
COPY DesafioApi/DesafioApi.csproj ./DesafioApi/
RUN dotnet restore ./DesafioApi/DesafioApi.csproj

# Copia todos os arquivos
COPY . .

# Publica apenas o projeto da API
RUN dotnet publish ./DesafioApi/DesafioApi.csproj -c Release -o /app

# Etapa 2: imagem final com SDK (para permitir uso do dotnet ef no container)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app

# Instala o dotnet-ef globalmente
RUN dotnet tool install --global dotnet-ef

# Adiciona o caminho das ferramentas ao PATH
ENV PATH="${PATH}:/root/.dotnet/tools"

# Copia os arquivos da etapa de build
COPY --from=build /app .

# Expõe a porta usada no container (match com docker-compose)
EXPOSE 80

# Inicia a aplicação
ENTRYPOINT ["dotnet", "DesafioApi.dll"]