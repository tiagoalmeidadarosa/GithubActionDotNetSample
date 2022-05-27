# Set the base image as the .NET 6.0 SDK (this includes the runtime)
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build-env

# Copy everything and publish the release (publish implicitly restores and builds)
COPY . ./
RUN dotnet publish ./GithubActionDotNetSample/GithubActionDotNetSample.csproj -c Release -o out --no-self-contained

# Label as GitHub action
LABEL com.github.actions.name="Github Action DotNet Sample"
LABEL com.github.actions.description="A Github action written in C# that serves as a usage example."
LABEL com.github.actions.icon="upload"
LABEL com.github.actions.color="blue"

# Relayer the .NET SDK, anew with the build output
FROM mcr.microsoft.com/dotnet/sdk:6.0
COPY --from=build-env /out .
ENTRYPOINT [ "dotnet", "/GithubActionDotNetSample.dll" ]
