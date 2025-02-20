using ConsoleTableExt;
using System.Diagnostics;

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

            switch (taskPriority.ToLower())
            {
                case "h":
                    taskPriority = "High";
                break;

                case "m":
                    taskPriority = "Medium";
                break;

                case "l":
                    taskPriority = "Low";
                break;
            }

            id += 10;

            //Method to add new object at list
            tasks.Add(
                new List<object> {
                    id,
                    taskName,
                    taskDescription,
                    taskPriority,
                    "To do",
                    DateTime.Now.ToString("MM/dd/yyyy hh:mmtt"),
                    ""
                }
            );

            textArt.SuccessMsg("Task created successfully.");
            Console.WriteLine("");
        }

        public static void UpdateTask()
        {
            if (tasks.Count > 0)
            {
                Console.WriteLine("---------------Update Task---------------");
                Console.WriteLine("");

                ReadTasks();

                Console.WriteLine("");
                Console.WriteLine("Enter the ID of the task to be updated:");

                int.TryParse(Console.ReadLine(), out int updateId);
                Console.WriteLine("");


                if (updateId != 0)
                {
                    int index = tasks.FindIndex(t => (int)t[0] == updateId);

                    if (index != -1)
                    {
                        Console.WriteLine("Enter update task name: ");
                        tasks[index][1] = Console.ReadLine();
                        Console.WriteLine("");

                        Console.WriteLine("Enter update task description: ");
                        tasks[index][2] = Console.ReadLine();
                        Console.WriteLine("");


                        string updatePriority = "";

                        while (!new[] { "h", "m", "l" }.Contains(updatePriority.ToLower()))
                        {
                            Console.WriteLine("Enter update task priority");
                            textArt.ErrorMsg  ("High      [H]");
                            textArt.WarningMsg("Medium    [M]");
                            textArt.SuccessMsg("Low       [L]");
                            
                            updatePriority = Console.ReadLine();
                            Console.WriteLine("");
                        }

                        switch (updatePriority.ToLower())
                        {
                            case "h":
                                updatePriority = "High";
                                break;

                            case "m":
                                updatePriority = "Medium";
                                break;

                            case "l":
                                updatePriority = "Low";
                                break;
                        }

                        tasks[index][3] = updatePriority;
                        textArt.SuccessMsg("Information updated successfully.");
                        Console.WriteLine("");
                    }
                    else
                    {
                        textArt.ErrorMsg($"Task ID {updateId} not found.   :(");
                        Console.WriteLine("");
                    }
                }
                else 
                {
                    textArt.ErrorMsg("Task ID not found.   :(");
                    Console.WriteLine("");
                }
            }
            else
            {
                textArt.ErrorMsg("Tasks not found.   :(");
                Console.WriteLine("");
            }
        }

        public static void ReadTasks()
        {
            if (tasks.Count > 0)
            {
                ConsoleTableBuilder
                .From(tasks)
                .WithTitle("Tasks ", ConsoleColor.White, ConsoleColor.DarkGray)
                .WithColumn("ID", "Name", "Description", "Priority", "Progress", "Created Date", "Updated Date").ExportAndWriteLine();
            }
            else
            {
                textArt.ErrorMsg("Tasks not found.   :(");
                Console.WriteLine("");
            }
        }
    }
}