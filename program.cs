public class Light
{
    public void TurnOn()
    {
        Console.WriteLine("The light is ON.");
    }

    public void TurnOff()
    {
        Console.WriteLine("The light is OFF.");
    }
}
public interface ICommand
{
    void Execute();
    void Undo();
}
public class TurnOnLightCommand : ICommand
{
    private readonly Light _light;

    public TurnOnLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOn();
    }

    public void Undo()
    {
        _light.TurnOff();
    }
}

public class TurnOffLightCommand : ICommand
{
    private readonly Light _light;

    public TurnOffLightCommand(Light light)
    {
        _light = light;
    }

    public void Execute()
    {
        _light.TurnOff();
    }

    public void Undo()
    {
        _light.TurnOn();
    }
}
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command;
    }

    public void PressButton()
    {
        _command.Execute();
    }

    public void PressUndo()
    {
        _command.Undo();
    }
}
class Program
{
    static void Main(string[] args)
    {
        // Receiver
        Light light = new Light();

        // Commands
        ICommand turnOnCommand = new TurnOnLightCommand(light);
        ICommand turnOffCommand = new TurnOffLightCommand(light);

        // Invoker
        RemoteControl remote = new RemoteControl();

        // Turn on the light
        remote.SetCommand(turnOnCommand);
        remote.PressButton(); // Output: The light is ON.

        // Undo turn on
        remote.PressUndo(); // Output: The light is OFF.

        // Turn off the light
        remote.SetCommand(turnOffCommand);
        remote.PressButton(); // Output: The light is OFF.

        // Undo turn off
        remote.PressUndo(); // Output: The light is ON.
    }
}
