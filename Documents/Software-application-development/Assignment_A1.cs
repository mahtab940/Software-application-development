using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManagement
{
    /// <summary>
    /// Assignment A1: Student Grade Management System (20 Marks)
    /// Problem 1: Student Grade Management System
    /// 
    /// Requirements:
    /// 1. Ask the user for the number of students.
    /// 2. For each student, input: Name and Marks (0–100).
    /// 3. Use a function and conditionals to calculate the grade:
    ///    A (90–100), B (75–89), C (50–74), F (<50).
    /// 4. Use loops to display each student's Name, Marks, and Grade.
    /// 5. Use another function to find the highest scorer.
    /// 6. Use another function to get remarks.
    /// 7. Implement method overloading for a function PrintResult.
    /// </summary>
    
    public class Student
    {
        public string Name { get; set; }
        public int Marks { get; set; }
        public char Grade { get; set; }
        
        public Student(string name, int marks, char grade)
        {
            Name = name;
            Marks = marks;
            Grade = grade;
        }
    }
    
    public class StudentGradeManager
    {
        private List<Student> students;
        
        public StudentGradeManager()
        {
            students = new List<Student>();
        }
        
        /// <summary>
        /// Function to calculate grade based on marks using conditionals
        /// </summary>
        /// <param name="marks">Student marks (0-100)</param>
        /// <returns>Grade character (A, B, C, F)</returns>
        public char CalculateGrade(int marks)
        {
            if (marks >= 90)
                return 'A';
            else if (marks >= 75)
                return 'B';
            else if (marks >= 50)
                return 'C';
            else
                return 'F';
        }
        
        /// <summary>
        /// Function to get remarks based on grade
        /// </summary>
        /// <param name="grade">Grade character</param>
        /// <returns>Remarks string</returns>
        public string GetRemarks(char grade)
        {
            switch (grade)
            {
                case 'A':
                    return "Excellent";
                case 'B':
                    return "Very Good";
                case 'C':
                    return "Needs Improvement";
                case 'F':
                    return "Fail";
                default:
                    return "Unknown";
            }
        }
        
        /// <summary>
        /// Function to find the highest scorer
        /// </summary>
        /// <returns>Student with highest marks or null if no students</returns>
        public Student FindHighestScorer()
        {
            if (students.Count == 0)
                return null;
            
            Student highestStudent = students[0];
            foreach (Student student in students)
            {
                if (student.Marks > highestStudent.Marks)
                {
                    highestStudent = student;
                }
            }
            return highestStudent;
        }
        
        /// <summary>
        /// Method overloading for PrintResult
        /// PrintResult(string name, int marks) → prints name and grade
        /// </summary>
        /// <param name="name">Student name</param>
        /// <param name="marks">Student marks</param>
        public void PrintResult(string name, int marks)
        {
            char grade = CalculateGrade(marks);
            Console.WriteLine($"Name: {name}, Marks: {marks}, Grade: {grade}");
        }
        
        /// <summary>
        /// Method overloading for PrintResult
        /// PrintResult(string name, int marks, string remarks) → prints name, grade, and extra remarks
        /// </summary>
        /// <param name="name">Student name</param>
        /// <param name="marks">Student marks</param>
        /// <param name="remarks">Grade remarks</param>
        public void PrintResult(string name, int marks, string remarks)
        {
            char grade = CalculateGrade(marks);
            Console.WriteLine($"Name: {name}, Marks: {marks}, Grade: {grade}, Remarks: {remarks}");
        }
        
        /// <summary>
        /// Ask the user for the number of students and input their details
        /// </summary>
        /// <returns>True if input successful, false otherwise</returns>
        public bool InputStudents()
        {
            try
            {
                // Ask the user for the number of students
                Console.Write("Enter the number of students: ");
                int numStudents = int.Parse(Console.ReadLine());
                
                // For each student, input: Name and Marks (0–100)
                for (int i = 0; i < numStudents; i++)
                {
                    Console.WriteLine($"\n--- Entering details for Student {i + 1} ---");
                    
                    // Input student name
                    Console.Write("Enter student name: ");
                    string name = Console.ReadLine().Trim();
                    
                    // Input and validate marks (0-100)
                    int marks;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter marks (0-100): ");
                            marks = int.Parse(Console.ReadLine());
                            if (marks >= 0 && marks <= 100)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Error: Please enter marks between 0 and 100.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error: Please enter a valid number.");
                        }
                    }
                    
                    // Calculate grade and store student data
                    char grade = CalculateGrade(marks);
                    Student student = new Student(name, marks, grade);
                    students.Add(student);
                }
                
                return true;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number of students.");
                return false;
            }
        }
        
        /// <summary>
        /// Use loops to display each student's Name, Marks, and Grade
        /// </summary>
        public void DisplayAllStudents()
        {
            Console.WriteLine("\n" + new string('=', 60));
            Console.WriteLine("               STUDENT GRADE REPORT");
            Console.WriteLine(new string('=', 60));
            
            // Use loop to display each student's details
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"\nStudent {i + 1}:");
                string remarks = GetRemarks(students[i].Grade);
                // Using method overloading with remarks
                PrintResult(students[i].Name, students[i].Marks, remarks);
            }
        }
        
        /// <summary>
        /// Display the highest scorer using the FindHighestScorer function
        /// </summary>
        public void DisplayHighestScorer()
        {
            Student highest = FindHighestScorer();
            if (highest != null)
            {
                Console.WriteLine("\n" + new string('=', 40));
                Console.WriteLine("           HIGHEST SCORER");
                Console.WriteLine(new string('=', 40));
                string remarks = GetRemarks(highest.Grade);
                Console.WriteLine("🏆 Congratulations to the highest scorer!");
                PrintResult(highest.Name, highest.Marks, remarks);
            }
            else
            {
                Console.WriteLine("No students found.");
            }
        }
        
        /// <summary>
        /// Demonstrate method overloading with examples
        /// </summary>
        public void DemonstrateMethodOverloading()
        {
            if (students.Count == 0)
                return;
                
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("        DEMONSTRATING METHOD OVERLOADING");
            Console.WriteLine(new string('=', 50));
            
            Student firstStudent = students[0];
            
            Console.WriteLine("\n1. Using PrintResult(name, marks) - without remarks:");
            PrintResult(firstStudent.Name, firstStudent.Marks);
            
            Console.WriteLine("\n2. Using PrintResult(name, marks, remarks) - with remarks:");
            string remarks = GetRemarks(firstStudent.Grade);
            PrintResult(firstStudent.Name, firstStudent.Marks, remarks);
        }
        
        /// <summary>
        /// Display additional summary statistics
        /// </summary>
        public void DisplaySummaryStatistics()
        {
            if (students.Count == 0)
                return;
                
            Console.WriteLine("\n" + new string('=', 40));
            Console.WriteLine("         SUMMARY STATISTICS");
            Console.WriteLine(new string('=', 40));
            
            int totalStudents = students.Count;
            double totalMarks = students.Sum(s => s.Marks);
            double averageMarks = totalMarks / totalStudents;
            
            // Count grades
            var gradeCounts = new Dictionary<char, int>
            {
                {'A', 0}, {'B', 0}, {'C', 0}, {'F', 0}
            };
            
            foreach (Student student in students)
            {
                gradeCounts[student.Grade]++;
            }
            
            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Average Marks: {averageMarks:F2}");
            Console.WriteLine("Grade Distribution:");
            
            foreach (var gradeCount in gradeCounts)
            {
                double percentage = (double)gradeCount.Value / totalStudents * 100;
                Console.WriteLine($"  {gradeCount.Key}: {gradeCount.Value} students ({percentage:F1}%)");
            }
        }
        
        /// <summary>
        /// Main method to run the Student Grade Management System
        /// </summary>
        public void Run()
        {
            Console.WriteLine(new string('=', 60));
            Console.WriteLine("     WELCOME TO STUDENT GRADE MANAGEMENT SYSTEM");
            Console.WriteLine("                Assignment A1 - Problem 1");
            Console.WriteLine(new string('=', 60));
            
            // Step 1: Input student data
            if (InputStudents())
            {
                // Step 2: Display all students using loops
                DisplayAllStudents();
                
                // Step 3: Find and display highest scorer
                DisplayHighestScorer();
                
                // Step 4: Demonstrate method overloading
                DemonstrateMethodOverloading();
                
                // Step 5: Display summary statistics
                DisplaySummaryStatistics();
                
                Console.WriteLine("\n" + new string('=', 60));
                Console.WriteLine("           THANK YOU FOR USING THE SYSTEM!");
                Console.WriteLine(new string('=', 60));
            }
            else
            {
                Console.WriteLine("Failed to input student data. Please try again.");
            }
        }
    }
    
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main entry point of the application
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            StudentGradeManager gradeManager = new StudentGradeManager();
            gradeManager.Run();
            
            // Keep console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
