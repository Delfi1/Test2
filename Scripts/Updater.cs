using Godot;
using System;
using System.IO;
using System.Threading;

public class Updater : Panel
{

	private string fullPath = System.IO.Directory.GetCurrentDirectory();
	private string UpdaterPath = System.IO.Directory.GetCurrentDirectory() + "\\Updater.exe";

	private void Launch(string path){
		System.Diagnostics.ProcessStartInfo processStart = new System.Diagnostics.ProcessStartInfo();
		processStart.FileName = path;
		processStart.CreateNoWindow = true;
		processStart.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		System.Diagnostics.Process.Start(processStart);
	}

	public override void _Ready()
	{
		//System.Console.WriteLine("Hello!");
	}

	private void _on_Button2_pressed()
	{
		//GetTree().ReloadCurrentScene();
		if (System.IO.File.Exists("Updater.exe")){
			Launch(UpdaterPath);
			GetNode<Button>("Button2").Disabled = true;
			System.Threading.Thread.Sleep(15000);
			GetNode<Button>("Button2").Disabled = false;
		}
		else{
			GetNode<Button>("Button2").Disabled = true;
			GetNode<Label>("Label2").Text = UpdaterPath;
			System.Threading.Thread.Sleep(1000);
			GetNode<Button>("Button2").Disabled = false;
		}
		if (System.IO.File.Exists("Test2.pck")){
			GetTree().ReloadCurrentScene();
		}
		else{
			System.Threading.Thread.Sleep(5000);
			GetTree().ReloadCurrentScene();			
		}
	}
}
