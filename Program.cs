namespace app
{ 
    class Program
    {
        static void Main()
        {
            Console.Title = "Console 🔥";

            textArt.Welcome();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("+------------------------+");
                Console.WriteLine("|        Main Menu       |");
                Console.WriteLine("| Add Task           [A] |");
                Console.WriteLine("| Update Task        [U] |");
                Console.WriteLine("| Update Progress    [P] |");
                Console.WriteLine("| Delete Task        [D] |");
                Console.WriteLine("| List Tasks         [R] |");
                Console.WriteLine("| Close System       [X] |");
                Console.WriteLine("+------------------------+");

                string option = Console.ReadLine();
                Console.WriteLine("");

                switch (option.ToLower())
                {
                    case "a":
                        Task.AddTask();
                    break;

                    case "u":
                        Task.UpdateTask();
                    break;

                    case "p":
                        Task.UpdateProgress();
                    break;

                    case "d":
                        Task.DeleteTask();
                    break;

                    case "r":
                        Task.ReadTasks();
                        Console.ReadKey();
                        Console.WriteLine("");
                    break;

                    case "x":
                        Console.WriteLine("");
                        exit = true;
                    break;
                }
            }

            textArt.Bye();
        }
    }
}
