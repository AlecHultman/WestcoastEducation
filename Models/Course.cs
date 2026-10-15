namespace WestcoastEducation;

public class Course :IPresentable
{
    public int CourseNumber { get; set; }
    public string Title { get; set; } = "";
    public int DurationWeek { get; set; }
    public DateOnly Startdate { get; set; }
    public DateOnly Enddate { get; set; }
    public bool IsDistanceEducation {get; set;}



    public Course(int courseNumber, string title, int durationWeek, DateOnly startDate, DateOnly endDate, bool isDistanceEducation)
    {
        CourseNumber = courseNumber;
        Title = title;
        DurationWeek = durationWeek;
        Startdate = startDate;
        Enddate = endDate;
        IsDistanceEducation = isDistanceEducation;

    }

    public void GetInfo()
    {
        string distanceEducation;
            if(IsDistanceEducation == true)
            {
                distanceEducation = "ja";
            }
            else
            {
                distanceEducation = "nej";
            }
        Console.WriteLine( $"Kursnummer: {CourseNumber}, Kursnamn: {Title}, Kurslängd: {DurationWeek}, Startdatum: {Startdate}, Slutdatum: {Enddate}, Distanskurs: {distanceEducation}");
    }


}


