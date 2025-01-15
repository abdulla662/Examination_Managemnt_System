using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
public enum DifficultyLevel
{
    Easy = 1,
    Medium = 2,
    Hard = 3
}


namespace EMS
{
    public class Questions
    {
        public String QuestionText;
        public String QuestionType;
        public int Mark;
        public List<string> Choices { get; set; }

        public string CorrectAnswer;
        public DifficultyLevel Difficulty { get; set; }
        public static List<Questions> questionslist = new List<Questions>();


        public Questions(DifficultyLevel difficulty = 0, string questionText = "", string questionType = "", int mark = 0, string correctAnswer = "", List<string> choices = null)
        {
            Difficulty = difficulty;
            QuestionText = questionText;
            QuestionType = questionType;
            Mark = mark;
            CorrectAnswer = correctAnswer;
            if (choices == null)
            {
                Choices = new List<string>();
            }
            else
            {
                Choices = choices;
            }

        }
        public override string ToString()
        {
            string choicesText;
            if (Choices != null && Choices.Count > 0)
            {
                choicesText = string.Join(", ", Choices);
            }
            else
            {
                choicesText = "no choices added";
            }

            return $"[Type: {QuestionType}, Marks: {Mark}, Text: {QuestionText},correctanswer: {CorrectAnswer} ,difficulty {Difficulty}]";
        }
        public void Questionare()
        {
            int typefquestion;
            Console.WriteLine("How Many Questions You Want ? (From 1 ... 6 max)");
            int numberofquestions = int.Parse(Console.ReadLine());
            if (numberofquestions < 1 || numberofquestions > 6)
            {
                Console.WriteLine("Please choose between 1 and 6 questions.");
                return;
            }

            for (int i = 0; i < numberofquestions; i++)
            {
                Console.WriteLine($"Creating Question {i + 1}");
                Console.WriteLine("what is the type of question You Want\n" + "1.True/False Question\n" + "2.Multiple Choice Question choose between (1-2-3)\n" + "3.essay question");
                int questionTypeChoice;


                try
                {
                    questionTypeChoice = int.Parse(Console.ReadLine());


                }
                catch (FormatException e)
                {
                    Console.WriteLine("error choose numbers from 1 to 3 ");
                    return;
                }
                string questionType;
                switch (questionTypeChoice)
                {
                    case 1:
                        questionType = "True/False";
                        break;
                    case 2:
                        questionType = "Multiple Choice";
                        break;
                    case 3:
                        questionType = "Essay";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        return;
                }

                Console.WriteLine("Enter the question text:");
                string questionText = Console.ReadLine();
                Console.WriteLine("Enter the question level (1 for Easy, 2 for Medium, 3 for Hard):");
                int levelChoice = int.Parse(Console.ReadLine());
                DifficultyLevel difficulty;

                if (levelChoice == 1)
                {
                    difficulty = DifficultyLevel.Easy;
                }
                else if (levelChoice == 2)
                {
                    difficulty = DifficultyLevel.Medium;
                }
                else if (levelChoice == 3)
                {
                    difficulty = DifficultyLevel.Hard;
                }
                else
                {
                    Console.WriteLine("Invalid input. Defaulting to Easy.");
                    difficulty = DifficultyLevel.Easy;
                }
                Console.WriteLine("Enter the marks for this question:");
                int marks;
                try
                {
                    marks = int.Parse(Console.ReadLine());
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value for marks.");
                    return;
                }
                string correctAnswer = "";
                List<string> choices = null;

                if (questionType == "True/False")
                {
                    Console.WriteLine("Enter the correct answer (True/False):");
                    correctAnswer = Console.ReadLine();
                }
                else if (questionType == "Multiple Choice")
                {
                    choices = new List<string>();
                    Console.WriteLine("Enter the number of choices:");
                    int choiceCount = int.Parse(Console.ReadLine());

                    for (int j = 0; j < choiceCount; j++)
                    {
                        Console.WriteLine($"Enter choice {j + 1}:");
                        choices.Add(Console.ReadLine());
                    }

                    Console.WriteLine("Enter the correct choice(s) (comma-separated for multiple correct answers):");
                    correctAnswer = Console.ReadLine();
                }
                else if (questionType == "Essay")
                {
                    Console.WriteLine("Enter a keyword or phrase that must be included in the answer:");
                    correctAnswer = Console.ReadLine();
                }
                questionslist.Add(new Questions(difficulty, questionText, questionType, marks, correctAnswer, choices));


            }
            Console.WriteLine("\nQuestions Created Successfully!");

            foreach (var question in questionslist)
            {
                Console.WriteLine(question.ToString());
            }

        }
    }
}
      


      
