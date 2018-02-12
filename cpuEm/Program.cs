using System;

namespace cpuEm
{
	public class Program
	{
		static void Main(string[] args)
		{
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
