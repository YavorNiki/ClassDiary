namespace ClassDiary
{
    public class Diary
    {
        private string filePath;

        public Diary(string filePath)
        {
            this.filePath = filePath;
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }

        public void AddStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(name + ":");
            }

            Console.WriteLine($"Student {name} has been added.");
        }

        public void AddGrade()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter subject: ");
            string subject = Console.ReadLine();

            Console.Write("Enter grade: ");
            string grade = Console.ReadLine();

            List<string> lines = new List<string>(File.ReadAllLines(filePath));
            bool found = false;

            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].StartsWith(name + ":"))
                {
                    lines[i] += $" {subject} - {grade},";
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student not found.");
            }
            else
            {
                File.WriteAllLines(filePath, lines);
                Console.WriteLine("Grade has been added.");
            }
        }

        public void ShowGrades()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            string[] lines = File.ReadAllLines(filePath);
            bool found = false;

            foreach (string line in lines)
            {
                if (line.StartsWith(name + ":"))
                {
                    Console.WriteLine($"\nGrades for {name}:");
                    Console.WriteLine(line.Substring(name.Length + 1));
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Student not found.");
            }
        }
    }
}
