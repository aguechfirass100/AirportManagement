using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Staff : Passenger
{
    public DateTime EmploymentDate { get; set; }
    public string Function { get; set; }
    public double Salary { get; set; }

    public Staff() { }

    public Staff(int id, string firstName, string lastName, DateTime birthDate,
                 string emailAddress, string passportNumber, int telNumber,
                 DateTime employmentDate, string function, double salary)
        : base(id, firstName, lastName, birthDate, emailAddress, passportNumber, telNumber)
    {
        EmploymentDate = employmentDate;
        Function = function;
        Salary = salary;
    }

    public override void PassengerType()
    {
        base.PassengerType();
        Console.WriteLine("I am a staff member");
    }

    public override string ToString()
    {
        return base.ToString() + $", Employment Date: {EmploymentDate.ToShortDateString()}, " +
               $"Function: {Function}, Salary: {Salary:C}";
    }
}
