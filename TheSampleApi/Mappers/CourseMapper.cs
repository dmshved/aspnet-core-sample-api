using TheSampleApi.Dtos;
using TheSampleApi.Models;

namespace TheSampleApi.Mappers;

public static class CourseMapper
{
    public static CourseModel ToModel(this CreateCourseDto dto, int id)
    {
        return new CourseModel()
        {
            Id = id,
            IsPreorder = dto.IsPreorder,
            CourseUrl = dto.CourseUrl,
            // CourseType must be lowercase
            CourseType = dto.CourseType.ToLowerInvariant(),
            CourseName = dto.CourseName,
            CourseLessonCount = dto.CourseLessonCount,
            CourseLengthInHours = dto.CourseLengthInHours,
            ShortDescription = dto.ShortDescription,
            CourseImage = dto.CourseImage,
            PriceInUSD = dto.PriceInUSD,
            CoursePreviewLink = dto.CoursePreviewLink,
        };
    }

    public static CourseDto ToDto(this CourseModel course)
    {
        return new CourseDto(
            course.Id,
            course.IsPreorder,
            course.CourseUrl,
            course.CourseType,
            course.CourseName,
            course.CourseLessonCount,
            course.CourseLengthInHours,
            course.ShortDescription,
            course.CourseImage,
            course.PriceInUSD,
            course.CoursePreviewLink);
    }

    public static void UpdateFrom(this CourseModel course, UpdateCourseDto dto)
    {
        course.IsPreorder = dto.IsPreorder;
        course.CourseUrl = dto.CourseUrl;
        // CourseType must be lowercase
        course.CourseType = dto.CourseType.ToLowerInvariant();
        course.CourseName = dto.CourseName;
        course.CourseLessonCount = dto.CourseLessonCount;
        course.CourseLengthInHours = dto.CourseLengthInHours;
        course.ShortDescription = dto.ShortDescription;
        course.CourseImage = dto.CourseImage;
        course.PriceInUSD = dto.PriceInUSD;
        course.CoursePreviewLink = dto.CoursePreviewLink;
    }
}
