namespace EMS
{
    public class student {
   

        string st_name { get; set; }
        double st_score { get; set; }
        public static List<student> studentdata { get; set; }
        public student(string st_name="", double st_score=0)
        {
            this.st_name = st_name;
            this.st_score = st_score;
            if (studentdata == null)
            {
                studentdata = new List<student>();
            }
        }
        public override string ToString()
        {
            return $"[StduentName: {st_name}, Marks: {st_score}";

        }
        public void TakeExam()
        {
            Console.WriteLine("please enter Your Name ");
            string answer=Console.ReadLine();
            Console.WriteLine("connecting...");
            Thread.Sleep(3000);             //https://stackoverflow.com/questions/20082221/when-to-use-task-delay-when-to-use-thread-sleep //
            Console.WriteLine("");
            Console.WriteLine("connected !");


            if (Questions.questionslist.Count == 0)
            {
                Console.WriteLine("No questions available. Please ask the teacher to create questions first.");
                return;
            }

            int totalMarks = 0;
            int obtainedMarks = 0;

            Console.WriteLine("\nAnswer the following questions:");

            foreach (var question in Questions.questionslist)
            {
                Console.WriteLine($"\n{question.QuestionText}");

                if (question.QuestionType == "True/False")
                {
                    Console.WriteLine("Answer (True/False):");
                }
                else if (question.QuestionType == "Multiple Choice")
                {
                    Console.WriteLine("Choices:");
                    for (int i = 0; i < question.Choices.Count; i++)
                    {
                        Console.WriteLine((i + 1) + ". " + question.Choices[i]);
                    }
                }
                else if (question.QuestionType == "Essay")
                {
                    Console.WriteLine("Answer (include the required keyword):");
                }

                string studentAnswer = Console.ReadLine();
                totalMarks += question.Mark;

                if (question.QuestionType == "Essay")
                {
                    if (studentAnswer.Contains(question.CorrectAnswer))
                    {
                        obtainedMarks += question.Mark;
                    }
                }
                else
                {
                    if (studentAnswer.Equals(question.CorrectAnswer))
                    {
                        obtainedMarks += question.Mark;
                    }
                }
            }
            studentdata.Add(new student(answer, obtainedMarks));
            foreach (var student in studentdata)
            {
                Console.WriteLine(student);
                if (obtainedMarks > totalMarks / 2)
                {
                    
                   
                    Console.WriteLine($"congratulations you have beeen passed the \nExam You scored {obtainedMarks} out of {totalMarks}.");
                }
                else {
                    Console.WriteLine($"sorry you have beeen failed in the \nExam You scored {obtainedMarks} out of {totalMarks}.");

                }
            }
           
        }
    }
}



