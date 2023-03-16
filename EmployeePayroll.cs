using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_Problem
{
    public class EmployeePayroll
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Basic_Pay { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public long Phone_Number { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }
        public double Deductions { get; set; }
        public double Taxable_Pay { get; set; }
        public double Income_Tax { get; set; }
        public double Net_Pay { get; set; }
    }
}
