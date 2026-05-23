public class  RemoteControl
{
    // Constructor Injection (DI) - tmrw if i wan to add AC -- it will change the code of this class -- not good
    private readonly ILightCommand _light;
    private readonly IFanCommand _fan;

    public RemoteControl(ILightCommand light, IFanCommand fan)
    {
        _light = light;
        _fan = fan;
    }

    public void LightOn()
    {
        _light.On();
    }

    public void LightOff()
    {
        _light.Off();
    }

    public void FanOn()
    {
        _fan.On();
    }

    public void FanPause()
    {
        _fan.Pause();
    }

    public void FanOff()
    {
        _fan.Off();
    }
}
