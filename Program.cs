using System.Diagnostics;

namespace UniversityCourses
{
    internal class Program
    {
        //CourseID || Student Names 
        static Dictionary<string, HashSet<string>> Courses = new Dictionary<string, HashSet<string>>();
        static HashSet<string> StudentNames = new HashSet<string>();

        static void Main(string[] args)
        {
            bool IdentityLoop = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
                Console.WriteLine("\n\nChoose one of the following options:");
                Console.WriteLine("1.  Admin");
                Console.WriteLine("2.  Students ");
                Console.WriteLine("3.  Shut down");
                Console.Write("\nEnter: ");

                int Identity = 0;
                try
                {
                    Identity = int.Parse(Console.ReadLine());
                }
                catch (Exception exception) { Console.WriteLine(exception.Message); }

                switch (Identity)
                {
                    case 1:
                        Admin();
                        break;

                    case 2:
                        Student();
                        break;

                    case 3:
                        Console.WriteLine("Are you sure you want to leave? \nYes to leave anything else to cancel.");
                        Console.Write("\nEnter: ");
                        string Leave = Console.ReadLine().ToLower();

                        if (Leave.Trim() == "yes")
                        {
                            Console.WriteLine("See you again soon!");
                            IdentityLoop = false;
                        }
                        break;

                    default:
                        Console.WriteLine("\n<!>Improper input please try again :( <!>");
                        break;

                }
            } while (IdentityLoop != false);

        }


