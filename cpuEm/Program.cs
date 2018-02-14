using System;
using System.Collections.Generic;
using System.Linq;

namespace cpuEm
{
	public class Program
	{
		static void Main(string[] args)
		{
			//TODO: Add argument parsing to read in a program from file.
			var cpu = new Cpu();
			//cpu.LoadProgram();
			var cpuDisplay = new CpuDisplay();
			cpuDisplay.Print(cpu);
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
