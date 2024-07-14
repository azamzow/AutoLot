// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Services - MustNotBeGreaterThanAttribute.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2024/06/30
// ==================================

namespace AutoLot.Services.Validation;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class MustNotBeGreaterThanAttribute(string otherPropertyName, string errorMessage, string prefix)
    : ValidationAttribute(errorMessage), IClientModelValidator
{
    readonly string _otherPropertyName = otherPropertyName;
    string _otherPropertyDisplayName = otherPropertyName;
    readonly string _prefix = prefix;

    public MustNotBeGreaterThanAttribute(string otherPropertyName, string prefix = "")
        : this(otherPropertyName, "{0} must not be greater than {1}", prefix)
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
            ?? _otherPropertyName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherPropertyName);
        if (otherPropertyInfo == null)
        {
            return new ValidationResult("Unable to validate property. Please contact support",
                new[] { validationContext.MemberName, otherPropertyName });
        }

        SetOtherPropertyName(otherPropertyInfo);
        if (value is not int intValue)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName),
                new[] { validationContext.MemberName, otherPropertyName });
        }

        var otherPropObjectValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
        if (otherPropObjectValue is not int otherValue)
        {
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName),
                new[] { validationContext.MemberName, otherPropertyName });
        }

        return intValue > otherValue
            ? new ValidationResult(FormatErrorMessage(validationContext.DisplayName),
                new[] { validationContext.MemberName, otherPropertyName })
            : ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        string propertyDisplayName = context.ModelMetadata.GetDisplayName();
        var propertyInfo = context.ModelMetadata.ContainerType.GetProperty(_otherPropertyName);
        SetOtherPropertyName(propertyInfo);
        string errorMessage = FormatErrorMessage(propertyDisplayName);
        context.Attributes.Add("data-val-notgreaterthan", errorMessage);
        context.Attributes.Add("data-val-notgreaterthan-otherpropertyname", _otherPropertyName);
        context.Attributes.Add("data-val-notgreaterthan-prefix", _prefix);
        context.Attributes.Add("data-val-notgreaterthan-reevaluate", "true");
    }
}