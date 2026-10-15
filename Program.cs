using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace WestcoastEducation;

class Program
{
    static void Main(string[] args)
    {

        List<User> users = [];
        //Detta är en testanvändare, för att slippa skapa nytt konto varje gång.
        Administrator testUser = new("Test", "Testsson", "02022", "19800000", "hejvägen", "24111", "malmo", new DateOnly(2026, 01, 01), "email", "1234");
        users.Add(testUser);

        bool isRunning = true;

        while (isRunning)
        {

            Console.WriteLine("==================================================================");
            Console.WriteLine("HEJ! Välkommen till WestcoastEducation");
            Console.WriteLine("Välj ett av följande alternativ: ");
            Console.WriteLine("Logga in - tryck 1");
            Console.WriteLine("Skapa konto - tryck 2");
            Console.WriteLine("Tryck Q för att avsluta!");
            string response = InputHelper.CheckIfNullOrWhitespace("Ditt val:");






            if (response == "1")
            {
                // Användaren Loggar in.
                User? logInUser = null;

                while (logInUser == null)
                {

                    string email = InputHelper.CheckIfNullOrWhitespace("SKriv in din email");
                    string password = InputHelper.CheckIfNullOrWhitespace("Skriv in ditt lösenord");






                    foreach (User user in users)
                    {


                        if (user.Email == email && user.Password == password)
                        {

                            logInUser = user;
                            break;


                        }

                    }

                    if (logInUser != null)
                    {
                        WhenLoggedIn whenLoggedIn = new();
                        whenLoggedIn.Loggedin(logInUser, users);
                    }
                    else
                    {
                        string wantToTryAgain = InputHelper.CheckIfNullOrWhitespace("fel användarnamn eller lösenord. Vill du fösöka igen?(J/N)");


                        if (wantToTryAgain.ToUpper() == "N")
                        {
                            break;
                        }
                    }

                }



            }
            else if (response == "2")
            {


                CreateAccount createAccount = new();

                // hämtar inforationen från metoden useraccount och sparar den i user.
                User? user = createAccount.Useraccount();
                //Listans namn och lägg till.
                if (user != null)
                {
                    users.Add(user);

                    WhenLoggedIn whenLoggedIn = new();
                    whenLoggedIn.Loggedin(user, users);
                }




            }
            else if (response.ToUpper() == "Q")
            {
                isRunning = false;
            }

            else
            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }

        }


    }


}
