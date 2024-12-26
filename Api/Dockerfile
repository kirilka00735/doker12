# Используем официальный образ для .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Копируем Api.csproj в текущую директорию
COPY Api.csproj ./ 

# Выполняем восстановление зависимостей
RUN dotnet restore "Api.csproj"

# Копируем все файлы в контейнер
COPY . .

# Собираем проект
WORKDIR /src
RUN dotnet build "Api.csproj" -c Release -o /app/build

# Публикуем приложение
FROM build AS publish
RUN dotnet publish "Api.csproj" -c Release -o /app/publish

# Финальный образ для запуска
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Api.dll"]
