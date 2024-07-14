﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - GlobalUsings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

global using AutoLot.Dal.Repos;
global using AutoLot.Dal.Repos.Base;
global using AutoLot.Dal.Repos.Interfaces;
global using AutoLot.Dal.Repos.Interfaces.Base;

global using AutoLot.Models.Entities;
global using AutoLot.Models.Entities.Base;

global using AutoLot.Services.ApiWrapper; 
global using AutoLot.Services.ApiWrapper.Base; 
global using AutoLot.Services.ApiWrapper.Configuration; 
global using AutoLot.Services.ApiWrapper.Interfaces;
global using AutoLot.Services.ApiWrapper.Interfaces.Base;
global using AutoLot.Services.ApiWrapper.Models;
global using AutoLot.Services.DataServices;
global using AutoLot.Services.DataServices.Api; 
global using AutoLot.Services.DataServices.Api.Base;
global using AutoLot.Services.DataServices.Dal;
global using AutoLot.Services.DataServices.Dal.Base;
global using AutoLot.Services.DataServices.Interfaces;
global using AutoLot.Services.DataServices.Interfaces.Base;
global using AutoLot.Services.Logging;
global using AutoLot.Services.Logging.Interfaces;
global using AutoLot.Services.Logging.Settings;
global using AutoLot.Services.Simple;
global using AutoLot.Services.Simple.Interfaces;
global using AutoLot.Services.Validation;
global using AutoLot.Services.ViewModels;
global using AutoLot.Services.ViewModels.Base;

global using Microsoft.AspNetCore.Builder;
global using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Logging;
global using Microsoft.Extensions.Options; 

global using Serilog;
global using Serilog.Context;
global using Serilog.Core.Enrichers;
global using Serilog.Events;
global using Serilog.Sinks.MSSqlServer;

global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;
global using System.Data;
global using System.Diagnostics;
global using System.Net.Http.Headers;
global using System.Net.Http.Json;
global using System.Reflection;
global using System.Runtime.CompilerServices;
global using System.Text; 
global using System.Text.Json;
