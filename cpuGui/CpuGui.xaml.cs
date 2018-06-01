using System.Windows;
using cpuGui;
using CpuProject;

namespace CpuGui
{
	/// <summary>
	/// Interaction logic for CpuView.xaml
	/// </summary>
	public partial class CpuView : Window
	{
		public readonly Cpu CpuInstance;
		public CpuModel CpuModel = new CpuModel();


		public CpuView(Cpu cpu)
		{
			CpuInstance = cpu;

			InitializeComponent();

		}

		public void TickAndUpdate()
		{
			CpuInstance.Tick();

			for (int i = 0; i < CpuInstance.Regs.Count; i++)
			{
				var row = new RegDataGridRow
				{
					regName = $"r{i}",
					regValue = CpuInstance.Regs[i].ToString()
				};

				if (i % 2 == 0) //i is even
				{
					CpuModel.EvenRegs.Add(row);
				}
				else
				{
					CpuModel.OddRegs.Add(row);
				}
			}

			CpuModel.CurrentInstruction = CpuInstance.GetCurrentInstruction();
		}

	}
}
