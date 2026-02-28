    using TheSampleApi.Data;
using TheSampleApi.Dtos;
using TheSampleApi.Mappers;
using TheSampleApi.Models;

namespace TheSampleApi.Endpoints;

public static class CourseEndpoints
{
    private const string LoadCourseByIdEnpointName = "LoadCourseById";

    public static void AddCourseEndpoints(this WebApplication app)
    {
        app.MapGet("/courses", LoadAllCoursesAsync);
        app.MapGet("/courses/{id}", LoadCourseById).WithName(LoadCourseByIdEnpointName);
        app.MapPost("/courses", CreateCourse);
        app.MapPut("/course/{id}", UpdateCourse);
        app.MapDelete("/course/{id}", DeleteCourse);
    }

    // WARNING: The delay value is for educational purposes only!
    // WARNING: Don't use .RemoveAll() with relational databases!
    //          In this example the source of data is JSON, therefore .RemoveAll() is preferable
    //          .RemoveAll() shows better perfomance because it doesn't create a new list 
    //          (LINQ .Where() api does create a new lists so its slower on big data)
    private static async Task<IResult> LoadAllCoursesAsync(
        CourseData data,
        string? courseType,
        string? search,
        int? delay)
    {
        var courses = data.Courses;

        if (string.IsNullOrWhiteSpace(courseType) == false)
        {
            courses.RemoveAll(x => string.Compare(
                x.CourseType,
                courseType,
                StringComparison.OrdinalIgnoreCase) != 0);
        }

        if (string.IsNullOrWhiteSpace(search) == false)
        {
            courses.RemoveAll(x => !x.CourseName.Contains(search, StringComparison.OrdinalIgnoreCase) && 
                !x.ShortDescription.Contains(search, StringComparison.OrdinalIgnoreCase));
        }

        // Educational purposes only
        if (delay is not null)
        {
            // Max delay of 5 minutes (300,000 milliseconds)
            if (delay > 300_000)
                delay = 300_000;

            await Task.Delay((int)delay);
        }

        var output = courses.Select(x => x.ToDto()).ToList();

        return Results.Ok(output);
    }

    private static IResult LoadCourseById(CourseData data, int id)
    {
        var course = data.Courses.FirstOrDefault(x => x.Id == id);

        if (course is null) return Results.NotFound();

        CourseDto output = course.ToDto();

        return Results.Ok(output);
    }

    private static IResult CreateCourse(CreateCourseDto newData, CourseData data)
    {
        // Autoincrement Id by the biggest id found in the list
        CourseModel course = newData.ToModel(
            data.Courses.Any() ? data.Courses.Max(x => x.Id) + 1 : 1);

        data.Courses.Add(course);
        data.SaveChanges();

        CourseDto courseDto = course.ToDto();

        return Results.CreatedAtRoute(LoadCourseByIdEnpointName, new {id = course.Id}, courseDto);
    }

    private static IResult UpdateCourse(int id, UpdateCourseDto newData , CourseData data)
    {
        var course = data.Courses.FirstOrDefault(x => x.Id == id);

        if (course is null) return Results.NotFound();

        course.UpdateFrom(newData);
        data.SaveChanges();

        return Results.NoContent();
    }

    private static IResult DeleteCourse(int id, CourseData data)
    {
        var course = data.Courses.FirstOrDefault(x => x.Id == id);

        if (course is null) return Results.NotFound();

        // Delete found course in the list
        data.Courses.Remove(course);
        data.SaveChanges();

        return Results.NoContent();
    }
}
