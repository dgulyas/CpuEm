using System.Collections.Generic;

namespace cpuEm
{
	public class Cpu
	{
		public List<int> Regs = new List<int>(16);
		public List<Instruction> Instructions;

		private const int PcReg = 15; //The last register is the program counter.

		public void Tick()
		{
			var ci = Instructions[Regs[15]]; //current instruction

			Regs[ci.DestReg] = Alu.calc(ci.Function, ci.RegA, ci.RegB, ci.NewPcValue, Regs[PcReg]);
		}

	}
}
