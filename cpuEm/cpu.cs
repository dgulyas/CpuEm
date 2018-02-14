using System.Collections.Generic;

namespace cpuEm
{
	public class Cpu
	{
		public List<int> Regs = new List<int>(16);
		public List<Instruction> Instructions;
		public List<int> ConsoleBuffer = new List<int>();

		private readonly List<int> Ram = new List<int>();

		private const int PcReg = 15; //The last register is the program counter.
		private const int ConsoleReg = 14; //Writing to this reg writes to the console.
		private const int LiteralReg = 14; //Reading from this reg reads the literal in the instruction
		private const int RamReg = 13; //Reading and writing to this reg acesses the ram
		private const int RamAddressReg = 12;// Normal reg, but also the ram address that's currently accessed

		public void Tick()
		{
			//Load special regs with their values
			var ci = GetCurrentInstruction();
			Regs[LiteralReg] = ci.Literal;
			Regs[RamReg] = Ram[Regs[RamAddressReg]];

			//Do this cycles computation
			Regs[ci.DestReg] = Alu.calc(ci.Function, Regs[ci.RegA], Regs[ci.RegB], Regs[ci.NewPcValue], Regs[PcReg]);

			//If the destination reg was a special reg, write the result to the correct place.
			if (ci.DestReg != PcReg)
			{
				Regs[PcReg]++;
			}

			if (ci.DestReg == RamReg)
			{
				Ram[Regs[RamAddressReg]] = Regs[RamReg];
			}

			if (ci.DestReg == ConsoleReg)
			{
				ConsoleBuffer.Add(Regs[ci.DestReg]);
			}

			//TODO: Don't have keyboard input yet.
		}

		public Instruction GetCurrentInstruction()
		{
			return Instructions[Regs[15]];
		}

		public void LoadProgram(List<string> binaryProgram)
		{
			foreach (var binaryInstruction in binaryProgram)
			{
				Instructions.Add(new Instruction(binaryInstruction));
			}
		}

	}
}
