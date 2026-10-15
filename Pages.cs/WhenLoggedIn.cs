namespace WestcoastEducation;

public class WhenLoggedIn
{


    bool isLoggedIn = true;




    public void Loggedin(User user, List<User> users)
    {
        Console.Clear();


        while (isLoggedIn)
        {


            if (user is Student)
            {
                Console.WriteLine("Vill du lista kurser - tryck 1: ");
                Console.WriteLine("Vill du lista studenter - tryck 2: ");
                Console.WriteLine("Vill du logga ut - tryck 3");
                string response = InputHelper.CheckIfNullOrWhitespace("Ditt val: ");
                if (response == "1")
                {
                    ListCourses();
                }
                else if (response == "2")
                {
                    ListStudents(users);
                }
                else if (response == "3")
                {
                    isLoggedIn = false;
                }
            }

            if (user is Teacher)
            {
                Console.WriteLine("Vill du lista kurser - tryck 1: ");
                Console.WriteLine("Vill du lista studenter - tryck 2: ");
                Console.WriteLine("Vill du lägga till ny student - tryck 3: ");
                Console.WriteLine("Vill du lägga till ny kurs  - tryck 4: ");
                Console.WriteLine("Vill du logga ut - tryck 5");
                Console.WriteLine("Lägg till kurs som du ansvarar för - tryck 6");
                Console.WriteLine("Visa kurserna du är ansvarig för - tryck 7");


                Teacher teacher = (Teacher)user;


                string response = InputHelper.CheckIfNullOrWhitespace("Ditt val: ");
                if (response == "1")
                {
                    ListCourses();
                }
                else if (response == "2")
                {
                    ListStudents(users);
                }
                else if (response == "3")
                {
                    AddStudent(users);

                }

                else if (response == "4")
                {
                    AddCourse();
                }

                else if (response == "5")
                {
                    isLoggedIn = false;
                }
                else if (response == "6")
                {
                    List<Course> courses = CourseService.GetList();
                    foreach (Course course in courses)
                    {
                        Console.WriteLine($"Kursnummer: {course.CourseNumber}, Kurstitel: {course.Title}");

                    }
                    int choice = InputHelper.ReadInt("Skriv in kursnummer för att välja kurs du är ansvarig för: ");
                    bool isACourse = false;
                    foreach (Course course in courses)
                    {
                        if (choice == course.CourseNumber)
                        {
                            teacher.ResponsibleCourses.Add(course);
                            isACourse = true;
                        }
                    }
                    if (isACourse == true)
                    {
                        Console.WriteLine("Kursen är tillagd");
                    }
                    else
                    {
                        Console.WriteLine("Kursen finns inte");
                    }

                }
                else if (response == "7")
                {
                    List<Course> responsibleCourses = teacher.ResponsibleCourses;
                    if(responsibleCourses.Count > 0)
                    {
                        
                    Console.WriteLine("Du är ansvarig för: ");
                    foreach (Course course in responsibleCourses)
                    {
                        course.GetInfo();
                    }
                    }
                    else
                    {
                        Console.WriteLine("Du har inga kurser du är ansvarig för");
                    }
                }
                
                

            }


            if (user is EducationalManager or Administrator)
            {
                Console.WriteLine("Vill du lista kurser - tryck 1: ");
                Console.WriteLine("Vill du lista studenter - tryck 2: ");
                Console.WriteLine("Vill du lägga till ny student - tryck 3: ");
                Console.WriteLine("Vill du lägga till en lärare - tryck 4: ");
                Console.WriteLine("Vill du lägga till en administratör - tryck 5: ");
                Console.WriteLine("Vill du lägga till en utbildningsledare - tryck 6: ");
                Console.WriteLine("Vill du lägga till ny kurs  - tryck 7: ");
                Console.WriteLine("Vill du logga ut - tryck 8");



                string response = InputHelper.CheckIfNullOrWhitespace("Ditt val: ");
                if (response == "1")
                {
                    ListCourses();
                }
                else if (response == "2")
                {
                    ListStudents(users);
                }
                else if (response == "3")
                {
                    AddStudent(users);

                }
                else if (response == "4")
                {
                    AddStaff(users, "lärarens");

                }
                else if (response == "5")
                {
                    AddStaff(users, "administratörens");
                }
                else if (response == "6")
                {
                    AddStaff(users, "utbildningsledarens");
                }

                else if (response == "7")
                {
                    AddCourse();
                }

                else if (response == "8")
                {
                    isLoggedIn = false;
                }
                else
                {
                    Console.WriteLine("Du måste välja ett av alternativen");
                }
            }

        }


    }

    public void ListCourses()
    {

        List<Course> courses = CourseService.GetList();
        foreach (Course course in courses)
        {
            course.GetInfo();
        }
    }

