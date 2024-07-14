#!/usr/bin/env bash

echo "create the ASP.NET Core Web App (MVC) project and add it to the solution"
dotnet new mvc -lang c# -n AutoLot.Mvc -au none -o AutoLot.Mvc -f net8.0
dotnet sln AutoLot.sln add AutoLot.Mvc
dotnet add AutoLot.Mvc reference AutoLot.Models
dotnet add AutoLot.Mvc reference AutoLot.Dal
dotnet add AutoLot.Mvc reference AutoLot.Services

echo "add packages"
dotnet add AutoLot.Mvc package AutoMapper
dotnet add AutoLot.Mvc package System.Text.Json  
dotnet add AutoLot.Mvc package LigerShark.WebOptimizer.Core
dotnet add AutoLot.Mvc package Microsoft.Web.LibraryManager.Build
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore  
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.Design  
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.SqlServer  
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Web.CodeGeneration.Design  
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Threading.Analyzers 

read -p "Press Enter to continue" </dev/ttyc
