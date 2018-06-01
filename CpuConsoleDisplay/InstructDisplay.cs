using System;
using CpuProject;

namespace CpuConsoleDisplay
{
	class InstructDisplay
	{
		public Instruction Instruct;
		public Point Location;

		public void SetInstruction(Instruction i)
		{
			Instruct = i;
		}

		public void Print()
		{
			var currentRow = Location.rowNum;

			Console.SetCursorPosition(Location.columnNum, currentRow++);
			Console.Write(m_horizontalBorder);
			Console.SetCursorPosition(Location.columnNum, currentRow++);
			Console.Write($"|{Instruct.Binary}|");
			Console.SetCursorPosition(Location.columnNum, currentRow++);
			Console.Write($"|{Instruct.DecLine}|");
			Console.SetCursorPosition(Location.columnNum, currentRow++);
			Console.Write($"|{Instruct.GetDescriptionLine()}|");
			Console.SetCursorPosition(Location.columnNum, currentRow);
			Console.Write(m_horizontalBorder);
		}

		private int m_width => Instruct.BinaryWidth + 2;
		private string m_horizontalBorder => new string('-', m_width);
	}
}
