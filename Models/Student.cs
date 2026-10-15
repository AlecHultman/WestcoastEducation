namespace WestcoastEducation;

public class Student : User
{
    public Student (string firstName, string lastName, string phoneNumber, string socialSecurityNumber, string adress, string postalCode, string city, string email, string password)
    : base(firstName, lastName, phoneNumber, socialSecurityNumber, adress, postalCode, city, email, password)
    {
        
    }
}
