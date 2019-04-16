using BusinessLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool programEnd = false;
            string name;
            int standardId, id;

            BusinessLayer.BusinessLayer businessLayer = new BusinessLayer.BusinessLayer();
            IEnumerable<Standard> standardTable;
            IEnumerable<Student> studentTable;
            IEnumerable<Teacher> teacherTable;
            IEnumerable<Course> courseTable;

            Standard standard;
            Student student;
            Teacher teacher;
            Course course;

            string option;

            while (!programEnd)
            {
                Console.WriteLine(  "1. Table Standard\n" +
                                    "2. Table Student\n" +
                                    "3. Table Teacher\n" +
                                    "4. Table Course\n" +
                                    "5. Exit Program");
                Console.Write("Please select from the above: ");
                string strInput = Console.ReadLine();

                int intTemp = 0;
                if (int.TryParse(strInput, out intTemp))
                {
                    intTemp = Convert.ToInt32(strInput);
                }

                if (intTemp == 1)
                {
                    bool standardEnd = false;

                    while (!standardEnd)
                    {
                        Console.WriteLine(  "Standard Table Options:\n" +
                                            "1. Create Standard\n" +
                                            "2. Update Standard\n" +
                                            "3. Delete Standard\n" +
                                            "4. Display students under a standard ID\n" +
                                            "5. Display all standards\n" +
                                            "6. Exit menu.");
                        Console.Write("Selection: ");
                        int intInput = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine();

                        switch(intInput)
                        {
                            case 1:
                                Console.WriteLine("Please enter the standard you wish to enter:");
                                Console.Write("Standard Name: ");
                                name = Console.ReadLine();

                                Standard stand = new Standard()
                                {
                                    StandardName = name
                                };

                                businessLayer.AddStandard(stand);
                                break;
                            case 2:
                                Console.WriteLine("Enter the standard name you wish to update: ");
                                Console.Write("Standard Name: ");
                                name = Console.ReadLine();
                                Console.WriteLine();

                                standard = businessLayer.GetStandardByName(name);
                                standard = businessLayer.GetStandardByID(standard.StandardId);
                                Console.Write("Enter the updated standard name: ");
                                standard.StandardName = Console.ReadLine();
                                businessLayer.UpdateStandard(standard);
                                break;
                            case 3:
                                Console.Write("Enter the standard id you wish to delete: ");
                                standardId = Convert.ToInt16(Console.ReadLine());
                                standard = businessLayer.GetStandardByID(standardId);
                                businessLayer.RemoveStandard(standard);
                                break;
                            case 4:
                                Console.Write("Enter the standard ID you wish to access: ");
                                standardId = Convert.ToInt16(Console.ReadLine());
                                standard = businessLayer.GetStandardByID(standardId);
                                Console.WriteLine();
                                Console.WriteLine("Students in " + standard.StandardName + ": ");
                                Console.WriteLine();
                                Console.WriteLine("Students: " + "\t\t" + "ID:");
                                foreach (Student s in standard.Students)
                                {
                                    Console.WriteLine(s.StudentName + "\t\t\t" + s.StudentID);
                                }
                                Console.WriteLine();
                                break;
                            case 5:
                                standardTable = businessLayer.GetAllStandards();
                                Console.WriteLine();
                                foreach (Standard newStandard in standardTable)
                                {
                                    Console.WriteLine(newStandard.StandardId + " " + newStandard.StandardName);
                                }
                                Console.WriteLine();
                                break;
                            default:
                                standardEnd = true;
                                break;
                        }
                    }
                }
                else if (intTemp == 2)
                {
                    bool studentEnd = false;

                    while (!studentEnd)
                    {
                        Console.WriteLine(  "Student Table Options:\n" +
                                            "1. Create Student\n" +
                                            "2. Update Student\n" +
                                            "3. Delete Student\n" +
                                            "4. Display all Students\n" +
                                            "5. Exit menu.");
                        Console.Write("Selection: ");
                        int input = Convert.ToInt32(Console.ReadLine());

                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Please enter the student name.");
                                Console.Write("Name: ");
                                name = Console.ReadLine();

                                //Console.Write("New student's standard ID: ");
                                //standardId = Convert.ToInt16(Console.ReadLine());

                                student = new Student
                                {
                                    StudentName = name,
                                    //StandardId = standardId
                                };

                                //standard = businessLayer.GetStandardByID(standardId);
                                //standard.Students.Add(student);
                                businessLayer.AddStudent(student);
                                break;
                            case 2:
                                Console.Write("Would you like to update by student name or student id?: ");
                                option = Console.ReadLine();
                                Console.WriteLine();
                                if (option.Equals("name"))
                                {
                                    Console.Write("Enter the student name you are searching for: ");
                                    name = Console.ReadLine();
                                    student = businessLayer.GetStudentByName(name);
                                    student = businessLayer.GetStudentByID(student.StudentID);
                                    Console.Write("\nEnter the updated student name: ");
                                    student.StudentName = Console.ReadLine();
                                    businessLayer.UpdateStudent(student);
                                }
                                else if (option.Equals("id"))
                                {
                                    Console.Write("Enter the student ID you are searching for: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    student = businessLayer.GetStudentByID(id);
                                    Console.Write("\nEnter the updated student name: ");
                                    student.StudentName = Console.ReadLine();
                                    businessLayer.UpdateStudent(student);
                                }
                                break;
                            case 3:
                                Console.Write("Enter the student ID you want to delete: ");
                                id = Convert.ToInt16(Console.ReadLine());
                                student = businessLayer.GetStudentByID(id);
                                businessLayer.RemoveStudent(student);
                                break;
                            case 4:
                                studentTable = businessLayer.GetAllStudents();
                                Console.WriteLine();
                                foreach (Student studentLoop in studentTable)
                                {
                                    Console.WriteLine(studentLoop.StudentName + " " + studentLoop.StudentID);
                                }
                                Console.WriteLine();
                                break;
                            default:
                                studentEnd = true;
                                break;
                        }
                    }
                }
                else if (intTemp == 3)
                {
                    bool teacherEnd = false;

                    while (!teacherEnd)
                    {
                        Console.WriteLine(  "Teacher Table Options:\n" +
                                            "1. Create Teacher\n" +
                                            "2. Update Teacher\n" +
                                            "3. Delete Teacher\n" +
                                            "4. Display all Teacher\n" +
                                            "5. Display all courses taught by an individual teacher\n" +
                                            "6. Exit menu.");
                        Console.Write("Selection: ");
                        int input = Convert.ToInt32(Console.ReadLine());

                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Please enter the teacher name.");
                                Console.Write("Name: ");
                                name = Console.ReadLine();

                                //Console.Write("New teacher's standard ID: ");
                                //standardId = Convert.ToInt16(Console.ReadLine());

                                teacher = new Teacher
                                {
                                    TeacherName = name,
                                    //StandardId = standardId
                                };

                                //standard = businessLayer.GetStandardByID(standardId);
                                //standard.Teachers.Add(teacher);
                                businessLayer.AddTeacher(teacher);
                                break;
                            case 2:
                                Console.Write("Would you like to update by teacher name or teacher id?: ");
                                option = Console.ReadLine();
                                Console.WriteLine();
                                if (option.Equals("name"))
                                {
                                    Console.Write("Enter the teacher name you are searching for: ");
                                    name = Console.ReadLine();
                                    teacher = businessLayer.GetTeacherByName(name);
                                    teacher = businessLayer.GetTeacherByID(teacher.TeacherId);
                                    Console.Write("\nEnter the updated teacher name: ");
                                    teacher.TeacherName = Console.ReadLine();
                                    businessLayer.UpdateTeacher(teacher);
                                }
                                else if (option.Equals("id"))
                                {
                                    Console.Write("Enter the teacher ID you are searching for: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    teacher = businessLayer.GetTeacherByID(id);
                                    Console.WriteLine();
                                    Console.Write("Enter the updated teacher name: ");
                                    teacher.TeacherName = Console.ReadLine();
                                    businessLayer.UpdateTeacher(teacher);
                                }
                                break;
                            case 3:
                                Console.Write("Enter the teacher ID you want to delete: ");
                                id = Convert.ToInt16(Console.ReadLine());
                                teacher = businessLayer.GetTeacherByID(id);
                                businessLayer.RemoveTeacher(teacher);
                                break;
                            case 4:
                                teacherTable = businessLayer.GetAllTeachers();
                                Console.WriteLine();
                                foreach (Teacher teacherloop in teacherTable)
                                {
                                    Console.WriteLine(teacherloop.TeacherName + " " + teacherloop.TeacherId);
                                }
                                Console.WriteLine();
                                break;
                            case 5:
                                courseTable = businessLayer.GetAllCourses();
                                Console.Write("Enter the teacher ID you wish to access: ");
                                id = Convert.ToInt16(Console.ReadLine());
                                teacher = businessLayer.GetTeacherByID(id);
                                Console.WriteLine("\nCourses taught by " + teacher.TeacherName + ": ");
                                Console.WriteLine("\nCourses: " + "\t\t" + "Course ID:");
                                foreach (Course c in courseTable)
                                {
                                    if (c.TeacherId == id)
                                    {
                                        Console.WriteLine(c.CourseName + "\t\t\t" + c.CourseId);
                                    }
                                    
                                }
                                Console.WriteLine();
                                break;
                            default:
                                teacherEnd = true;
                                break;
                        }
                    }
                }
                else if (intTemp == 4)
                {
                    bool courseEnd = false;

                    while (!courseEnd)
                    {
                        Console.WriteLine(  "Course Table Options:\n" +
                                            "1. Create Course\n" +
                                            "2. Update Course Name\n" +
                                            "3. Update Course Teacher\n" +
                                            "4. Delete Course\n" +
                                            "5. Display all Course\n" +
                                            "6. Exit menu.");
                        Console.Write("Selection: ");
                        int input = Convert.ToInt32(Console.ReadLine());

                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("Please enter the course name.");
                                Console.Write("Name: ");
                                name = Console.ReadLine();

                                Console.Write("New course teacher's ID: ");
                                id = Convert.ToInt16(Console.ReadLine());

                                course = new Course
                                {
                                    CourseName = name,
                                    TeacherId = id
                                };
                                
                                businessLayer.AddCourse(course);
                                break;
                            case 2:
                                Console.Write("Would you like to update by course name or course id?: ");
                                option = Console.ReadLine();
                                Console.WriteLine();
                                if (option.Equals("name"))
                                {
                                    Console.Write("Enter the course name you are searching for: ");
                                    name = Console.ReadLine();
                                    course = businessLayer.GetCourseByName(name);
                                    course = businessLayer.GetCourseByID(course.CourseId);
                                    Console.Write("\nEnter the updated course name: ");
                                    course.CourseName = Console.ReadLine();
                                    businessLayer.UpdateCourse(course);
                                }
                                else if (option.Equals("id"))
                                {
                                    Console.Write("Enter the course ID you are searching for: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    course = businessLayer.GetCourseByID(id);
                                    Console.Write("\nEnter the updated course name: ");
                                    course.CourseName = Console.ReadLine();
                                    businessLayer.UpdateCourse(course);
                                }
                                break;
                            case 3:
                                Console.Write("Would you like to update by course name or course id?: ");
                                option = Console.ReadLine();
                                Console.WriteLine();
                                if (option.Equals("name"))
                                {
                                    Console.Write("Enter the course name you are searching for: ");
                                    name = Console.ReadLine();
                                    course = businessLayer.GetCourseByName(name);
                                    course = businessLayer.GetCourseByID(course.CourseId);
                                    Console.Write("\nEnter the updated course teacher's id: ");
                                    course.TeacherId = Convert.ToInt16(Console.ReadLine());
                                    businessLayer.UpdateCourse(course);
                                }
                                else if (option.Equals("id"))
                                {
                                    Console.Write("Enter the course ID you are searching for: ");
                                    id = Convert.ToInt16(Console.ReadLine());
                                    course = businessLayer.GetCourseByID(id);
                                    Console.Write("\nEnter the updated course teacher's id: ");
                                    course.TeacherId = Convert.ToInt16(Console.ReadLine());
                                    businessLayer.UpdateCourse(course);
                                }
                                break;
                            case 4:
                                Console.Write("Enter the course ID you want to delete: ");
                                id = Convert.ToInt16(Console.ReadLine());
                                course = businessLayer.GetCourseByID(id);

                                //Get rid of all connections in course
                                if (course.TeacherId != null)
                                {
                                    teacher = businessLayer.GetTeacherByID((int)course.TeacherId);
                                    teacher.Courses.Remove(course);
                                    businessLayer.UpdateTeacher(teacher);
                                }
                                
                                course.Teacher = null;
                                course.Students.Clear();
                                businessLayer.UpdateCourse(course);

                                businessLayer.RemoveCourse(course);
                                break;
                            case 5:
                                courseTable = businessLayer.GetAllCourses();
                                Console.WriteLine();
                                foreach (Course courseLoop in courseTable)
                                {
                                    Console.WriteLine(courseLoop.CourseName + " " + courseLoop.CourseId);
                                }
                                Console.WriteLine();
                                break;
                            default:
                                courseEnd = true;
                                break;
                        }
                    }
                }
                else if (intTemp == 5)
                {
                    Console.WriteLine("Program has been exited");
                    programEnd = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please select one of the above options.\n");
                }
            }
        }
     }
}
