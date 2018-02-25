using System.Collections.Generic;
using System.Linq;

namespace cpuEm
{
	public class Cpu
	{
		public List<int> Regs = new List<int>(16);
		public List<Instruction> Instructions = new List<Instruction>();
		public List<int> ConsoleBuffer = new List<int>();

		public readonly List<int> Ram = new List<int>();

		public const int PcReg = 15; //The last register is the program counter.
		public const int ConsoleReg = 14; //Writing to this reg writes to the console.
		public const int LiteralReg = 14; //Reading from this reg reads the literal in the instruction
		public const int RamReg = 13; //Reading and writing to this reg acesses the ram
		public const int RamAddressReg = 12;// Normal reg, but also the ram address that's currently accessed

		public Cpu()
		{
			for (int i = 0; i < 16; i++)
			{
				Regs.Add(0);
			}

			for (int i = 0; i < 256; i++)
			{
				Ram.Add(0);
			}
		}

		public void Tick()
		{
			//Load special regs with their values
			var ci = GetCurrentInstruction();
			Regs[LiteralReg] = ci.Literal;
			Regs[RamReg] = Ram[Regs[RamAddressReg]];

			//Do this cycles computation
			Regs[ci.DestReg] = Alu.calc(ci.Function, Regs[ci.RegA], Regs[ci.RegB], Regs[ci.NewPcValue], Regs[PcReg]);

			//If the destination reg was a special reg, write the result to the correct place.
			if (ci.DestReg != PcReg) //wasn't a jump instruction
			{
				Regs[PcReg]++;
			}

			if (ci.DestReg == RamReg) //write result to ram
			{
				Ram[Regs[RamAddressReg]] = Regs[RamReg];
			}

			if (ci.DestReg == ConsoleReg) //write result to console
			{
				ConsoleBuffer.Add(Regs[ConsoleReg]);
			}

			//TODO: Don't have keyboard input yet.
		}

		public Instruction GetCurrentInstruction()
		{
			return Instructions[Regs[PcReg]];
		}

		public void LoadProgram(List<string> binaryProgram)
		{
			foreach (var binaryInstruction in binaryProgram)
			{
				Instructions.Add(new Instruction(binaryInstruction));
			}
		}

		public int PopConsoleBuffer()
		{
			var value = ConsoleBuffer.First();
			ConsoleBuffer.RemoveAt(0);
			return value;
		}

		public enum KBoardOrAlu
		{
			kBoard = 0,
			alu = 1
		}

	}
}
