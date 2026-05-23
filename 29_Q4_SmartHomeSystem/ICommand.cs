public interface ICommand
{
    //if i put queue here -- then On and Off commands will have to implement it as well, which doesn't make sense. but if i don't put it here, then RemoteButton will have to know about the specific command types, which also doesn't make sense. so where should i put the queue method?
    // void Queue();
    void Execute();
    void Undo();
}

public class StructureOn : ICommand
{
    private readonly IStructure _structure;

    public StructureOn(IStructure structure)
    {
        _structure = structure;
    }

    // public void Queue()
    // {
    //     Console.WriteLine($"Queuing Structure ON command for Structure: {_structure}");
    // }

    public void Execute()
    {
        _structure.On();
    }

    public void Undo()
    {
        _structure.Off();
    }
}

public class StructureOff : ICommand
{
    private readonly IStructure _structure;

    public StructureOff(IStructure structure)
    {
        _structure = structure;
    }

    // public void Queue()
    // {
    //     Console.WriteLine($"Queuing Structure OFF command for Structure: {_structure}");
    // }

    public void Execute()
    {
        _structure.Off();
    }

    public void Undo()
    {
        _structure.On();
    }
}

public class SetTemperatureCommand : ICommand
{
    private readonly Ac _ac;
    private readonly int _temperature;
    private Stack<int> _previousTemperatures = new Stack<int>();

    public SetTemperatureCommand(Ac ac, int temperature)
    {
        _ac = ac;
        _temperature = temperature;
    }

    public void Execute()
    {
        _previousTemperatures.Push(_ac.GetCurrentTemperature());
        _ac.setTemperature(_temperature);
    }

    public void Undo()
    {
        if (_previousTemperatures.Count > 0)
        {
            _ac.setTemperature(_previousTemperatures.Pop());
        }
    }
}