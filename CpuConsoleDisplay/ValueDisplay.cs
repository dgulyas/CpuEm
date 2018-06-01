using System;

namespace CpuConsoleDisplay
{
	public class ValueDisplay
	{
		public string Name;
		public string Value;
		public Point Location;
		public int MinNameWidth = 7;
		public int MinValueWidth = 7;

		public void SetValue(object v)
		{
			var s = v as string;
			Value = s ?? v.ToString();
		}

		public void Print()
		{
			var currentRow = Location.rowNum;

			Console.SetCursorPosition(Location.columnNum, currentRow++);
			Console.Write(m_horizontalBorder);
			Console.SetCursorPosition(Location.columnNum, currentRow++);
			Console.Write($"|{Name.PadRight(m_actualNameWidth)}:{Value.PadRight(m_actualValueWidth)}|");
			Console.SetCursorPosition(Location.columnNum, currentRow);
			Console.Write(m_horizontalBorder);
		}

		private int m_actualNameWidth => Name.Length > MinNameWidth ? Name.Length : MinNameWidth;
		private int m_actualValueWidth => Value.Length > MinValueWidth ? Value.Length : MinValueWidth;
		private int m_width => m_actualNameWidth + m_actualValueWidth + 3;
		private string m_horizontalBorder => new string('-', m_width);
	}
}
