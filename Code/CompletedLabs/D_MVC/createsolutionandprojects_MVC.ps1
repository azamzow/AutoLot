rem create the ASP.NET Core Web App (MVC) project and add it to the solution
dotnet new mvc -lang c# -n AutoLot.Mvc -au none -o .\AutoLot.Mvc -f net8.0
dotnet sln AutoLot.sln add AutoLot.Mvc
dotnet add AutoLot.Mvc reference AutoLot.Models
dotnet add AutoLot.Mvc reference AutoLot.Dal
dotnet add AutoLot.Mvc reference AutoLot.Services

rem add packages
dotnet add AutoLot.Mvc package AutoMapper -v '[12.0.*,13.0)'
dotnet add AutoLot.Mvc package System.Text.Json -v '[8.0.*,9.0)' 
dotnet add AutoLot.Mvc package LigerShark.WebOptimizer.Core -v '[3.0.*,4)'
dotnet add AutoLot.Mvc package Microsoft.Web.LibraryManager.Build -v '[2.1.*,3.0)'
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.SqlServer -v '[8.0.*,9.0)'
dotnet add AutoLot.Mvc package Microsoft.EntityFrameworkCore.Design -v '[8.0.*,9.0)'
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Web.CodeGeneration.Design -v '[8.0.*,9.0)'
dotnet add AutoLot.Mvc package Microsoft.VisualStudio.Threading.Analyzers -v '[17.*,18.0)'
pause
