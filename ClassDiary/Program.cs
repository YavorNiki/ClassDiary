namespace ClassDiary

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Diary diary = new Diary("diary.txt");

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Add grade");
                Console.WriteLine("3. Show grades");
                Console.WriteLine("4. Exit");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        diary.AddStudent();
                        break;
                    case "2":
                        diary.AddGrade();
                        break;
                    case "3":
                        diary.ShowGrades();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Unvalid command. Try agian.");
                        break;
                }
            }
            Console.WriteLine("GoodBye:)");


        }
    }
}




