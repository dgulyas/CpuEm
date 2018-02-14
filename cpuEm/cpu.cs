using System.Collections.Generic;

namespace cpuEm
{
	public class Cpu
	{
		public List<int> Regs = new List<int>(16);
		public List<Instruction> Instructions;
		public List<int> ConsoleBuffer = new List<int>();

		private const int PcReg = 15; //The last register is the program counter.
		private const int ConsoleReg = 14; //Writing to this reg writes to the console.

		public void Tick()
		{
			var ci = GetCurrentInstruction();

			Regs[ci.DestReg] = Alu.calc(ci.Function, ci.RegA, ci.RegB, ci.NewPcValue, Regs[PcReg]);
			if (ci.DestReg == ConsoleReg)
			{
				ConsoleBuffer.Add(Regs[ci.DestReg]);
			}
		}

		public Instruction GetCurrentInstruction()
		{
			return Instructions[Regs[15]];
		}

	}
}
