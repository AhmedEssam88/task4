using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class Student: Person
    {
        public int Age { get; set; }
        public List<Course> Courses = new();
        public Student(int id, string name, int age, List<Course> courses):base(id, name)
        {
            Age = age;
            Courses = courses;
        }
        public bool Enroll(Course course)
        {
            if (course == null)
                return false;
            if (Courses.Contains(course))
                return false;

            Courses.Add(course);
            return true;
        }
        public override string PrintDetails()
        {
            return $"Student[ID={Id}, Name={Name}, Age={Age}]";
        }
    }
}
