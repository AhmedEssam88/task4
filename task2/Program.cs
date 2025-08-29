<<<<<<< HEAD
﻿namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {                
                bool isQuit = false, added;
                int age, instructorId, courseId, studentId,choice;
                string[] data;

                do
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("\n             Main Menu           \n1-Add Student\n2-Add Instructor\n3-Add Course\n4-Enroll Student in Course\n5-Show All Students\n6-Show All Courses\n7-Show All Instructors\n8  -  Find Student by id or name\n9-Find Course by id or title\n10-Quit\n==========================================||");
                    Console.WriteLine("------------------------");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    StudentManagerSchool school = new StudentManagerSchool();

                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("enter student details :id, name, age");
                            string[] studentDetails = Console.ReadLine().Split(',');
                            if (studentDetails.Length != 3)
                            {
                                Console.WriteLine("Invalid input. Please enter id, name, and age separated by commas.");
                                break;
                            }

                            try
                            {
                                studentId = int.Parse(studentDetails[0].Trim());
                                age = int.Parse(studentDetails[2].Trim());
                            }
                            catch
                            {

                                Console.WriteLine("id and age must be integers.");
                                break;
                            }

                            Student student = new Student(studentId, studentDetails[0].Trim(), age, new List<Course>());
                            added = school.AddStudent(student);
                            if (added)
                                Console.WriteLine("Student added.");
                            else
                                Console.WriteLine("error in add student");
                            break;

                        case 2:
                            Console.WriteLine("enter student details :id, name, age");
                            string[] instructorDetails = Console.ReadLine().Split(',');
                            if (instructorDetails.Length != 3)
                            {
                                Console.WriteLine("Invalid input. Please enter id, name, and age separated by commas.");
                                break;
                            }

                            try
                            {
                                instructorId = int.Parse(instructorDetails[0].Trim());

                            }
                            catch
                            {
                                Console.WriteLine("id and age must be integers.");
                                break;
                            }

                            Instructor instructor = new Instructor(instructorId, instructorDetails[1].Trim(), instructorDetails[2].Trim());
                            bool addedInstructor = school.AddInstructor(instructor);
                            if (addedInstructor)
                                Console.WriteLine("Instructor added.");
                            else
                                Console.WriteLine("error in add instructor");
                            break;
                        case 3:
                            Console.WriteLine("Enter course as: courseId,title,instructorId");
                            data = Console.ReadLine().Split(',');
                            if (data.Length != 3)
                            {
                                Console.WriteLine("Format must be: courseId,title,instructorId");
                                break;
                            }
                            try
                            {
                                courseId = Convert.ToInt32(data[0].Trim());
                                instructorId = Convert.ToInt32(data[2].Trim());
                            }
                            catch
                            {
                                Console.WriteLine("IDs must be numbers.");
                                break;
                            }


                            Instructor found = null;
                            List<Instructor> allInst = school.GetAllInstructors();
                            for (int i = 0; i < allInst.Count; i++)
                            {
                                if (allInst[i].Id == instructorId)
                                {
                                    found = allInst[i];
                                    break;
                                }
                            }

                            if (found == null)
                            {
                                Console.WriteLine("Instructor not found.");
                                break;
                            }

                            Course course = new Course(courseId, data[1].Trim(), found);
                            bool AddCourse = school.AddCourse(course);
                            if (AddCourse)
                                Console.WriteLine("Course added.");
                            else
                                Console.WriteLine("error in add course");
                            break;
                        case 4:
                            Console.WriteLine("Enter: studentId,courseId");
                            data = Console.ReadLine().Split(',');
                            if (data.Length != 2)
                            {
                                Console.WriteLine("Format must be: studentId,courseId");
                                break;
                            }


                            try
                            {
                                studentId = Convert.ToInt32(data[0].Trim());
                                courseId = Convert.ToInt32(data[1].Trim());
                            }
                            catch
                            {
                                Console.WriteLine("IDs must be numbers.");
                                break;
                            }
                            break;


                        case 5:
                            List<Student> allStudents = school.GetAllStudents();
                            if (allStudents.Count == 0)
                            {
                                Console.WriteLine("No students found.");
                                break;
                            }
                            foreach (var stud in allStudents)
                            {
                                Console.WriteLine(stud.PrintDetails());
                            }

                            break;
                        case 6:
                            List<Course> allCourses = school.GetAllCourses();
                            if (allCourses.Count == 0)
                            {
                                Console.WriteLine("No courses found.");
                                break;
                            }
                            foreach (var cour in allCourses)
                            {
                                Console.WriteLine(cour.PrintDetails());
                            }

                            break;
                        case 7:
                            List<Instructor> allInstructors = school.GetAllInstructors();
                            if (allInstructors.Count == 0)
                            {
                                Console.WriteLine("No instructors found.");
                                break;
                            }
                            foreach (var inst in allInstructors)
                            {
                                Console.WriteLine(inst.PrintDetails());
                            }
                            break;
                        case 8:
                            Console.WriteLine("Enter student id or name:");
                            string input = Console.ReadLine().Trim();
                            Student foundStudent = null;
                            List<Student> students = school.GetAllStudents();
                            foreach (var stud in students)
                            {
                                if (stud.Id.ToString() == input || stud.Name == input)
                                {
                                    foundStudent = stud;
                                    break;
                                }
                            }
                            if (foundStudent != null)
                            {
                                Console.WriteLine("Student found: " + foundStudent.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;
                        case 9:
                            Console.WriteLine("Enter course id or title:");
                            string courseInput = Console.ReadLine().Trim();
                            Course foundCourse = null;
                            List<Course> courses = school.GetAllCourses();
                            foreach (var cour in courses)
                            {
                                if (cour.Id.ToString() == courseInput || cour.Title == courseInput)
                                {
                                    foundCourse = cour;
                                    break;
                                }
                            }
                            if (foundCourse != null)
                            {
                                Console.WriteLine("Course found: " + foundCourse.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                            break;

                        case 10:
                            Console.WriteLine("quit");
                            isQuit = true;
                            break;
                        default:
                            Console.WriteLine("Invaliad Choise");
                            break;
                    }
                } while (!isQuit);
            }
        }
        }
    }

