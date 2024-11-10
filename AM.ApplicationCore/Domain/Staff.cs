using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class Staff : Passenger
{
    public DateTime EmploymentDate { get; set; }
    public string Function { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Salary { get; set; }

    //public string StaffSpecificProperty { get; set; }

    public Staff() { }

    public Staff(int id, FullName fullName, DateTime birthDate,
                 string emailAddress, string passportNumber, int telNumber,
                 DateTime employmentDate, string function, decimal salary)
        : base(id, fullName, birthDate, emailAddress, passportNumber, telNumber)
    {
        EmploymentDate = employmentDate;
        Function = function;
        Salary = salary;
    }

    public override string GetPassengerType()
    {
        return "I am a Staff member";
    }

    public override string ToString()
    {
        return base.ToString() + $", Employment Date: {EmploymentDate.ToShortDateString()}, " +
               $"Function: {Function}, Salary: {Salary:C}";
    }
}
