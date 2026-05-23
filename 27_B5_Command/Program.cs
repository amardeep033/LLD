//Command pattern is helpful when we want to have control over execution of a command: undo, redo, delay, schedule, queue or cancelled.

//there are two things: command type and actual command
//command type is like execute, undo --- functions
//actual command is like light on, light off, fan on, fan pause, fan off etc ---- classes
//so there will be 5 classes and 2 functions in each class -- execute and undo

Console.WriteLine("-----------Before applying DI and Interface------------");
BadRemoteControl bad_remote = new BadRemoteControl();
bad_remote.PressLightOn();
bad_remote.PressLightOff();
bad_remote.PressFanOn();
bad_remote.PressFanPause();
bad_remote.PressFanOff();

Console.WriteLine("-----------After applying DI and Interface------------");
ILightCommand light = new Light();
IFanCommand fan = new Fan();
RemoteControl remote = new RemoteControl(light, fan);
remote.LightOn();
remote.LightOff();
remote.FanOn();
remote.FanPause();
remote.FanOff();


Console.WriteLine("-----------After applying Command Pattern------------");
GoodLight good_light = new GoodLight();
GoodFan good_fan = new GoodFan();
GoodRemoteButton good_button = new GoodRemoteButton();

//remote takes -- ICommand type anything -- sets and executes it
//each command we are setting is a class in itself -- so object will be created each time -- no ocp violation -- and helps in queue too
//press button will execute last command set
//pressundo without stack will just undo last command -- with stack all history of command can be undone

good_button.SetCommand(new GoodLightOnCommand(good_light));
good_button.PressButton(); //1L_ON
good_button.SetCommand(new GoodFanOnCommand(good_fan));
good_button.PressButton(); //2F_ON
good_button.SetCommand(new GoodLightOffCommand(good_light));
good_button.PressButton(); //3L_OFF

good_button.PressUndo(); //3L_OFF -> L_ON(without stack -- only last set is fixed for n undo)  ----- with stack -- 3L_OFF -> L_ON
good_button.PressUndo(); //3L_OFF -> L_ON(without stack -- its not state based undo) --------------- with stack -- 2F_ON -> F_OFF
good_button.PressUndo(); //3L_OFF -> L_ON(without stack -- its not state based undo) --------------- with stack -- 1L_ON -> L_OFF
good_button.PressUndo(); //3L_OFF -> L_ON(without stack -- its not state based undo) --------------- with stack -- Nothing to undo