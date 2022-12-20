using Godot;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

public class Updater : Panel
{

	private string fullPath = System.IO.Directory.GetCurrentDirectory();
	private string UpdaterPath = System.IO.Directory.GetCurrentDirectory() + "\\Updater.exe";

	private void Download(string path){
		System.Diagnostics.ProcessStartInfo processStart = new System.Diagnostics.ProcessStartInfo();
		processStart.FileName = path;
		processStart.Verb = "runas";
		processStart.CreateNoWindow = true;
		processStart.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
		System.Diagnostics.Process.Start(processStart);
	}

	public override void _Ready()
	{
		//System.Console.WriteLine("Hello!");
		GetNode<Button>("Button2").Text = "Download Update";
	}

	private async void _on_Button2_pressed()
	{
		if (System.IO.File.Exists(UpdaterPath)){
			if (GetNode<Button>("Button2").Text == "Confirm Update"){
				GetNode<Button>("Button2").Disabled = true;
				GetTree().ReloadCurrentScene();
				GetNode<Button>("Button2").Disabled = false;
				GetNode<Button>("Button").Disabled = false;
				GetNode<Button>("Button2").Text = "Download Update";
			}
			else{
				GetNode<Button>("Button2").Disabled = true;
				GetNode<Button>("Button").Disabled = true;
				GetNode<Button>("Button2").Text = "Confirm Update";
				await Task.Delay(50);
				Download(UpdaterPath);
				await Task.Delay(350);
				while(!System.IO.File.Exists(fullPath + "\\Test2.pck")){
					await Task.Delay(1000);
				}
				await Task.Delay(500);
				GetNode<Button>("Button2").Disabled = false;
			}
		}
		else{
			GD.Print("Updater not exist!");
		}
		// if (System.IO.File.Exists("Updater.exe")){
		// 	Launch(UpdaterPath);
		// 	GetNode<Button>("Button2").Disabled = true;
		// 	System.Threading.Thread.Sleep(15000);
		// 	GetNode<Button>("Button2").Disabled = false;
		// }
		// else{
		// 	GetNode<Button>("Button2").Disabled = true;
		// 	GetNode<Label>("Label2").Text = UpdaterPath;
		// 	System.Threading.Thread.Sleep(1000);
		// 	GetNode<Button>("Button2").Disabled = false;
		// }
		// if (System.IO.File.Exists("Test2.pck")){
		// 	GetTree().ReloadCurrentScene();
		// }
		// else{
		// 	System.Threading.Thread.Sleep(5000);
		// 	GetTree().ReloadCurrentScene();
		// }
	}
}
