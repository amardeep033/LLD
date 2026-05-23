public interface IStructure
{
    //one doubt here: should we have add/remove methods in the interface? but then device will have to implement them as well, which doesn't make sense

    //show doesnt belong here -- just for demo added

    //few methods logic are repeated in both home and device, so added here to avoid code duplication
    void Show();
    void On();
    void Off();
}