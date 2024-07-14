// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Blazor.Models - MustNotBeGreaterThanAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/07/07
// ==================================

using System.Reflection;

namespace AutoLot.Blazor.Models.Validation;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class MustNotBeGreaterThanAttribute(
string otherPropertyName, 
string errorMessage)
    : ValidationAttribute(errorMessage)
{
    private string _otherPropertyDisplayName;
    public MustNotBeGreaterThanAttribute(string otherPropertyName)
        : this(otherPropertyName, "{0} must not be greater than {1}")
		 { 
		 }

    public override string FormatErrorMessage(string name) 
        => string.Format(ErrorMessageString, name, _otherPropertyDisplayName);

    internal void SetOtherPropertyName(PropertyInfo otherPropertyInfo)
    {
        _otherPropertyDisplayName = 
            otherPropertyInfo.GetCustomAttributes<DisplayAttribute>().FirstOrDefault()?.Name
            ?? otherPropertyInfo.GetCustomAttributes<DisplayNameAttribute>()
			.FirstOrDefault()?.DisplayName
            ?? otherPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType.GetProperty(otherPropertyName);
        if (otherPropertyInfo == null)
        {
            return new ValidationResult("Unable to validate property. Please contact support");
        }

        SetOtherPropertyName(otherPropertyInfo);
        if (!int.TryParse(value?.ToString(), out int toValidate))
        {
            return new ValidationResult($"{validationContext.DisplayName} must be numeric.",
                new[] { validationContext.MemberName, otherPropertyName });
        }

        var otherPropObjectValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (otherPropObjectValue == null || !int.TryParse(otherPropObjectValue.ToString(),
                out var otherValue))
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName),
                new[] { validationContext.MemberName, otherPropertyName });
        }

        return toValidate > otherValue
            ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName),
                new[] { validationContext.MemberName, otherPropertyName })
            : ValidationResult.Success;
    }
}