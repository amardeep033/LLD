//proxy is used for security - Proxy adds behavior without changing real object.
//only premium users can play + cache metadata + log watch history+ load expensive object only when needed
//both proxyService and realService implement the same interface 'IService'
//Common Types of Proxy
//1.Virtual Proxy - controls access to a resource that is expensive to create. It creates the object only when it is needed.
//2.Remote Proxy - provides a local representative for an object that is located in a different address
//3.Protection Proxy - controls access to a resource based on access rights -----------
//4.Cache Proxy - provides temporary storage of results to improve performance ---------
//5.Logging Proxy - logs the interactions with the real object for auditing or debugging purposes
//6. Smart Reference Proxy - performs additional actions when an object is accessed, such as reference

//--------------------------------------------------------------------------------------------------------------------------------------

// var bad_payroll = new BadPayrollController();
// bad_payroll.PrintSalary(1, "Admin");

// var bad_reporting = new BadReportingService();
// bad_reporting.PrintDepartment(1, "Analyst");

// var bad_audit = new BadAuditLogger();
// bad_audit.LogAccess(1, "ReadOnly");

// Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

IHRService service = new HRServiceProxy(new HRService());

var payroll = new PayrollController(service);
payroll.PrintSalary(1, "Admin");

var reporting = new ReportingService(service); 
reporting.PrintDepartment(1, "Analyst");

var audit = new AuditLogger(service);
audit.LogAccess(1, "ReadOnly");