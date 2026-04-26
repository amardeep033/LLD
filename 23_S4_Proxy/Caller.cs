// All callers depend only on IHRService.
// They have NO idea a proxy is involved — that's the whole point.
// No access control, no caching, no logging logic lives here.

public class PayrollController
{
    private readonly IHRService _hrService;

    public PayrollController(IHRService hrService)
    {
        _hrService = hrService;
    }

    public void PrintSalary(int employeeId, string callerRole)
    {
        var employee = _hrService.GetEmployee(employeeId, callerRole);

        if (employee.Salary == 0)
            Console.WriteLine($"  [PayrollController] Salary for {employee.Name} is restricted for your role.");
        else
            Console.WriteLine($"  [PayrollController] {employee.Name}'s salary: {employee.Salary:C}");
    }
}

public class ReportingService
{
    private readonly IHRService _hrService;

    public ReportingService(IHRService hrService)
    {
        _hrService = hrService;
    }

    public void PrintDepartment(int employeeId, string callerRole)
    {
        var employee = _hrService.GetEmployee(employeeId, callerRole);
        Console.WriteLine($"  [ReportingService] {employee.Name} works in {employee.Department}");
    }
}

public class AuditLogger
{
    private readonly IHRService _hrService;

    public AuditLogger(IHRService hrService)
    {
        _hrService = hrService;
    }

    public void LogAccess(int employeeId, string callerRole)
    {
        var employee = _hrService.GetEmployee(employeeId, callerRole);
        Console.WriteLine($"  [AuditLogger] Record confirmed: {employee.Name} (id={employeeId})");
    }
}