public class HRService : IHRService
{
    public EmployeeData GetEmployee(int id, string callerRole)
    {
        Console.WriteLine($"  [DB HIT] Fetching employee {id} from database...");
        Thread.Sleep(10);

        return id switch
        {
            1 => new EmployeeData { Id = 1, Name = "Alice",   Salary = 95000, Department = "Engineering" },
            2 => new EmployeeData { Id = 2, Name = "Bob",     Salary = 72000, Department = "Marketing"   },
            3 => new EmployeeData { Id = 3, Name = "Charlie", Salary = 61000, Department = "Support"     },
            _ => throw new KeyNotFoundException($"Employee {id} not found")
        };
    }
}