public class HRServiceProxy : IHRService
{
    private readonly IHRService _real;
    private readonly Dictionary<int, EmployeeData> _cache = new();

    private static readonly HashSet<string> _allowedRoles = new() { "Admin", "Analyst", "ReadOnly" };
    private static readonly HashSet<string> _salaryRoles = new() { "Admin" };

    public HRServiceProxy(IHRService real)
    {
        _real = real;
    }

    public EmployeeData GetEmployee(int id, string callerRole)
    {
        // --- 1. Access control (one place, consistently enforced for ALL callers) ---
        if (!_allowedRoles.Contains(callerRole))
            throw new UnauthorizedAccessException(
                $"Role '{callerRole}' is not permitted to access employee data.");

        // --- 2. Audit logging (one place) ---
        Console.WriteLine($"  [PROXY] Access by role='{callerRole}' for employee id={id}");

        // --- 3. Cache check (one place) ---
        if (_cache.TryGetValue(id, out var cached))
        {
            Console.WriteLine($"  [CACHE HIT] Returning cached data for employee {id}");
            return SanitizeForRole(cached, callerRole);
        }

        // --- 4. Delegate to real service only when necessary ---
        var data = _real.GetEmployee(id, callerRole);
        _cache[id] = data;

        return SanitizeForRole(data, callerRole);
    }

    // Strips fields the caller's role isn't allowed to see.
    // Callers get back a clean object — they never see salary unless they're Admin.
    private static EmployeeData SanitizeForRole(EmployeeData data, string callerRole)
    {
        return new EmployeeData
        {
            Id         = data.Id,
            Name       = data.Name,
            Department = data.Department,
            Salary     = _salaryRoles.Contains(callerRole) ? data.Salary : 0
        };
    }
}