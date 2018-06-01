using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using CpuProject;

namespace CpuFormGui
{
	public class CpuModel // : INotifyPropertyChanged
	{
		public List<RegDataGridRow> OddRegs;
		public List<RegDataGridRow> EvenRegs;

		//This could just be an instruction, but I'm not sure how to bind to something inside an object
		//inside the model.     Update, lets see if this works.
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

		//public event PropertyChangedEventHandler PropertyChanged;

		//protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		//{
		//	PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		//}
	}

	public class RegDataGridRow
	{
		public string regName;
		public string regValue;
	}
}
