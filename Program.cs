

using Classtask.Modes;

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("Student Management System");
        Console.WriteLine("1 Add a new student");
        Console.WriteLine("2 Display all students");
        Console.WriteLine("3 Search for student by Id");
        Console.WriteLine("4 Delete a student");
        Console.WriteLine("5 Exit");

        int operation;
        string id;
        Student[] students = { };

        do
        {
            Console.WriteLine("Choose operation :");
            operation = Convert.ToInt32(Console.ReadLine());

            switch (operation)
            {
                case 1:
                    students = Add(students);
                    break;
                case 2:
                    DisplayStudents(students);
                    break;
                case 3:
                    Console.WriteLine("Enter student Id to search:");
                    id = Console.ReadLine();
                    SearchStudent(students, id);
                    break;
                case 4:
                    Console.WriteLine("Enter student Id to delete:");
                    id = Console.ReadLine();
                    students = Remove(students, id);
                    break;
                default:
                    break;
            }
        }
        while (operation != 5);
    }

    static Student[] Add(Student[] students)
    {
        Console.Write("Add student name: ");
        string studentName = Console.ReadLine();
        Console.WriteLine("Add student age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Student student = new Student()
        {
            Name = studentName,
            Age = age,
            Id = Guid.NewGuid().ToString() 
        };

        Array.Resize(ref students, students.Length + 1);
        students[students.Length - 1] = student;

        Console.WriteLine("Student added successfully ");
        return students;
    }

    static void SearchStudent(Student[] students, string id)
    {
        Student searchedStudent = students.FirstOrDefault(x => x.Id == id);

        if (searchedStudent != null)
        {
            Console.WriteLine("Searched student:");
            Console.WriteLine($"Student Id : {searchedStudent.Id},\nStudent name : {searchedStudent.Name}\nStudent age : {searchedStudent.Age}");
        }
        else
        {
            Console.WriteLine("Student not found.");
        }
    }

    static void DisplayStudents(Student[] students)
    {
        Console.WriteLine("Students information:");
        foreach (Student stu in students)
        {
            Console.WriteLine($"Student Id: {stu.Id}, Student name: {stu.Name}, Student age: {stu.Age}");
        }
    }

    static Student[] Remove(Student[] students, string id)
    {
        students = students.Where(x => x.Id != id).ToArray();
        Console.WriteLine("Student deleted successfully ");
        return students;
    }
}