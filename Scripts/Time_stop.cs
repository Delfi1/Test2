using Godot;
using System;
using System.Threading.Tasks;

public class Time_stop : Node
{
    bool reload = false;

    public override async void _Process(float delta)
    {
        await Task.Delay(10);
        if(Input.IsActionJustPressed("Stop") && !reload){
            GetTree().Paused = true;
            reload = true;
            await Task.Delay(2000);
            GetTree().Paused = false;
            await Task.Delay(1000);
            reload = false;
        }
    }
}
