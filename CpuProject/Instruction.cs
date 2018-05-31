using System;

namespace CpuProject
{
	public class Instruction
	{
		//An instruction is a binary string. It's divided into sections.

		//0-7   literal value. Treated as register 14.
		//8-11  destination reg. The register that the result goes into.
		//12-15 new PC value/Reg C. Used to do jump operations.
		//16-19 Reg B. The second argument going to the alu.
		//20-23 Reg A. The first argument going to the alu.
		//24-27 Function. The operation the alu should perform on the arguments.
		//28    Load from keyboard or alu result.

		public string Binary;

		public int Literal;
		public int DestReg;
		public int NewPcValue;
		public int RegB;
		public int RegA;
		public int Function;
		public int KeybOrAlu;

		public int BinaryWidth = 29; //29 binary digits

		private int literalWidth = 8;
		private int regWidth = 4;
		private int funcWidth = 4;
		private int keybOrAluWidth = 1;

		public Instruction(string binaryArg)
		{ //todo error checking
			Binary = binaryArg;
			Literal = Convert.ToInt32(binaryArg.Substring(0, literalWidth), 2);
			DestReg = Convert.ToInt32(binaryArg.Substring(8, regWidth), 2);
			NewPcValue = Convert.ToInt32(binaryArg.Substring(12, regWidth), 2);
			RegB = Convert.ToInt32(binaryArg.Substring(16, regWidth), 2);
			RegA = Convert.ToInt32(binaryArg.Substring(20, regWidth), 2);
			Function = Convert.ToInt32(binaryArg.Substring(24, funcWidth), 2);
			KeybOrAlu = Convert.ToInt32(binaryArg.Substring(28, keybOrAluWidth), 2);
		}

		public Instruction() { }

		public Instruction(int literal, int destReg, int newPcValue, int regA, int regB, int func, int kOrA)
		{ //todo error checking
			Binary = "";

			Literal = literal;
			Binary += ToBinaryWithPadding(literal, literalWidth);

			DestReg = destReg;
			Binary += ToBinaryWithPadding(destReg, regWidth);

			NewPcValue = newPcValue;
			Binary += ToBinaryWithPadding(newPcValue, regWidth);

			RegB = regB;
			Binary += ToBinaryWithPadding(regB, regWidth);

			RegA = regA;
			Binary += ToBinaryWithPadding(regA, regWidth);

			Function = func;
			Binary += ToBinaryWithPadding(func, funcWidth);

			KeybOrAlu = kOrA;
			Binary += ToBinaryWithPadding(kOrA, keybOrAluWidth);
		}

		//returns a string that fits under the Binary string.
		//The numbers should line up with the matching digits in the BinaryString.
		public string DecLine
		{
			get
			{
				var line = "";

				line += Literal.ToString().PadLeft(literalWidth);
				line += DestReg.ToString().PadLeft(regWidth);
				line += NewPcValue.ToString().PadLeft(regWidth);
				line += RegB.ToString().PadLeft(regWidth);
				line += RegA.ToString().PadLeft(regWidth);
				line += Function.ToString().PadLeft(funcWidth);
				line += KeybOrAlu.ToString().PadLeft(keybOrAluWidth);

				return line;
			}
			set
			{
				var a = value;
			}
		}

		public string GetDescriptionLine()
		{
			return "     lit Des rPC  rB  rA fun ";
		}

		private static string ToBinaryWithPadding(int num, int minWidth)
		{
			return Convert.ToString(num, 2).PadLeft(minWidth, '0');
		}

	}
}
