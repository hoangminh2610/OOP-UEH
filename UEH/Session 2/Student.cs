using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_1
{
    public class Student
    {
        private string name;
        private double score;
        private static int totalStudents = 0;

        public Student(string name, double score)
        {
            this.name = name;
            this.score = score;
            totalStudents++;
        }

        // Instance menthods
        public string GetName() 
        { 
            return name; 
        }
        public double GetScore()
        {
            return score;
        }

        public bool IsPassed()
        {
            return score >= 5.0;
        }

        public string GetClassification()
        {
            if (score >= 8.0)
                return "Excellent";
            else if (score >= 6.5)
                return "Good";
            else if (score >= 5.0)
                return "Average";
            else
                return "Weak";
        }

        // Static methods
        public static int GetTotalStudents()
        {
            return totalStudents;
        }
        public static Student FindTopStudent(Student[] students)
        {
            if (students == null || students.Length == 0)
                return null;

            Student topStudent = students[0];
            foreach (Student student in students)
            {
                if (student.score > topStudent.score)
                    topStudent = student;
            }
            return topStudent;
        }
        public static double CalculateAverageScore(Student[] students)
        {
            if (students == null || students.Length == 0)
                return 0;

            double sum = 0;
            foreach (Student student in students)
            {
                sum += student.score;
            }
            return sum / students.Length;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create array of Student objects
            Student[] students = new Student[]
            {
                new Student("ABC", 9.3),
                new Student("DEF", 4.9),
                new Student("GHI", 5.0),
                new Student("JKL", 7.2),
                new Student("MNO", 8.8)
            };

            Console.WriteLine("Total Students Created: " + Student.GetTotalStudents());
            Console.WriteLine();

            Console.WriteLine("Student List:");
            foreach (Student student in students)
            {
                string status = student.IsPassed() ? "Passed" : "Failed";
                Console.WriteLine($"Name: {student.GetName(),-5} Score: {student.GetScore(),-5} Classification: {student.GetClassification(),-11} Status: {status}");
            }
            Console.WriteLine();

            Student topStudent = Student.FindTopStudent(students);
            Console.WriteLine($"Top Student: {topStudent.GetName()} with score {topStudent.GetScore()}");
            Console.WriteLine();

            double averageScore = Student.CalculateAverageScore(students);
            Console.WriteLine($"Class Average Score: {averageScore:F2}");
        }
    }
}
