using System.ComponentModel.DataAnnotations;
using TheSampleApi.Validation;

namespace TheSampleApi.Dtos;

public record UpdateCourseDto(
    [Required] bool IsPreorder,
    [Required][StringLength(130)][Url] string CourseUrl,
    [Required][AllowedCourseTypes] string CourseType,
    [Required][StringLength(50)] string CourseName,
    [Required][Range(0, 999)] int CourseLessonCount,
    [Required][Range(0, 24)] double CourseLengthInHours,
    [Required][StringLength(130)] string ShortDescription,
    [Required][StringLength(130)][Url] string CourseImage,
    [Required][Range(0, int.MaxValue)] int PriceInUSD,
    [Required][StringLength(130)][Url] string CoursePreviewLink);
