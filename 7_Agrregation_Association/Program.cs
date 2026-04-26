// Association  →  "uses"    -- plain arrow →        — no ownership,  independent lifetime
// Aggregation  →  "has-a"   -- hollow diamond ◇     — weak ownership, child survives parent
// Composition  →  "owns-a"  -- filled diamond ◆     — strong ownership, child dies with parent

// Association — uses someone else's object -- [Doctor → Patient]
// Aggregation — holds a reference but didn't create it. -- [Department → Teacher]
// Composition — created it internally, fully responsible for its lifetime. -- [House → Room] 

// Association — both exist independently, just use each other temporarily.
// Doctor exists without Patient. Patient exists without Doctor.

// Aggregation — both exist independently, but one holds the other.
// Department exists without Teachers. Teachers exist without Department.

// The only difference from association is that Department maintains a reference (the list) — it's a longer-term relationship, not just a method call.
// Composition — child cannot exist without parent.
// Room has no meaning without House. ConnectionPool has no meaning without HttpClient.

// Association > Aggregation > Composition > Inheritance

//OrderService holds onto _processor and _logger for its entire lifetime -- Aggregation -- stored as field
//if use and forget then association -- that is not stored as field

using _7_Agrregation_Association;

class Program
{
    static void Main()
    {
        // --- ASSOCIATION ---
        var doctor = new Doctor("Smith");
        var patient = new Patient("Alice");  // exists independently
        doctor.Treat(patient);
        // patient still alive here — doctor has no hold on it



        // --- AGGREGATION ---
        var t1 = new Teacher("Mr. Roy");
        var t2 = new Teacher("Ms. Priya");          // created outside
        var dept = new Department("CS", new List<Teacher> { t1, t2 });
        dept.ShowTeachers();
        // dept = null → t1, t2 still alive. Teacher can join another dept.

        

        // --- COMPOSITION ---
        var house = new House();   // Rooms born here, inside House
        house.ShowRooms();
        // house = null → Rooms are gone. No one holds a reference to them.
    }
}

