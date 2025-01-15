using System.Xml.Linq;

namespace EMS
{
 

    public enum UserType
    {
        Student,
        Teacher
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) {
                Console.WriteLine("please choose student or teacher Mode T/S ?");
                try
                {
                    char response = char.Parse(Console.ReadLine().ToUpper());
                    UserType userType;
                    if (response == 'S')
                    {
                        char c = '\u263a';
                        Console.WriteLine(c.ToString());
                        userType = UserType.Student;
                        Console.WriteLine("You selected: " + userType);
                        student student = new student();
                        student.TakeExam();





                    }
                    else if (response == 'T')
                    {
                        userType = UserType.Teacher;
                        Console.WriteLine("You selected: " + userType);
                        Teacher usermethod = new Teacher();
                        Console.WriteLine(usermethod.Login());
                        Questions question = new Questions();
                        Console.WriteLine("");
                        question.Questionare();


                    }
                    else
                    {
                        Console.WriteLine("Invalid selection. Please enter 'S' for Student or 'T' for Teacher.");
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a single character (S or T).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An unexpected error occurred: " + ex.Message);
                }
                Console.WriteLine("\nWould you like to continue? (Y/N)");
                char continueResponse = char.Parse(Console.ReadLine().ToUpper());
                if (continueResponse != 'Y')
                {
                    Console.WriteLine("Exiting the program. Goodbye!");
                    break;
                }


            }
        }
    }

}
