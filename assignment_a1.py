#!/usr/bin/env python3


class StudentGradeManager:
    def __init__(self):
        self.students = []
    
    def calculate_grade(self, marks):
        """Function to calculate grade based on marks using conditionals"""
        if marks >= 90:
            return 'A'
        elif marks >= 75:
            return 'B'
        elif marks >= 50:
            return 'C'
        else:
            return 'F'
    
    def get_remarks(self, grade):
        """Function to get remarks based on grade"""
        remarks_mapping = {
            'A': "Excellent",
            'B': "Very Good", 
            'C': "Needs Improvement",
            'F': "Fail"
        }
        return remarks_mapping.get(grade, "Unknown")
    
    def find_highest_scorer(self):
        """Function to find the highest scorer"""
        if not self.students:
            return None
        
        highest_student = self.students[0]
        for student in self.students:
            if student['marks'] > highest_student['marks']:
                highest_student = student
        return highest_student
    
    def print_result(self, name, marks, remarks=None):
        """
        Method overloading implementation for PrintResult:
        - PrintResult(name, marks) → prints name and grade
        - PrintResult(name, marks, remarks) → prints name, grade, and extra remarks
        """
        grade = self.calculate_grade(marks)
        
        if remarks is None:
            # PrintResult(string name, int marks) → prints name and grade
            print(f"Name: {name}, Marks: {marks}, Grade: {grade}")
        else:
            # PrintResult(string name, int marks, string remarks) → prints name, grade, and extra remarks
            print(f"Name: {name}, Marks: {marks}, Grade: {grade}, Remarks: {remarks}")
    
    def input_students(self):
        """Ask the user for the number of students and input their details"""
        try:
            # Ask the user for the number of students
            num_students = int(input("Enter the number of students: "))
            
            # For each student, input: Name and Marks (0–100)
            for i in range(num_students):
                print(f"\n--- Entering details for Student {i + 1} ---")
                
                # Input student name
                name = input("Enter student name: ").strip()
                
                # Input and validate marks (0-100)
                while True:
                    try:
                        marks = int(input("Enter marks (0-100): "))
                        if 0 <= marks <= 100:
                            break
                        else:
                            print("Error: Please enter marks between 0 and 100.")
                    except ValueError:
                        print("Error: Please enter a valid number.")
                
                # Calculate grade and store student data
                grade = self.calculate_grade(marks)
                student = {
                    'name': name,
                    'marks': marks,
                    'grade': grade
                }
                self.students.append(student)
                
        except ValueError:
            print("Error: Please enter a valid number of students.")
            return False
        return True
    
    def display_all_students(self):
        """Use loops to display each student's Name, Marks, and Grade"""
        print("\n" + "="*60)
        print("               STUDENT GRADE REPORT")
        print("="*60)
        
        # Use loop to display each student's details
        for i, student in enumerate(self.students, 1):
            print(f"\nStudent {i}:")
            remarks = self.get_remarks(student['grade'])
            # Using method overloading with remarks
            self.print_result(student['name'], student['marks'], remarks)
    
    def display_highest_scorer(self):
        """Display the highest scorer using the find_highest_scorer function"""
        highest = self.find_highest_scorer()
        if highest:
            print("\n" + "="*40)
            print("           HIGHEST SCORER")
            print("="*40)
            remarks = self.get_remarks(highest['grade'])
            print(f"🏆 Congratulations to the highest scorer!")
            self.print_result(highest['name'], highest['marks'], remarks)
        else:
            print("No students found.")
    
    def demonstrate_method_overloading(self):
        """Demonstrate method overloading with examples"""
        if not self.students:
            return
            
        print("\n" + "="*50)
        print("        DEMONSTRATING METHOD OVERLOADING")
        print("="*50)
        
        first_student = self.students[0]
        
        print("\n1. Using PrintResult(name, marks) - without remarks:")
        self.print_result(first_student['name'], first_student['marks'])
        
        print("\n2. Using PrintResult(name, marks, remarks) - with remarks:")
        remarks = self.get_remarks(first_student['grade'])
        self.print_result(first_student['name'], first_student['marks'], remarks)
    
    def display_summary_statistics(self):
        """Display additional summary statistics"""
        if not self.students:
            return
            
        print("\n" + "="*40)
        print("         SUMMARY STATISTICS")
        print("="*40)
        
        total_students = len(self.students)
        total_marks = sum(student['marks'] for student in self.students)
        average_marks = total_marks / total_students
        
        # Count grades
        grade_counts = {'A': 0, 'B': 0, 'C': 0, 'F': 0}
        for student in self.students:
            grade_counts[student['grade']] += 1
        
        print(f"Total Students: {total_students}")
        print(f"Average Marks: {average_marks:.2f}")
        print(f"Grade Distribution:")
        for grade, count in grade_counts.items():
            percentage = (count / total_students) * 100
            print(f"  {grade}: {count} students ({percentage:.1f}%)")
    
    def run(self):
        """Main method to run the Student Grade Management System"""
        print("="*60)
        print("     WELCOME TO STUDENT GRADE MANAGEMENT SYSTEM")
        print("                Assignment A1 - Problem 1")
        print("="*60)
        
        # Step 1: Input student data
        if self.input_students():
            # Step 2: Display all students using loops
            self.display_all_students()
            
            # Step 3: Find and display highest scorer
            self.display_highest_scorer()
            
            # Step 4: Demonstrate method overloading
            self.demonstrate_method_overloading()
            
            # Step 5: Display summary statistics
            self.display_summary_statistics()
            
            print("\n" + "="*60)
            print("           THANK YOU FOR USING THE SYSTEM!")
            print("="*60)
        else:
            print("Failed to input student data. Please try again.")

def main():
    """Main function to start the Student Grade Management System"""
    grade_manager = StudentGradeManager()
    grade_manager.run()

if __name__ == "__main__":
    main()