=======
﻿namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid number. Try again.");
                    continue;
                }
                bool isQuit = false, added;
                int age, instructorId, courseId, studentId;
                string[] data;

                do
                {
                    Console.WriteLine("------------------------");
                    Console.WriteLine("\n             Main Menu           \n1-Add Student\n2-Add Instructor\n3-Add Course\n4-Enroll Student in Course\n5-Show All Students\n6-Show All Courses\n7-Show All Instructors\n8  -  Find Student by id or name\n9-Find Course by id or title\n10-Quit\n==========================================||");
                    Console.WriteLine("------------------------");
                    int choise = Convert.ToInt32(Console.ReadLine());
                    StudentManagerSchool school = new StudentManagerSchool();

                    switch (choise)
                    {
                        case 1:
                            Console.WriteLine("enter student details :id, name, age");
                            string[] studentDetails = Console.ReadLine().Split(',');
                            if (studentDetails.Length != 3)
                            {
                                Console.WriteLine("Invalid input. Please enter id, name, and age separated by commas.");
                                break;
                            }

                            try
                            {
                                studentId = int.Parse(studentDetails[0].Trim());
                                age = int.Parse(studentDetails[2].Trim());
                            }
                            catch
                            {

                                Console.WriteLine("id and age must be integers.");
                                break;
                            }

                            Student student = new Student(studentId, studentDetails[0].Trim(), age, new List<Course>());
                            added = school.AddStudent(student);
                            if (added)
                                Console.WriteLine("Student added.");
                            else
                                Console.WriteLine("error in add student");
                            break;

                        case 2:
                            Console.WriteLine("enter student details :id, name, age");
                            string[] instructorDetails = Console.ReadLine().Split(',');
                            if (instructorDetails.Length != 3)
                            {
                                Console.WriteLine("Invalid input. Please enter id, name, and age separated by commas.");
                                break;
                            }

                            try
                            {
                                instructorId = int.Parse(instructorDetails[0].Trim());

                            }
                            catch
                            {
                                Console.WriteLine("id and age must be integers.");
                                break;
                            }

                            Instructor instructor = new Instructor(instructorId, instructorDetails[1].Trim(), instructorDetails[2].Trim());
                            bool addedInstructor = school.AddInstructor(instructor);
                            if (addedInstructor)
                                Console.WriteLine("Instructor added.");
                            else
                                Console.WriteLine("error in add instructor");
                            break;
                        case 3:
                            Console.WriteLine("Enter course as: courseId,title,instructorId");
                            data = Console.ReadLine().Split(',');
                            if (data.Length != 3)
                            {
                                Console.WriteLine("Format must be: courseId,title,instructorId");
                                break;
                            }
                            try
                            {
                                courseId = Convert.ToInt32(data[0].Trim());
                                instructorId = Convert.ToInt32(data[2].Trim());
                            }
                            catch
                            {
                                Console.WriteLine("IDs must be numbers.");
                                break;
                            }


                            Instructor found = null;
                            List<Instructor> allInst = school.GetAllInstructors();
                            for (int i = 0; i < allInst.Count; i++)
                            {
                                if (allInst[i].Id == instructorId)
                                {
                                    found = allInst[i];
                                    break;
                                }
                            }

                            if (found == null)
                            {
                                Console.WriteLine("Instructor not found.");
                                break;
                            }

                            Course course = new Course(courseId, data[1].Trim(), found);
                            bool AddCourse = school.AddCourse(course);
                            if (AddCourse)
                                Console.WriteLine("Course added.");
                            else
                                Console.WriteLine("error in add course");
                            break;
                        case 4:
                            Console.WriteLine("Enter: studentId,courseId");
                            data = Console.ReadLine().Split(',');
                            if (data.Length != 2)
                            {
                                Console.WriteLine("Format must be: studentId,courseId");
                                break;
                            }


                            try
                            {
                                studentId = Convert.ToInt32(data[0].Trim());
                                courseId = Convert.ToInt32(data[1].Trim());
                            }
                            catch
                            {
                                Console.WriteLine("IDs must be numbers.");
                                break;
                            }
                            break;


                        case 5:
                            List<Student> allStudents = school.GetAllStudents();
                            if (allStudents.Count == 0)
                            {
                                Console.WriteLine("No students found.");
                                break;
                            }
                            foreach (var stud in allStudents)
                            {
                                Console.WriteLine(stud.PrintDetails());
                            }

                            break;
                        case 6:
                            List<Course> allCourses = school.GetAllCourses();
                            if (allCourses.Count == 0)
                            {
                                Console.WriteLine("No courses found.");
                                break;
                            }
                            foreach (var cour in allCourses)
                            {
                                Console.WriteLine(cour.PrintDetails());
                            }

                            break;
                        case 7:
                            List<Instructor> allInstructors = school.GetAllInstructors();
                            if (allInstructors.Count == 0)
                            {
                                Console.WriteLine("No instructors found.");
                                break;
                            }
                            foreach (var inst in allInstructors)
                            {
                                Console.WriteLine(inst.PrintDetails());
                            }
                            break;
                        case 8:
                            Console.WriteLine("Enter student id or name:");
                            string input = Console.ReadLine().Trim();
                            Student foundStudent = null;
                            List<Student> students = school.GetAllStudents();
                            foreach (var stud in students)
                            {
                                if (stud.Id.ToString() == input || stud.Name == input)
                                {
                                    foundStudent = stud;
                                    break;
                                }
                            }
                            if (foundStudent != null)
                            {
                                Console.WriteLine("Student found: " + foundStudent.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Student not found.");
                            }
                            break;
                        case 9:
                            Console.WriteLine("Enter course id or title:");
                            string courseInput = Console.ReadLine().Trim();
                            Course foundCourse = null;
                            List<Course> courses = school.GetAllCourses();
                            foreach (var cour in courses)
                            {
                                if (cour.Id.ToString() == courseInput || cour.Title == courseInput)
                                {
                                    foundCourse = cour;
                                    break;
                                }
                            }
                            if (foundCourse != null)
                            {
                                Console.WriteLine("Course found: " + foundCourse.PrintDetails());
                            }
                            else
                            {
                                Console.WriteLine("Course not found.");
                            }
                            break;

                        case 10:
                            Console.WriteLine("quit");
                            isQuit = true;
                            break;
                        default:
                            Console.WriteLine("Invaliad Choise");
                            break;
                    }
                } while (!isQuit);
            }
        }
        }
    }

>>>>>>> ccdff87af025da4c1d5f2f5889006ad753f185de
