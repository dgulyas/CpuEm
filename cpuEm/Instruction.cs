using System;

namespace cpuEm
{
	public class Instruction
	{
		//An instruction is a binary string. It's divided into sections.

		//0-7   literal value. Treated as register 14.
		//8-11  destination reg. The register that the result goes into.
		//12-15 new PC value/ Reg C. Used to do jump operations.
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
		
		public Instruction(string binary)
		{
			Binary = binary;
			Literal = Convert.ToInt32(binary.Substring(0, 8));
			DestReg = Convert.ToInt32(binary.Substring(8, 4));
			NewPcValue = Convert.ToInt32(binary.Substring(12, 4));
			RegB = Convert.ToInt32(binary.Substring(16, 4));
			RegA = Convert.ToInt32(binary.Substring(20, 4));
			Function = Convert.ToInt32(binary.Substring(24, 4));
			KeybOrAlu = Convert.ToInt32(binary.Substring(28, 1));
		}
	}
}
