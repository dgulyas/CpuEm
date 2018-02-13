using System;

namespace cpuEm
{
	public class Program
	{
		static void Main(string[] args)
		{
			var cpuDisplay = new CpuDisplay();
			cpuDisplay.Print();
			Console.ReadLine();

			var binary = "10101010101010101010101010101";
			var instruct = new Instruction(binary);
			var instDisplay = new InstructDisplay {Location = new Point(0, 0)};
			instDisplay.SetInstruction(instruct);
			instDisplay.Print();

			var data = "abcdefghijklmnopqrstuvwxyz.,/\\!@#$%^&*()";

			var console = new ConsoleDisplay(new Point(3, 4), 6, 6);

			while (true)
			{
				foreach (var c in data)
				{
					System.Threading.Thread.Sleep(100);
					console.AddAscii(Convert.ToInt32(c));
					console.Print();
				}
			}

		}
	}
}
