namespace EmployeePayrollProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please select given options");
                Console.WriteLine("1.CreateConnectionsWithDatabase\n" +
                    "8.Exit\n");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        Console.Clear();
                        EmployeeRepository.GetAllEmployees();
                        Console.Write("\nPress any key to continue...... ");
                        break;
                    case 8:
                        Console.Clear();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Please select only given options");
                        Console.Write("\nPress any key to continue...... ");
                        break;
                }
                Console.ReadLine();
            }
        }
    }
}
