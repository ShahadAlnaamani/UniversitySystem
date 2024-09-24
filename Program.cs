using System.Diagnostics;

namespace UniversityCourses
{
    internal class Program
    {
        //CourseID || Student Names 
        static Dictionary <string, HashSet <string>> Courses = new Dictionary <string, HashSet<string>> ();
        static HashSet<string> StudentNames = new HashSet<string> ();

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
                AdminLogin();

                
                Console.WriteLine("\n\nChoose one of the following options:");
                Console.WriteLine("1.  View Course Information");
                Console.WriteLine("2.  Add course");
                Console.WriteLine("3.  Remove course");
                Console.WriteLine("4.  Manage students"); //view student profile(courses), remove student profile, remove course for specific student, add student to course
                Console.WriteLine("5.  Search for student by course");
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

                    default:
                        Console.WriteLine("\n<!>Improper input please try again :( <!>");
                        break;
                }
                
            }while (AdminPage != false);
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
                Console.Write("CourseID = {0}", p.Key, " ");
            }

        }


        static public void AddCourse()
        {
            Console.Clear();
            Console.WriteLine("\n\nC I T Y   U N I V E R S I T Y\n\n");
            Console.WriteLine("ADDING COURSE: ");
            Console.Write("Enter ID: ");
            string CourseID = Console.ReadLine();

            Courses.Add(CourseID, new HashSet<string>(){ });

            Console.WriteLine("The new course list: ");
            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.Write("CourseID = {0}", p.Key, " ");

            }

        }


        static public void RemoveCourse()
        { }


        static public void ManageCourse()
        { }


        static public void ManageStudent()
        {
            //adding student 
            Console.Write("Enter student name: ");
            string StudentName = Console.ReadLine();
            Courses["123A"].Add(StudentName);

            foreach (KeyValuePair<string, HashSet<string>> p in Courses)
            {
                Console.Write("CourseID = {0}", p.Key, " ");

                foreach (string student in p.Value)
                {
                    Console.Write("Name = {0}", student);
                }
            }
        }

        static public void SearchByCourse()
        { }



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
