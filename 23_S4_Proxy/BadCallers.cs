public class BadPayrollController
{
    public void PrintSalary(int employeeId, string callerRole)
    {
        if (callerRole != "Admin")
        {
            Console.WriteLine("  [PayrollController] Access denied. Admins only.");
            return;
        }

        var service = new BadHRService();
        var employee = service.GetEmployee(employeeId);
        Console.WriteLine($"  [PayrollController] {employee.Name}'s salary: {employee.Salary:C}");
    }
}

public class BadReportingService
{
    public void PrintDepartment(int employeeId, string callerRole)
    {
        if (callerRole != "Admin" && callerRole != "Analyst")
        {
            Console.WriteLine("  [ReportingService] Access denied.");
            return;
        }

        var service = new BadHRService();
        var employee = service.GetEmployee(employeeId);
        Console.WriteLine($"  [ReportingService] {employee.Name} works in {employee.Department}");
    }
}

public class BadAuditLogger
{
    public void LogAccess(int employeeId, string callerRole)
    {
        var service = new BadHRService();
        var employee = service.GetEmployee(employeeId);
        Console.WriteLine($"  [AuditLogger] Employee {employee.Name} (id={employeeId}) was accessed by role={callerRole}");
    }
}