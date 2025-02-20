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

                        tasks[index][6] = DateTime.Now.ToString("MM/dd/yyyy hh:mmtt");

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

        public static void UpdateProgress()
        {
            if (tasks.Count > 0)
            {
                Console.WriteLine("---------------Update Progress Task---------------");
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
                        string newProgress = "";

                        while (!new[] { "t", "p", "d" }.Contains(newProgress.ToLower()))
                        {
                            Console.WriteLine("Enter new progress task:");
                            Console.WriteLine("To do          [T]");
                            Console.WriteLine("In Progress    [P]");
                            Console.WriteLine("Done           [D]");

                            newProgress = Console.ReadLine();
                            Console.WriteLine("");
                        }

                        switch (newProgress.ToLower())
                        {
                            case "t":
                                tasks[index][4] = "To do";
                                Console.WriteLine("");
                            break;

                            case "p":
                                tasks[index][4] = "In Progress";
                                Console.WriteLine("");
                            break;

                            case "d":
                                tasks[index][4] = "Done";
                                Console.WriteLine("");
                            break;
                        }

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

        public static void DeleteTask()
        {
            if (tasks.Count > 0)
            {
                Console.WriteLine("---------------Delete Task---------------");
                Console.WriteLine("");

                ReadTasks();

                Console.WriteLine("");
                Console.WriteLine("Enter the ID of the task to be deleted:");

                int.TryParse(Console.ReadLine(), out int deleteId);
                Console.WriteLine("");

                if (deleteId != 0)
                {
                    int index = tasks.FindIndex(t => (int)t[0] == deleteId);

                    if (index != -1)
                    {
                        bool acceptDelete = false;

                        string option = "";

                        while (option.ToLower() != "y" && option.ToLower() != "n")
                        {
                            textArt.QuestionMsg($"Are you sure you want to delete task {deleteId}?");
                            textArt.QuestionMsg("Yes   [Y]");
                            textArt.QuestionMsg("No    [N]");

                            option = Console.ReadLine();
                            
                            Console.WriteLine("");
                        }

                        if (option.ToLower() == "y")
                        {
                            tasks.RemoveAt(index);

                            textArt.SuccessMsg("Information deleted successfully.");
                            Console.WriteLine("");
                        }
                        else if (option.ToLower() == "n")
                        {
                            textArt.WarningMsg("Information not deleted.");
                            Console.WriteLine("");
                        }
                    }
                    else
                    {
                        textArt.ErrorMsg($"Task ID {deleteId} not found.   :(");
                        Console.WriteLine("");
                    }
                }
                else
                {
                    textArt.ErrorMsg("Tasks not found.   :(");
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