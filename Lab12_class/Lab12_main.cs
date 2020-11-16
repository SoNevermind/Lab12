using System;

namespace Lab12_class
{
    public class Lab12_main
    {
        static void Main(string[] args)
        {
            var student = new Student(new Person("Wafel", "Unknow", new DateTime(2001, 7, 11)), Education.SecondEducation, 1488);
            Console.WriteLine(student.ToShortString() + "\n");

            foreach (Education element in Enum.GetValues(typeof(Education)))
            {
                Console.WriteLine($"{element} = {student[element]}");
            }

            Console.WriteLine();

            student.AddExams(
                new Exam("math", 2, new DateTime(2007, 1, 1)),
                new Exam("physic", 3, new DateTime(2007, 1, 2)),
                new Exam("english", 10, new DateTime(2007, 1, 3)),
                new Exam("literature", 12, new DateTime(2007, 1, 4)),
                new Exam("music", 3, new DateTime(2007, 1, 5))
                );

            Console.WriteLine(student);

            Console.ReadLine();
        }
    }
}
