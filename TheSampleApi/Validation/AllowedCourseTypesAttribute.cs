using System.ComponentModel.DataAnnotations;

namespace TheSampleApi.Validation;
public class AllowedCourseTypesAttribute : ValidationAttribute
{
    private readonly string[] allowedCourseTypes =
    {
        "training", "accelerate", "legacy", "mastercourse", "skillcheck"
    };

    protected override ValidationResult? IsValid(
        object? value, ValidationContext validationContext)
    {
        // Required will take care of null
        if (value is null) 
            return ValidationResult.Success;

        if (value is not string StringValue) 
            return new ValidationResult("CourseType must be a string");

        if (allowedCourseTypes.Contains(StringValue, StringComparer.OrdinalIgnoreCase))
            return ValidationResult.Success;

        return new ValidationResult(
            $"CourseType must be one of: {string.Join(",", allowedCourseTypes)}");
    }
}
