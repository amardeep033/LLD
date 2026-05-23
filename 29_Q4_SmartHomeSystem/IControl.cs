public class Remote
{
    //not null safe -- what if someone calls press execute without setting a command? can add null check in execute and queue methods, but for simplicity skipping that here
    // private ICommand _command;
    private ICommand? _command;

    private Stack<ICommand> _history = new Stack<ICommand>();
    private Queue<ICommand> _queue = new Queue<ICommand>();

    //undo means reverse last executed command, not last queued command

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressQueue()
    {
        if (_command is null)
        {
            Console.WriteLine("No command set to queue.");
            return;
        }
        Console.WriteLine($"Queuing command {_command}...");
        _queue.Enqueue(_command);
    }

    public void PressExecute()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("No commands in queue to execute.");
            return;
        }
        while (_queue.Count > 0)
        {
            ICommand command = _queue.Dequeue();
            command.Execute();
            _history.Push(command);
        }
    }

    public void PressUndo()
    {
        Console.WriteLine("Undoing last command...");
        if (_history.Count > 0)
        {
            ICommand command = _history.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("Nothing to undo");
        }
    }
}