using System;
using System.Collections.Generic;
using System.Linq;
using CpuProject;

namespace Command
{
	//The Command project deals with all the start up things. Parsing args, creating CPU's and loading programs into them, hooking GUIs onto them, etc.
	class Program
	{
		static void Main(string[] args)
		{
			//TODO: Add argument parsing to read in a program from file.
			var cpu = new Cpu();
			cpu.LoadProgram(new List<string> { "00000111011001010100001100101" });

			var cpuDisplay = new CpuGui.CpuView(cpu);
			cpuDisplay.Show();
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
