using System;
using System.Collections.Generic;
using System.Linq;

namespace cpuEm
{
	public class ConsoleDisplay
	{
		public Point Location;
		public int Height;
		public int Width;
		public List<char[]> Text;

		private readonly Point m_cursorPos = new Point {columnNum = -1, rowNum = 0};
		private char blankChar = ' ';

		public ConsoleDisplay(Point location, int height, int width)
		{
			Location = location;
			Height = height;
			Width = width;
			Text = new List<char[]>(Height);
			for (int i = 0; i < Height; i++)
			{
				Text.Add(GetLineArray(Width));
			}
		}

		/// <summary>
		/// Converts the asciiNum to a char according to ascii encoding and appends it to the next available space
		/// in the console.
		/// </summary>
		/// <param name="asciiNum"></param>
		public void AddAscii(int asciiNum)
		{
			AdvanceCursor();

			var c = Convert.ToChar(asciiNum);
			Text[m_cursorPos.rowNum][m_cursorPos.columnNum] = c;
		}

		public void Print()
		{
			for (var row = 0; row < Height; row++)
			{
				Console.SetCursorPosition(Location.columnNum, Location.rowNum + row);
				Console.Write(new string(Text[row]));
			}
		}

		private char[] GetLineArray(int length)
		{
			return Enumerable.Repeat(blankChar, length).ToArray();
		}

		/// <summary>
		/// This is probably hard to understand.
		/// Move the cursor to the right.
		/// If it's past the end of the "screen" then move it to the start,
		/// then if it's not past the bottom, move it down, otherwise
		/// scroll the lines up and put a blank one at the bottom.
		/// </summary>
		private void AdvanceCursor()
		{
			m_cursorPos.columnNum += 1;
			if (m_cursorPos.columnNum >= Width)
			{
				m_cursorPos.columnNum = 0;
				if (m_cursorPos.rowNum < Height - 1)
				{
					m_cursorPos.rowNum++;
				}
				else
				{
					Text.RemoveAt(0);
					Text.Add(GetLineArray(Width));
				}
			}
		}

	}
}
