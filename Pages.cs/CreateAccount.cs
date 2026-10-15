using System.Collections;
using System.Runtime.CompilerServices;

namespace WestcoastEducation;

public class CreateAccount


{
    public User? Useraccount()
    {
        //Användaren ska skapa konto.

        Console.Clear();

        string email = InputHelper.CheckIfNullOrWhitespace("Skriv in din emailadress: ");

        string password = InputHelper.CheckIfNullOrWhitespace("Välj ett lösenord");

        string firstName = InputHelper.CheckIfNullOrWhitespace("Förnamn");

        string lastName = InputHelper.CheckIfNullOrWhitespace("Efternamn");

        string phoneNumber = InputHelper.CheckIfNullOrWhitespace("Telefonnummer");

        string socialSecuritynumber = InputHelper.CheckIfNullOrWhitespace("Personnummer");

        string adress = InputHelper.CheckIfNullOrWhitespace("Adress");

        string postalCode = InputHelper.CheckIfNullOrWhitespace("Postnummer");

        string city = InputHelper.CheckIfNullOrWhitespace("Stad");



        Console.WriteLine("Är du lärare - tryck 1");
        Console.WriteLine("Är du student - tryck 2");
        Console.WriteLine("Är du utbildningsledare - tryck 3");
        Console.WriteLine("Är du administratör - tryck 4");

        
        string personType = InputHelper.CheckIfNullOrWhitespace("Ditt val: ");

        while (personType != "1" && personType != "2" && personType != "3" && personType != "4")
        {
            personType = InputHelper.CheckIfNullOrWhitespace("Du måste välja ett alternativ 1-4");
            
            
        }

        DateOnly employmentDate;

        switch (personType)
        {
            case "1":

                string fieldOfKnowledge = InputHelper.CheckIfNullOrWhitespace("Vilket kunskapsområde har du?: ");
                
                employmentDate = GetEmploymentDate();

                Teacher teacher = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, employmentDate, fieldOfKnowledge, email, password);
                return teacher;

            case "2":
                Student student = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, email, password);
                return student;

            case "3":
                employmentDate = GetEmploymentDate();
                EducationalManager educationalManager = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, employmentDate, email, password);
                return educationalManager;

            case "4":
                employmentDate = GetEmploymentDate();
                Administrator administrator = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, employmentDate, email, password);
                return administrator;

            default:
                return null;


        }


    }

    public DateOnly GetEmploymentDate()
    {
        DateOnly employmentDate = InputHelper.ReadDate("Vad är ditt Anställningsdatum, i format YYYY-MM-DD: ");

        return employmentDate;
    }



}


