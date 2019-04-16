using DataAccessLayer;
using System.Collections.Generic;

namespace BusinessLayer
{
    public interface IBusinessLayer
    {
        #region Standard
        IEnumerable<Standard> GetAllStandards();

        Standard GetStandardByID(int id);

        Standard GetStandardByName(string name);

        void AddStandard(Standard standard);

        void UpdateStandard(Standard standard);

        void RemoveStandard(Standard standard);
        #endregion

        //----------------------------------------------------------------------------------
        //Define other methods here
        #region Student
        IEnumerable<Student> GetAllStudents();

        Student GetStudentByID(int id);

        Student GetStudentByName(string name);

        void AddStudent(Student standard);

        void UpdateStudent(Student standard);

        void RemoveStudent(Student standard);
        #endregion

        #region Teacher
        IEnumerable<Teacher> GetAllTeachers();

        Teacher GetTeacherByID(int id);

        Teacher GetTeacherByName(string name);

        void AddTeacher(Teacher standard);

        void UpdateTeacher(Teacher standard);

        void RemoveTeacher(Teacher standard);
        #endregion

        #region Course
        IEnumerable<Course> GetAllCourses();

        Course GetCourseByID(int id);

        Course GetCourseByName(string name);

        void AddCourse(Course standard);

        void UpdateCourse(Course standard);

        void RemoveCourse(Course standard);
        #endregion
    }
}