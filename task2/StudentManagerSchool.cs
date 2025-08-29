using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class StudentManagerSchool
    {
        private List<Student> students = new();
        private List<Course> courses = new();
        private List<Instructor> instructors = new();
        public bool AddStudent(Student student)
        {
            if (student == null)
                return false;
            if (students.Contains(student))
                return false;
            students.Add(student);
            return true;
        }
        public bool AddCourse(Course course)
        {
            if (course == null)
                return false;
            if (courses.Contains(course))
                return false;
            courses.Add(course);
            return true;
        }
        public bool AddInstructor(Instructor instructor)
        {
            if (instructor == null)
                return false;
            if (instructors.Contains(instructor))
                return false;
            instructors.Add(instructor);
            return true;
        }
        public Student FindStudent(int studentId)
        {
            foreach (var _student in students)
                if (_student.Id == studentId)
                    return _student;

            return null;
        }
        public Course FindCourse(int courseId)
        {
            foreach (var _course in courses)
                if (_course.Id == courseId)
                    return _course;
            return null;
        }
        public Instructor FindInstructor(int instructorId)
        {
            foreach (var _instructor in instructors)
                if (_instructor.Id == instructorId)
                    return _instructor;
            return null;
        }
        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            Student student = FindStudent(studentId);
            Course course = FindCourse(courseId);
            if (student == null || course == null)
                return false;
            return student.Enroll(course);
        }
        public List<Student> GetAllStudents() => students;
        public List<Course> GetAllCourses() => courses;
        public List<Instructor> GetAllInstructors() => instructors;


    }
}
