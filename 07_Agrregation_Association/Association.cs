using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _7_Agrregation_Association
{
    // ============================================================
    // ASSOCIATION — Doctor "uses" Patient, no ownership
    // Patient exists independently, Doctor doesn't own it
    // ============================================================
    public class Patient
    {
        public string Name { get; set; }
        public Patient(string name) => Name = name;
    }

    public class Doctor
    {
        public string Name { get; set; }
        public Doctor(string name) => Name = name;

        // Patient is passed in — Doctor doesn't own it -- no method field
        // Patient exists before this call and after this call
        public void Treat(Patient patient)
        {
            Console.WriteLine($"Dr.{Name} is treating {patient.Name}");
        }
    }
}