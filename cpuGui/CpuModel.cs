using System;
using System.Collections.Generic;
using CpuProject;


namespace cpuGui
{
	public class CpuModel
	{
		public List<RegDataGridRow> OddRegs;
		public List<RegDataGridRow> EvenRegs;

		//This could just be an instruction, but I'm not sure how to bind to something inside an object
		//inside the model.
		public Instruction CurrentInstruction;

		public string ConsoleOutput;
		public string ConsoleInput;

		public CpuModel()
		{
			OddRegs = new List<RegDataGridRow>();
			EvenRegs = new List<RegDataGridRow>();
			ConsoleOutput = "";
			ConsoleInput = "";
		}
	}

	public class RegDataGridRow
	{
		public string regName;
		public string regValue;
	}
}
