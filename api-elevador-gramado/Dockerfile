# Use a imagem base oficial do .NET 7 SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

# Defina o diretório de trabalho dentro do container
WORKDIR /app

# Copie os arquivos de projeto para o diretório de trabalho
COPY . ./

# Restaure as dependências
RUN dotnet restore

# Compile a aplicação
RUN dotnet publish -c Release -o out

# Use a imagem base oficial do .NET 7 runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime

# Defina o diretório de trabalho dentro do container
WORKDIR /app

# Copie os binários da fase de build para a fase de runtime
COPY --from=build /app/out .

# Exponha a porta 5000 para acesso externo
EXPOSE 5000

# Defina o comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "ApiElevadorGramado.dll"]

# Substitua 'SuaApi.dll' pelo nome correto do seu arquivo .dll
