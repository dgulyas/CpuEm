using System.Collections.Generic;
using System.IO;
using System.Windows;
using CpuFormGui;
using CpuProject;

namespace Command
{
	public partial class App : Application
	{
		private void App_OnStartup(object sender, StartupEventArgs e)
		{
			var binProgram = new List<string> {"00000111011001010100001100101"};

			if (e.Args.Length > 0)
			{
				if (File.Exists(e.Args[0]))
				{
					binProgram = ProgramLoader.ReadInBinaryExe(e.Args[0]);
				}
			}

			var cpu = new Cpu();
			cpu.LoadProgram(binProgram);
			var cpuGui = new CpuForm(cpu);
			cpuGui.Show();
		}

	}
}
