namespace WestcoastEducation;

public class User : IPresentable
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string PhoneNumber { get; set; }
    public string SocialSecurityNumber { get; set; }
    public Address Address { get; set; }    
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";

    public User(string firstName, string lastName, string phoneNumber, string socialSecurityNumber, string address, string postalCode, string city, string email, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        SocialSecurityNumber = socialSecurityNumber;               
        Email = email;
        Password = password;
        Address = new Address( address, postalCode, city);

    }

    public virtual void GetInfo()
    {
        Console.WriteLine( $"Förnamn: {FirstName}, Efternamn: {LastName}, Telefonnummer: {PhoneNumber}, Personnummer: {SocialSecurityNumber} Adress: {Address.Street}, {Address.PostalCode}, {Address.City}, Email: {Email}");
    }


}
