using System.Diagnostics;

namespace UniversityCourses
{
    internal class Program
    {
        //CourseID || Student Names 
        Dictionary <string, HashSet <string>> Courses = new Dictionary <string, HashSet<string>> ();
        HashSet<string> StudentNames = new HashSet<string> ();

        static void Main(string[] args)
        {
            Console.WriteLine("C I T Y   L I B R A R Y");

            Console.WriteLine("Choose one of the following options:");
            Console.WriteLine("1.  Admin");
            Console.WriteLine("2.  Students ");
            Console.Write("\nEnter: ");

            int Identity = 0;
            try
            {
                Identity = int.Parse(Console.ReadLine());
            } catch (Exception exception) { Console.WriteLine(exception.Message); } 

            switch (Identity)
            {
                case 1:
                    Admin();
                    break;

                case 2:
                    Student();
                    break;

                default:
                    Console.WriteLine("\n<!>Improper input please try again :( <!>");
                    break;
            
            }
            //Go to admin --> view full course information[all courses and number of students enrolled and students in each course], add new course, remove course[check no one is enrolled], remove student from course, add student to course, search for student by course, search by student


            //Go to User --> view courses, enroll in course, remove course enrollment[check wait list], drop out [check waitlist, remove from all enrolled courses], view profile 

        }

        static public void Admin()
        {
            //Go to admin --> view full course information[all courses and number of students enrolled and students in each course], add new course, remove course[check no one is enrolled], remove student from course, add student to course, search for student by course, search by student
            Console.WriteLine("Hi from admin");
            AdminLogin();
        }


        static public void Student()
        {
            //Go to User --> view courses, enroll in course, remove course enrollment[check wait list], drop out [check waitlist, remove from all enrolled courses], view profile
            Console.WriteLine("Hi from Student");
            StudentLogin();
        }


        static public void AdminLogin()
        {
            Console.WriteLine("Hi from Admin Login");
        }


        static public void StudentLogin()
        {
            Console.WriteLine("Hi from Student Login");
        }


        static public void WaitList()
        { }
    }
}
