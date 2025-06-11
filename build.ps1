# Build and Publish Script for Vidly

# Set error action preference
$ErrorActionPreference = "Stop"

# Define paths
$solutionPath = ".\vidly.sln"
$publishPath = ".\bin\Release\PublishOutput"

# Clean solution
Write-Host "Cleaning solution..." -ForegroundColor Green
& dotnet clean $solutionPath

# Restore NuGet packages
Write-Host "Restoring NuGet packages..." -ForegroundColor Green
& dotnet restore $solutionPath

# Build solution in Release mode
Write-Host "Building solution in Release mode..." -ForegroundColor Green
& dotnet build $solutionPath -c Release

# Publish the application
Write-Host "Publishing application..." -ForegroundColor Green
& dotnet publish $solutionPath -c Release -o $publishPath

# Check if publish was successful
if ($LASTEXITCODE -eq 0) {
    Write-Host "Build and publish completed successfully!" -ForegroundColor Green
    Write-Host "Published files are located at: $publishPath" -ForegroundColor Green
} else {
    Write-Host "Build or publish failed!" -ForegroundColor Red
    exit 1
} 