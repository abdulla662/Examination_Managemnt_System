namespace EMS

{
    public class Teacher {
        public int userID { get; set; }
        public string userName { get; set; }

        public UserType userType { get; set; }
        public String Login() {

            Console.WriteLine("Please SignUp by Writing Your UserName"); 
            string user = Console.ReadLine();
            Console.WriteLine("Authenticating...");
            Thread.Sleep(3000);             //https://stackoverflow.com/questions/20082221/when-to-use-task-delay-when-to-use-thread-sleep //
            Console.WriteLine("");
            Console.WriteLine("Authenticated !");

            if (user != null)
            {
                return $"succefully logged in mr/ms {user}";

            }
            else {
                return "Wrong name";
            }



        }

        public Teacher(int userID=0, string userName="")
        {
            this.userID = userID;
            this.userName = userName;
        }
    }
}
