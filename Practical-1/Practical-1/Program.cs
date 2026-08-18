using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practical_1
{
    internal class Program
    {
        class Student
        {
            public int AdmissionNumber;
            public string StudentName;
            public string Course;
            public int Semester;

            private double fees;
            private bool IsScholarshipEligible;

            private const double ScholarshipRate = 0.10;

            public Student()
            {
                Console.WriteLine("____________________________");
                Console.WriteLine("STUDENT ADMISSION SYSTEM");
                Console.WriteLine("____________________________");

                Course = "Computer Engineering";
                Semester = 5;
                Console.WriteLine("Student Object Created Successfully");
                Console.WriteLine();
            }

            public void AcceptDetails()
            {
                Console.WriteLine("Enter Admission Number:");
                AdmissionNumber = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter student name:");
                StudentName = Console.ReadLine();

                Console.Write("Enter course:");
                Course = Console.ReadLine();

                Console.Write("Enter semester:");
                Semester = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Admission Fees:");
                fees = Convert.ToInt32(Console.ReadLine());
            }

            public void CheckScholarshipEligibility()
            {
                if (fees <= 5000)
                {
                    IsScholarshipEligible = true;
                }
                else
                {
                    IsScholarshipEligible = false;
                }
            }
            public void DisplayDetails()
            {
                double FinalFees = fees;
                if (IsScholarshipEligible)
                {
                    FinalFees = fees - (fees * ScholarshipRate);
                }
                Console.WriteLine();
                Console.WriteLine("_____________________________");
                Console.WriteLine("STUDENT ADMISSION DETAILS");
                Console.WriteLine("_____________________________");
                Console.WriteLine("Admisssion Number:" + AdmissionNumber);
                Console.WriteLine("Student Name:" + StudentName);
                Console.WriteLine("Course:" + Course);
                Console.WriteLine("Semester:" + Semester);
                Console.WriteLine("Admission Fees:" + fees);
                Console.WriteLine("Scholarship:" + (IsScholarshipEligible ?
"Eligible" : "Not Eligible"));
                Console.WriteLine("Final Fees:" + FinalFees);
                Console.WriteLine("_____________________________");
            }
        }
        static void Main(string[] args)
        {
            Student student = new Student();
            student.AcceptDetails();
            student.CheckScholarshipEligibility();
            student.DisplayDetails();
        }
    }
}

