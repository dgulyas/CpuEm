using System.Collections.Generic;
using System.IO;

namespace Command
{
	public static class ProgramLoader
	{
		public static List<string> ReadInBinaryExe(string filePath)
		{
			var instructionArray = File.ReadAllLines(filePath);
			var instructionList = new List<string>(instructionArray);
			instructionList.RemoveAt(0); //The first line is meta-data
			return instructionList;
		}

	}
}
