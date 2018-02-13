using System;
using System.Collections.Generic;
using System.Linq;

namespace cpuEm
{
	public class CpuDisplay
	{
		private readonly List<ValueDisplay> m_regDisplays;
		private readonly ConsoleDisplay m_console;
		private readonly InstructDisplay m_instructDisplay;

		public CpuDisplay()
		{
			var regPoints = new List<Point>(16);
			for (int i = 0; i < 8; i++)
			{
				regPoints.Add(new Point(i*2 + 1, 1));
				regPoints.Add(new Point(i*2 + 1, 16));
			}

			m_regDisplays = new List<ValueDisplay>();
			for (int i = 0; i < regPoints.Count; i++)
			{
				m_regDisplays.Add(new ValueDisplay
				{
					Location = regPoints[i],
					MinNameWidth = 4,
					MinValueWidth = 4,
					Value = "",
					Name = $"R{i}"
				});
			}

			m_console = new ConsoleDisplay(new Point(1, 33), 10, 8);

			var instruct = new Instruction("00000000000000000000000000000");
			m_instructDisplay = new InstructDisplay {Location = new Point(18, 1), Instruct = instruct};
		}

		public void Print()//Cpu cpu)
		{
			foreach (var regDisplay in m_regDisplays)
			{
				regDisplay.Print();
			}
			m_console.Print();
			m_instructDisplay.Print();


		}



	}
}
