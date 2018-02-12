namespace cpuEm
{
	public class Point
	{
		public Point()
		{}

		public Point(int row, int col)
		{
			columnNum = col;
			rowNum = row;
		}

		//These match the arguments for the Console.SetCursorPosition function
		public int columnNum;
		public int rowNum;
	}
}
