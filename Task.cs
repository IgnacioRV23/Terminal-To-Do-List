using ConsoleTableExt;

namespace app
{
    class Task
    {
        public static List<List<object>> tasks = new List<List<object>>();

        static int id = 1000;

        public static void AddTask()
        {
            Console.WriteLine("Task name: ");
            string taskName = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Task description: ");
            string taskDescription = Console.ReadLine();
            Console.WriteLine("");


            string taskPriority = "";

            while (!new[] { "h", "m", "l" }.Contains(taskPriority.ToLower()))
            {
                Console.WriteLine ("Task priority");
                textArt.ErrorMsg  ("High      [H]");
                textArt.WarningMsg("Medium    [M]");
                textArt.SuccessMsg("Low       [L]");

                taskPriority = Console.ReadLine();
                Console.WriteLine("");
            }

            id += 10;

            //Method to add new object at list
            tasks.Add(
                new List<object> {
                    id,
                    taskName,
                    taskDescription,
                    taskPriority
                }
            );

            textArt.SuccessMsg("Task created successfully.");
            Console.WriteLine("");
        }

        public static void ReadTasks()
        {
            ConsoleTableBuilder
                .From(tasks)
                .WithTitle("Tasks ", ConsoleColor.White, ConsoleColor.DarkGray)
                .WithColumn("ID", "Name", "Description", "Priority").ExportAndWriteLine();
        }
    }
}