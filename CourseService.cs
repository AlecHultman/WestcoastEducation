namespace WestcoastEducation;
using System.Text.Json;

public static class CourseService
{
    private static string filePath = "CourseStorage.json";
    private static List<Course> courses = [];

    static CourseService()
    {
        if (File.Exists(filePath))
        {
            string jsontext = File.ReadAllText(filePath);

            courses = JsonSerializer.Deserialize<List<Course>>(jsontext)!;
        }

    }

    public static void AddCourse(Course course)
    {
        courses.Add(course);
        string json = JsonSerializer.Serialize(courses, new JsonSerializerOptions{WriteIndented = true});
        File.WriteAllText(filePath, json);
    }

    public static List<Course> GetList()
    {
        return courses;
    }

}
