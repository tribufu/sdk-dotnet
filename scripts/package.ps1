#!/usr/bin/env sh

dotnet clean
dotnet build -c Release
dotnet pack
