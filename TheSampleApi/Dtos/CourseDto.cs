using System.ComponentModel.DataAnnotations;

namespace TheSampleApi.Dtos;

public record CourseDto(
    [Required] int Id,
    [Required] bool IsPreorder,
    [Required] string CourseUrl,
    [Required] string CourseType,
    [Required] string CourseName,
    [Required] int CourseLessonCount,
    [Required] double CourseLengthInHours,
    [Required] string ShortDescription,
    [Required] string CourseImage,
    [Required] int PriceInUSD,
    [Required] string CoursePreviewLink);