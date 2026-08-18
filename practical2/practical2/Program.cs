//.Net Lab-2 (Calculate the salary of the employee based on their type (Full-Time or Part-Time))
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoEmployee_Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Employee Payroll System");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Full Time");
            Console.WriteLine("2. Part Time");
            Console.WriteLine("Enter Your Choice:");
            int ch = Convert.ToInt32(Console.ReadLine());

            if (ch == 1)
            {
                fullTimeemp f = new fullTimeemp();
                f.acceptemp();
                f.display();
                f.Calsal();
            }
            else if (ch == 2)
            {
                parttime p = new parttime();
                p.acceptemp();
                p.display();
                p.Calsal();
            }
            else
            {
                Console.WriteLine("Invalid Choice");
            }

            Console.ReadKey();
        }
        interface Ipayroll
        {
            //Calculate the salary of the employee based on their type (Full-Time) or (Part-Time)
            void Calsal();
        }
        class employeepay
        {
            //Data members
            public int id;
            public string name;
            public double b_salary;
            public string etype;

            //constructor
            public employeepay() //Main
            {
                Console.WriteLine("Employee Payroll System:");
                Console.WriteLine("------------------------");
            }

            //Method to accept employee data
            public void acceptemp()
            {
                Console.WriteLine("Enter Emp Id:");
                id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Emp Name:");
                name = Console.ReadLine();
                Console.WriteLine("Enter Emp Basic Salary:");
                b_salary = Convert.ToDouble(Console.ReadLine());
            }
            //method to Display employee details
            public void display()
            {
                Console.WriteLine("Employee Id = " + id);
                Console.WriteLine("Employee Name = " + name);
                Console.WriteLine("Employee Basic Salary = " + b_salary);
            }
        }
        class fullTimeemp : employeepay, Ipayroll //Derieved class
        {
            public void Calsal()
            {
                double hra = b_salary * 0.20;
                double ma = b_salary * 0.10;
                double da = b_salary * 0.12;
                double pf = 2500;

                double netsal = ((b_salary + hra + ma + da) - pf);
                Console.WriteLine("Employee type = Full Time");
                Console.WriteLine("Net Salary = " + netsal);


            }
        }
        class parttime : employeepay, Ipayroll //derieved class2
        {
            public void Calsal()
            {
                double netsalary = b_salary;
                Console.WriteLine("Employee Type = Part Time");
                Console.WriteLine("Net Salary = " + netsalary);
            }
        }
    }
}