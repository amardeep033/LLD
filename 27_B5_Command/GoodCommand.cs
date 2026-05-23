public interface IGoodCommand
{
    void Execute();
    void Undo();
}





//each command is a class in itself -- which knows only class belonging to itself
//impl interface but with own respective class
public class GoodLightOnCommand : IGoodCommand
{
    private readonly GoodLight _light;

    public GoodLightOnCommand(GoodLight light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.On();
    }

    public void Undo()
    {
        _light.Off();
    }
}

public class GoodLightOffCommand : IGoodCommand
{
    private readonly GoodLight _light;

    public GoodLightOffCommand(GoodLight light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.Off();
    }

    public void Undo()
    {
        _light.On();
    }

}

public class GoodFanOnCommand : IGoodCommand
{
    private readonly GoodFan _fan;

    public GoodFanOnCommand(GoodFan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.On();
    }

    public void Undo()
    {
        _fan.Off();
    }
}

public class GoodFanPauseCommand : IGoodCommand
{
    private readonly GoodFan _fan;

    public GoodFanPauseCommand(GoodFan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.Pause();
    }

    public void Undo()
    {
        _fan.On();
    }
}

public class GoodFanOffCommand : IGoodCommand
{
    private readonly GoodFan _fan;

    public GoodFanOffCommand(GoodFan fan)
    {
        _fan = fan;
    }

    public void Execute()
    {
        _fan.Off();
    }

    public void Undo()
    {
        _fan.On();
    }
}