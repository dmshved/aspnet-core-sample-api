using System.Text.Json;
using TheSampleApi.Models;

namespace TheSampleApi.Data;

public class CourseData
{
    public List<CourseModel> Courses { get; private set; } = new();
    private readonly string _filePath;
    private readonly JsonSerializerOptions _options;

    public CourseData()
    {
        _options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        _filePath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Data",
            "coursedata.json");

        Load();
    }

    private void Load()
    {
        string json = File.ReadAllText(_filePath);
        Courses = JsonSerializer.Deserialize<List<CourseModel>>(json, _options) ?? new();
    }

    public void SaveChanges()
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        string json = JsonSerializer.Serialize(Courses, options);
        File.WriteAllText(_filePath, json);
    }
}