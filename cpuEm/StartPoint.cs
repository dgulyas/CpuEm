using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CpuProject;

namespace cpuEm
{
	public class StartPoint
	{
		static void Main(string[] args)
		{

			Window qWindow = new Window();
			qWindow.Title = "WPF in Console";
			qWindow.Width = 400;
			qWindow.Height = 300;
			qWindow.ShowDialog();




			//TODO: Add argument parsing to read in a program from file.
			var cpu = new Cpu();
			cpu.LoadProgram(new List<string> { "00000111011001010100001100101" });
			var w = new Window();
			//var cpuDisplay = new cpuGui.CpuGui;
			//cpuDisplay.ShowDialog
			//var cpuDisplay = new CpuDisplay();
			//cpuDisplay.Print(cpu);
			Console.ReadLine();
		}

		public static List<string> HexToBinary(List<string> hexProgram)
		{
			var binaryProgram = new List<string>();
			foreach (var hexInstruction in hexProgram)
			{
				string binaryString = String.Join(String.Empty,
					hexInstruction.Select(c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')));
				binaryProgram.Add(binaryString);
			}

			return binaryProgram;
		}

	}
}
