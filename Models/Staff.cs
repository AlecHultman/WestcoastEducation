namespace WestcoastEducation;

public class Staff : User
{
    public DateOnly EmploymentDate { get; set; }
    // construktorn och dess argument.
    public Staff(string firstName, string lastName, string phoneNumber, string socialSecurityNumber, string adress, string postalCode, string city, DateOnly employmentDate, string email, string password)
    //vilka kommer från basklassen (person)
    : base(firstName, lastName, phoneNumber, socialSecurityNumber, adress, postalCode, city, email, password)
    {
        EmploymentDate = employmentDate;
    }


 public override void GetInfo()
    {
        Console.WriteLine($"Förnamn: {FirstName}, Efternamn: {LastName}, Telefonnummer: {PhoneNumber}, Personnummer: {SocialSecurityNumber} Adress: {Address.Street}, {Address.PostalCode}, {Address.City}, Email: {Email}, Anställningsdatum: {EmploymentDate}");
    }

}

