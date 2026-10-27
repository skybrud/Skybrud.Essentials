@echo off
dotnet build src/Skybrud.Essentials --configuration Debug /t:rebuild /t:pack -p:PackageOutputPath=c:/nuget