using Godot;
using System;
using System.IO;
using System.Threading;

public class Updater : Panel
{
	private string UpdaterPath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "\\Updater.exe");

	public override void _Ready()
	{
		//System.Console.WriteLine("Hello!");
	}

	private void _on_Button2_pressed()
	{
		if (System.IO.File.Exists(UpdaterPath)){
			System.Diagnostics.Process.Start(UpdaterPath);
			GetNode<Button>("Button2").Disabled = true;
			System.Threading.Thread.Sleep(10000);
			GetNode<Button>("Button2").Disabled = false;
			GetTree().ReloadCurrentScene();
		}
		else{
			GetNode<Button>("Button2").Disabled = true;
			System.Threading.Thread.Sleep(1000);
			GetNode<Button>("Button2").Disabled = false;
		}
	}
}
