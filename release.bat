@echo off
dotnet build src/Skybrud.Essentials --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget