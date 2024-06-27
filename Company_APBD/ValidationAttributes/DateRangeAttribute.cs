namespace Company_APBD.ValidationAttributes;

using System;
using System.ComponentModel.DataAnnotations;

public class DateRangeAttribute : ValidationAttribute
{
    private readonly int _minDays;
    private readonly int _maxDays;

    public DateRangeAttribute(int minDays, int maxDays)
    {
        _minDays = minDays;
        _maxDays = maxDays;
    }
    

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var endDateProperty = validationContext.ObjectType.GetProperty("EndDate");
        if (endDateProperty == null)
            throw new ArgumentException("Property EndDate not found");

        var endDate = (DateTime)endDateProperty.GetValue(validationContext.ObjectInstance);

        if (value is DateTime startDate)
        {
            var difference = (endDate - startDate).TotalDays;

            if (difference < _minDays)
            {
                return new ValidationResult($"The difference between StartDate and EndDate should be at least {_minDays} days.");
            }
            if (difference > _maxDays)
            {
                return new ValidationResult($"The difference between StartDate and EndDate should not exceed {_maxDays} days.");
            }
        }

        return ValidationResult.Success;
    }
}
