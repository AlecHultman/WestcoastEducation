namespace WestcoastEducation;

public class EducationalManager : Staff
{
    public EducationalManager(string firstName, string lastName, string phoneNumber, string socialSecurityNumber, string adress, string postalCode, string city, DateOnly employmentDate, string email, string password)
    : base(firstName, lastName, phoneNumber, socialSecurityNumber, adress, postalCode, city, employmentDate, email, password)
    {

    }
}
