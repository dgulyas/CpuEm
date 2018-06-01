using System.Windows;
using CpuProject;

namespace CpuFormGui
{
	/// <summary>
	/// Interaction logic for CpuView.xaml
	/// </summary>
	public partial class CpuForm : Window
	{
		public readonly Cpu CpuInstance;
		public CpuModel CpuModel = new CpuModel();

		public CpuForm(Cpu cpu)
		{
			CpuInstance = cpu;

			InitializeComponent();

		}

		public void Update()
		{
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
			//TODO: make the current instruction show up

			if (ConsoleInput.Text.Length > 0)
			{
				CpuModel.ConsoleOutput += ConsoleInput.Text;
				ConsoleInput.Text = "";
			}
		}

		private void TickCpu(object sender, RoutedEventArgs e)
		{
			CpuInstance.Tick();
			Update();
		}

	}
}
