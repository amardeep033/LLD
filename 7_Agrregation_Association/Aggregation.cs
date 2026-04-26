using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _7_Agrregation_Association
{
    // ============================================================
    // AGGREGATION — Department "has" Teachers, weak ownership
    // Teachers exist independently — can belong to multiple depts
    // If Department is deleted, Teachers still exist
    // ============================================================
    public class Teacher
    {
        public string Name { get; set; }
        public Teacher(string name) => Name = name;
    }

    public class Department
    {
        private readonly List<Teacher> _teachers;  // doesn't own them
        public string DeptName { get; set; }

        // Teachers are created OUTSIDE and passed in
        public Department(string name, List<Teacher> teachers)
        {
            DeptName = name;
            _teachers = teachers;
        }

        public void ShowTeachers()
        {
            foreach (var t in _teachers)
                Console.WriteLine($"{DeptName} has teacher: {t.Name}");
        }
    }
}