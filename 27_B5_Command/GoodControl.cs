public class GoodRemoteButton
{
    //if tmrw we want to add a new device, we just need to create a new command class and implement the IGoodCommand interface, without changing the existing code of the remote button or the other commands.
    //indp class taking interface
    private IGoodCommand _command;
    private Stack<IGoodCommand> _history = new Stack<IGoodCommand>();


    public void SetCommand(IGoodCommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
        _history.Push(_command);
    }

    public void PressUndo()
    {
        Console.WriteLine("Undoing last command...");
        // _command.Undo();
        if (_history.Count > 0)
        {
            IGoodCommand command = _history.Pop();
            command.Undo();
        }
        else
        {
            Console.WriteLine("Nothing to undo");
        }
    }
}