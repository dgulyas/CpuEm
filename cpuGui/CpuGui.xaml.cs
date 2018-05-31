using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using cpuGui;
using CpuProject;

namespace CpuGui
{
	/// <summary>
	/// Interaction logic for CpuView.xaml
	/// </summary>
	public partial class CpuView : Window
	{
		public readonly CpuModel CpuModel = new CpuModel();


		public CpuView()
		{
			InitializeComponent();

		}

		public void Update(Cpu cpu)
		{
			for (int i = 0; i < cpu.Regs.Count; i++)
			{
				var row = new RegDataGridRow
				{
					regName = $"r{i}",
					regValue = cpu.Regs[i].ToString()
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

			CpuModel.CurrentInstruction = cpu.GetCurrentInstruction();
			//cpu.
		}

	}
}
