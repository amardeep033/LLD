public class  BadRemoteControl
{
    //tight coupling -- if we have interface and DI?
    private BadLight _light = new BadLight();
    private BadFan _fan = new BadFan();

    public void PressLightOn()
    {
        _light.On();
    }

    public void PressLightOff()
    {
        _light.Off();
    }

    public void PressFanOn()
    {
        _fan.On();
    }

    public void PressFanPause()
    {
        _fan.Pause();
    }

    public void PressFanOff()
    {
        _fan.Off();
    }
}
