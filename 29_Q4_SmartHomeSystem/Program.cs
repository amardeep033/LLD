Console.WriteLine("--- Smart Home System Simulation ---");
Console.WriteLine($"Is SmartHomeHub created? {SmartHomeHub.IsSmartHomeHubCreated}");
SmartHomeHub smart_home_hub = SmartHomeHub.Instance;
Console.WriteLine($"Is SmartHomeHub created? {SmartHomeHub.IsSmartHomeHubCreated}");

Console.WriteLine("\n--- Setting up Home Structure ---");

Home home = smart_home_hub.GetHome();
Room bedroom = new Room("Bedroom");
Room hall = new Room("Hall");
Device bedroom_light = new Light("Bedroom Light");
Device bedroom_fan = new Fan("Bedroom Fan");
//ref type needs to be AC instead of device to access setTemp method
Ac bedroom_ac = new Ac("Bedroom AC");
Device hall_light = new Light("Hall Light");
Device hall_fan = new Fan("Hall Fan");
bedroom.Add(bedroom_light);
bedroom.Add(bedroom_fan);
bedroom.Add(bedroom_ac);
hall.Add(hall_light);
hall.Add(hall_fan);
home.Add(bedroom);
home.Add(hall); 
home.Show();
Ac test_ac = new Ac("Test AC");

Console.WriteLine("\n--- Commands from here ---");

Remote remote = smart_home_hub.GetRemote();
// remote.SetCommand(new StructureOn(home));
// remote.PressQueue();
// remote.SetCommand(new StructureOff(home));
// remote.PressQueue();
// remote.PressExecute();

Console.WriteLine("\n--- Commands for AC here ---");

remote.SetCommand(new StructureOn(bedroom_ac));
remote.PressQueue();
remote.SetCommand(new SetTemperatureCommand(bedroom_ac, 26));
remote.PressQueue();
remote.SetCommand(new StructureOn(test_ac));
remote.PressQueue();
remote.SetCommand(new SetTemperatureCommand(test_ac, 27));
remote.PressQueue();
remote.SetCommand(new SetTemperatureCommand(bedroom_ac, 30));
remote.PressQueue();
remote.SetCommand(new SetTemperatureCommand(bedroom_ac, 32));
remote.PressQueue();
remote.SetCommand(new StructureOff(test_ac));
remote.PressQueue();
remote.SetCommand(new SetTemperatureCommand(test_ac, 29));
remote.PressQueue();
remote.PressExecute();
remote.PressUndo(); //Cannot set temperature. Test AC is off. --- shouldnt come
remote.PressUndo(); //Turning on Test AC
remote.PressUndo(); //Setting Bedroom AC temperature from 32 to 30 degrees
remote.PressUndo(); //Setting Bedroom AC temperature from 30 to 26 degrees
remote.PressUndo(); //Setting Test AC temperature from 27 to 24 degrees
remote.PressUndo(); //Turning off Test AC
remote.PressUndo(); //Setting Bedroom AC temperature from 26 to 24 degrees
remote.PressUndo(); //Turning off Bedroom AC
remote.PressUndo(); //Nothing to undo