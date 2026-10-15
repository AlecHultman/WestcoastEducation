namespace WestcoastEducation;

public class Teacher : Staff // Även lärare fick anställningsdatum ifrån Staff.
{
    public string FieldOfKnowledge { get; set; } = "";
    public List<Course> ResponsibleCourses { get; set; } = [];

    public Teacher(string firstName, string lastName, string phoneNumber, string socialSecurityNumber, string adress, string postalCode, string city, DateOnly employmentDate, string fieldOfKnowledge, string email, string password)
    : base(firstName, lastName, phoneNumber, socialSecurityNumber, adress, postalCode, city, employmentDate, email, password)
    {
        FieldOfKnowledge = fieldOfKnowledge;
    }

     public override void GetInfo()
    {
        Console.WriteLine($"Förnamn: {FirstName}, Efternamn: {LastName}, Telefonnummer: {PhoneNumber}, Personnummer: {SocialSecurityNumber} Adress: {Address.Street}, {Address.PostalCode}, {Address.City}, Email: {Email}, Anställningsdatum: {EmploymentDate}, Kunskapsområde: {FieldOfKnowledge}");
    }
}
