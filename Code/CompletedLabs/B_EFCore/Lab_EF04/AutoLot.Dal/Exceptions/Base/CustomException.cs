﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Dal - CustomException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/05/23
// ==================================

namespace AutoLot.Dal.Exceptions.Base;

public class CustomException : Exception
{
    public CustomException() {}
    public CustomException(string message) : base(message) {}
    public CustomException(string message, Exception innerException)
        : base(message, innerException) {}
}
