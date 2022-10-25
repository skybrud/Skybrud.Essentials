@echo off
dotnet build src/Skybrud.Essentials --configuration Debug /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=c:/nuget