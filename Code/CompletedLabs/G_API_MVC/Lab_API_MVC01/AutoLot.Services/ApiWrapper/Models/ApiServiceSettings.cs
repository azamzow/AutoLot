﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - ApiServiceSettings.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Services.ApiWrapper.Models;

public class ApiServiceSettings
{
    public ApiServiceSettings() { }
    public string Uri { get; set; }
    public string CarBaseUri { get; set; }
    public string MakeBaseUri { get; set; }
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public string Status { get; set; }
    public string ApiVersion
        => $"{MajorVersion}.{MinorVersion}"
           + (!string.IsNullOrEmpty(Status) ? $"-{Status}" : string.Empty);
}
