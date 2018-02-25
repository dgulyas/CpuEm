using System.Linq;
using NUnit.Framework;
using cpuEm;

namespace tests
{
	[TestFixture]
	public class CpuTests
	{
		[Test]
		public void AdditionTest()
		{
			var cpu = new Cpu();
			
			var instruct = new Instruction
			{
				Function = (int)Alu.Ops.Add,
				RegA = 0,
				RegB = 1,
				DestReg = 2,
				KeybOrAlu = (int)Cpu.KBoardOrAlu.alu
			};

			cpu.Regs[0] = 3;
			cpu.Regs[1] = 2;

			cpu.Instructions.Add(instruct);

			cpu.Tick();

			Assert.AreEqual(5, cpu.Regs[2]);
		}

		[Test]
		public void ConsoleTest()
		{
			var cpu = new Cpu();
			var instruct = new Instruction
			{
				Function = (int)Alu.Ops.PassThrough,
				RegA = 5,
				DestReg = Cpu.ConsoleReg,
				KeybOrAlu = (int) Cpu.KBoardOrAlu.alu
			};

			cpu.Regs[5] = 10;
			cpu.Instructions.Add(instruct);

			cpu.Tick();

			Assert.AreEqual(10, cpu.ConsoleBuffer.First());
		}

	}
}