    public void ListStudents(List<User> users)
    {
        foreach (User user in users)
        {
            if (user is Student)
            {
                user.GetInfo();
            }
        }
    }
    public void AddStudent(List<User> users)
    {

        string email = InputHelper.CheckIfNullOrWhitespace("Skriv in studentens emailadress");

        string password = InputHelper.CheckIfNullOrWhitespace("Välj ett lösenord, studenten kan ändra det sen: ");

        string firstName = InputHelper.CheckIfNullOrWhitespace("Vad är studentens förnamn: ");

        string lastName = InputHelper.CheckIfNullOrWhitespace("Vad är studentens efternamn: ");

        string phoneNumber = InputHelper.CheckIfNullOrWhitespace("Studentens telefonnummer: ");

        string socialSecuritynumber = InputHelper.CheckIfNullOrWhitespace("Studentens personnummer: ");

        string adress = InputHelper.CheckIfNullOrWhitespace("Studentens adress: ");

        string postalCode = InputHelper.CheckIfNullOrWhitespace("Studentens postnummer: ");

        string city = InputHelper.CheckIfNullOrWhitespace("Vilken stad bor studenten i: ");


        Student student = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, email, password);


        users.Add(student);

    }
    public void AddCourse()
    {
        int courseNumber = InputHelper.ReadInt("Vad är kursnumret?: ");
        //Console.WriteLine("Vad är kursnumret: ");
        //int courseNumber = Convert.ToInt32(Console.ReadLine());
        string title = InputHelper.CheckIfNullOrWhitespace("Vad heter kursen: ");
        //Console.WriteLine("Hur länge varar kursen: ");
        //int durationWeek = Convert.ToInt32(Console.ReadLine());
        int durationWeek = InputHelper.ReadInt("Hur länge varar kursen? (ange heltal i vecka/veckor): ");
        //Console.WriteLine("När startar kursen: ");
        //DateOnly startDate = DateOnly.Parse(Console.ReadLine());
        DateOnly startDate = InputHelper.ReadDate("När startar kursen?(svara i YYYY-MM-DD format): ");
        //Console.WriteLine("När slutar kursen: ");
        //DateOnly endDate = DateOnly.Parse(Console.ReadLine());
        DateOnly endDate = InputHelper.ReadDate("När slutar kursen?(svara i YYYY-MM-DD format): ");

        string distanceEducation = InputHelper.CheckIfNullOrWhitespace("Är kursen på distans, skriv ja eller nej: ");



        bool isDistanceEducation = false;


        if (distanceEducation == "ja")
        {
            isDistanceEducation = true;
        }



        Course course = new(courseNumber, title, durationWeek, startDate, endDate, isDistanceEducation);

        CourseService.AddCourse(course);


    }
    public void AddStaff(List<User> users, string staffName)
    {
        string email = InputHelper.CheckIfNullOrWhitespace($"Skriv in {staffName}  emailadress: ");

        string password = InputHelper.CheckIfNullOrWhitespace("Välj ett lösenord, anmvändaren kan ändra det sen: ");

        string firstName = InputHelper.CheckIfNullOrWhitespace($"Vad är {staffName} förnamn: ");

        string lastName = InputHelper.CheckIfNullOrWhitespace($"Vad är {staffName} efternamn: ");

        string phoneNumber = InputHelper.CheckIfNullOrWhitespace($"Vad är {staffName} telefonnummer: ");

        string socialSecuritynumber = InputHelper.CheckIfNullOrWhitespace($"Vad är {staffName} personnummer: ");

        string adress = InputHelper.CheckIfNullOrWhitespace($"Vad är {staffName} adress: ");

        string postalCode = InputHelper.CheckIfNullOrWhitespace($"Vad är {staffName} postnummer: ");

        string city = InputHelper.CheckIfNullOrWhitespace($"Vilken stad bor {staffName} i: ");



        //Console.WriteLine($"Vad är {staffName} anställningsdatum: ");
        //DateOnly employmentDate = DateOnly.Parse(Console.ReadLine());
        DateOnly employmentDate = InputHelper.ReadDate($"Vad är {staffName} anställningsdatum:");

        if (staffName == "lärarens")
        {
            string fieldOfKnowledge = InputHelper.CheckIfNullOrWhitespace("Vad är lärarens kunskapsområde: ");


            Teacher teacher = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, employmentDate, fieldOfKnowledge, email, password);
            users.Add(teacher);
        }
        if (staffName == "administratörens")
        {
            Administrator administrator = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, employmentDate, email, password);
            users.Add(administrator);

        }
        if (staffName == "utbildningsledarens")
        {
            EducationalManager educationalManager = new(firstName, lastName, phoneNumber, socialSecuritynumber, adress, postalCode, city, employmentDate, email, password);
            users.Add(educationalManager);
        }



    }



}
