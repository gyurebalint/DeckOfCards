# Set the base image to the official .NET 6 SDK image
# Set the base image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000

# Copy the solution file and restore dependencies
COPY *.sln .
COPY DeckOfCards/*.csproj ./DeckOfCards/
COPY DeckOfCardsLibrary/*.csproj ./DeckOfCardsLibrary/
COPY DeckOfCardsLibraryTests/*.csproj ./DeckOfCardsLibraryTests/
RUN dotnet restore

# Copy the remaining source code
COPY . .

# Build the solution
RUN dotnet build -c Release --no-restore

# Run the tests
RUN dotnet test --no-restore --verbosity normal --no-build

# Publish the projects
RUN dotnet publish DeckOfCards/DeckOfCards.csproj -c Release -o /app/publish/DeckOfCards
RUN dotnet publish DeckOfCardsLibrary/DeckOfCardsLibrary.csproj -c Release -o /app/publish/DeckOfCardsLibrary

# Set the runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/publish/DeckOfCards .
COPY --from=build /app/publish/DeckOfCardsLibrary .

# Set the entry point
ENTRYPOINT ["dotnet", "DeckOfCards.dll"]



# FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
# WORKDIR /app
# EXPOSE 5000

# ENV ASPNETCORE_URLS=http://+:5000

# # Creates a non-root user with an explicit UID and adds permission to access the /app folder
# # For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
# RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
# USER appuser

# FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
# WORKDIR /src
# COPY ["DeckOfCards/DeckOfCards.csproj", "DeckOfCards/"]
# RUN dotnet restore "DeckOfCards/DeckOfCards.csproj"
# COPY . .
# WORKDIR "/src/DeckOfCards"
# RUN dotnet build "DeckOfCards.csproj" -c Release -o /app/build

# FROM build AS publish
# RUN dotnet publish "DeckOfCards.csproj" -c Release -o /app/publish /p:UseAppHost=false

# FROM base AS final
# WORKDIR /app
# COPY --from=publish /app/publish .
# ENTRYPOINT ["dotnet", "DeckOfCards.dll"]
