using System.Collections.Generic;

namespace cpuEm
{
	public class Cpu
	{
		public List<int> Regs = new List<int>(16);
		public List<Instruction> Instructions;
		public List<int> ConsoleBuffer = new List<int>();

		private List<int> Ram = new List<int>();

		private const int PcReg = 15; //The last register is the program counter.
		private const int ConsoleReg = 14; //Writing to this reg writes to the console.
		private const int LiteralReg = 14; //Reading from this reg reads the literal in the instruction
		private const int RamReg = 13; //Reading and writing to this reg acesses the ram
		private const int RamAddressReg = 12;// Normal reg, but also the ram address that's currently accessed

		public void Tick()
		{
			var ci = GetCurrentInstruction();
			Regs[LiteralReg] = ci.Literal;
			Regs[RamReg] = Ram[Regs[RamAddressReg]];

			Regs[ci.DestReg] = Alu.calc(ci.Function, Regs[ci.RegA], Regs[ci.RegB], Regs[ci.NewPcValue], Regs[PcReg]);


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
