public interface IHRService
{
    EmployeeData GetEmployee(int id, string callerRole);
}