        //*********************************ADMIN*******************************//
        static public void Admin()
        {
            //Go to admin --> view full course information[all courses and number of students enrolled and students in each course], add new course, remove course[check no one is enrolled], remove student from course, add student to course, search for student by course, search by student
            //View drop requests 
            bool AdminPage = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
                //AdminLogin();


                Console.WriteLine("\n\nChoose one of the following options:");
                Console.WriteLine("1.  View Course Information");
                Console.WriteLine("2.  Add New Course");
                Console.WriteLine("3.  Remove Course");
                Console.WriteLine("4.  Enroll Student to Course"); //view student profile(courses), remove student profile, remove course for specific student, add student to course
                Console.WriteLine("5.  Search for student by course");
                Console.WriteLine("6.  Remove student from course");
                Console.WriteLine("7.  Common Courses");
                Console.WriteLine("8.  Withderaw Student");
                Console.Write("\nEnter: ");

                int Identity = 0;

                try
                {
                    Identity = int.Parse(Console.ReadLine());
                }
                catch (Exception exception) { Console.WriteLine(exception.Message); }

                switch (Identity)
                {
                    case 1:
                        ViewCourses();
                        break;

                    case 2:
                        AddCourse();
                        break;

                    case 3:
                        RemoveCourse();
                        break;

                    case 4:
                        ManageStudent();
                        break;

                    case 5:
                        SearchByCourse();
                        break;

                    case 6:
                        RemoveStudent();
                        break;

                    case 7:
                        CommonStudents();
                        break;

                    case 8:
                        WithDrawStudent();
                        break;

                    default:
                        Console.WriteLine("\n<!>Improper input please try again :( <!>");
                        break;
                }

            } while (AdminPage != false);
        }

        /*
        static public void AdminLogin()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("Hi from Admin Login");
        }
        */

        static public void ViewCourses()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("VIEWING COURSES: ");

            Console.WriteLine("Course list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID: {0}", p.Key, " ");

                foreach(string students in p.Value)
                {
                    Console.WriteLine("Student Name: {0}", students, "\n");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("Press enter to continue");
            Console.ReadKey();

        }


        static public void AddCourse()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("ADDING COURSE: ");
            Console.Write("Enter ID: ");
            string CourseID = Console.ReadLine();

            Courses.Add(CourseID, new HashSet<string>() { });

            Console.WriteLine("\nThe new course list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID = {0}", p.Key, " ");
            }
            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();

        }


        static public void RemoveCourse()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("REMOVING COURSE: ");

            Console.WriteLine("\nCourse list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID = {0}", p.Key, " ");
            }


            Console.Write("\nEnter ID: ");
            string RemoveID = Console.ReadLine();

            if (Courses.ContainsKey(RemoveID)) //Checking if course  exists 
            {
                //check that no one is registered to this course 
                Courses.Remove(RemoveID); //Deleting the course

                Console.WriteLine("\nThe new course list: ");
                foreach (KeyValuePair<string, HashSet<string>> p in Courses)
                {
                    Console.WriteLine("CourseID = {0}", p.Key, " ");
                }
            }

            else
            {
                Console.WriteLine("\n<!>This course is not in the system<!>");
            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();
        }


        static public void ManageCourse()
        { }


        static public void ManageStudent()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("ADDING STUDENT: ");

            Console.WriteLine("\nCourse list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID = {0}", p.Key, " ");
            }

            //adding student 
            Console.Write("\nEnter course ID: ");
            string CourseID = Console.ReadLine();

            Console.Write("\nEnter student name: ");
            string StudentName = Console.ReadLine();

            if (Courses.ContainsKey(CourseID))
            {
                Courses[CourseID].Add(StudentName);

                foreach (KeyValuePair<string, HashSet<string>> p in Courses)
                {
                    Console.Write("CourseID = {0}", p.Key, " ");

                    foreach (string student in p.Value)
                    {
                        Console.Write("Name = {0}", student);
                    }
                }
            }

            else { Console.WriteLine("<!>Improper input<!>"); }
        }


        static public void SearchByCourse()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("SHOW STUDENTS IN COURSE: ");

            Console.WriteLine("\nCourse list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID = {0}", p.Key);
            }

            Console.Write("\nEnter ID: ");
            string CourseID = Console.ReadLine();


            if (Courses.ContainsKey(CourseID)) //Checking if course  exists 
            {
                Console.WriteLine("\nStudents in course: ");
                foreach (string students in Courses[CourseID])
                {
                    Console.WriteLine("Student Name = {0}", students);
                }

                Console.WriteLine("Would you like to remove any students? \nPress x to delete student \nPress enter to cancel.");
                string Choice = Console.ReadLine().ToLower(); 

                if (Choice.Trim() == "x")
                {
                    RemoveStudent();
                }

                else { Console.WriteLine("Cancelled"); }
            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();

        }


        static public void RemoveStudent()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("REMOVING STUDENT FROM COURSE: ");

            Console.WriteLine("\nCourse list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID = {0}", p.Key, " ");
            }

            Console.Write("\nEnter ID: ");
            string CourseID = Console.ReadLine();

            if (Courses.ContainsKey(CourseID)) //Checking if course  exists 
            {
                Console.WriteLine("\nStudents in course: ");
                foreach (string students in Courses[CourseID])
                {
                    Console.WriteLine("Student Name = {0}", students);
                }

                Console.Write("\nEnter student name: ");
                string StudentName = Console.ReadLine();

                foreach (string students in Courses[CourseID])
                {
                    if (students == StudentName)
                    {
                        Courses[CourseID].Remove(students); //removing specific student 
                    }
                }

                Console.WriteLine("\nNew Students List: ");
                foreach (string students in Courses[CourseID])
                {
                    Console.WriteLine("Student Name = {0}", students);
                }
            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();

        }


        static public void CommonStudents()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("FINDING COMMON STUDENTS: ");

            Console.WriteLine("\nCourse list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID = {0}", p.Key, " ");
            }

            Console.Write("\nEnter 1st course ID: ");
            string Course1 = Console.ReadLine();    
            Console.Write("\nEnter 2nd course ID: ");
            string Course2 = Console.ReadLine();

            if (Courses.ContainsKey(Course1))
            {
                if (Courses.ContainsKey(Course2))
                {
                    HashSet <string> CoursesOne = new HashSet<string>();
                    HashSet<string> CoursesTwo = new HashSet<string>();

                    //Creating copies so main data is not affected by changes 
                    CoursesOne = Courses[Course1];
                    CoursesTwo = Courses[Course2];
                    CoursesOne.IntersectWith(CoursesTwo);

                    Console.WriteLine("\nThe common students are: ");
                    foreach (string course in CoursesOne)
                    {
                        Console.WriteLine(course);
                    }
                }

                else
                { Console.WriteLine("<!>The second course ID does not exist<!>"); }
            }

            else
            { Console.WriteLine("<!>The first course ID does not exist<!>"); }

            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();
            
        }

        static public void WithDrawStudent()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("WITHDRAWING STUDENT: ");

            Console.WriteLine("\nStudent information: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID: {0}", p.Key, " ");

                foreach (string students in p.Value)
                {
                    Console.WriteLine("Student Name: {0}", students, "\n");
                }
                Console.WriteLine("\n");
            }

            Console.Write("Enter name: ");
            string Name = Console.ReadLine();

            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                HashSet<string> Student = new HashSet<string>();
                foreach (string students in p.Value)
                {
                    if (students == Name)
                    {
                        Student.Add(students);
                        p.Value.ExceptWith(Student);
                    }
                }
            }

            Console.WriteLine("\nUpdated Student Information: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.WriteLine("CourseID: {0}", p.Key, " ");

                foreach (string students in p.Value)
                {
                    Console.WriteLine("Student Name: {0}", students, "\n");
                }
                Console.WriteLine("\n");
            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadKey();
        }

            //****************************STUDENT***********************************************************//

        static public void Student()
        {
            //Go to User --> view courses, enroll in course, remove course enrollment[check wait list], drop out [check waitlist, remove from all enrolled courses], view profile
            //Request tp drop 
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("Hi from Student");
            StudentLogin();
        }

        static public void StudentLogin()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("Hi from Student Login");
        }


        static public void WaitList()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
        }
    }
}
