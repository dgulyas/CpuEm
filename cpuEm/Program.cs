using System;
using System.Collections.Generic;

namespace cpuEm
{
	public class Program
	{
		static void Main(string[] args)
		{
			var values = new List<ValueDisplay>
			{
				new ValueDisplay
				{
					Location = new Point {columnNum = 0, rowNum = 0},
					Name = "Test",
					Value = "Value"
					
				},
				new ValueDisplay
				{
					Location = new Point {columnNum = 10, rowNum = 10},
					Name = "Test",
					Value = "Value"
				},
				new ValueDisplay
				{
					Location = new Point {columnNum = 0, rowNum = 2},
					Name = "Testtttttttt",
					Value = "Value"
				},
			};

			foreach (var valueDisplay in values)
			{
				valueDisplay.Print();
			}

			Console.ReadLine();
		}
	}
}
