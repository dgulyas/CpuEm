using System;

namespace cpuEm
{
	public static class Alu
	{
		public static int calc(int op, int regA, int regB, int newPc, int oldPc)
		{
			switch (op)
			{
				case 0:
					return regA + regB;
				case 1:
					return regA - regB;
				case 2:
					return -1*regA;
				case 3:
					return regA;
				case 4:
					//and
					throw new Exception($"Operation And (num 4) is not supported");
				case 5:
					//or
					throw new Exception($"Operation Or (num 5) is not supported");
				case 6:
					//boolean inverter
					return regA == 0 ? 1 : 0; 
				case 7:
					//greater than
					return regA > regB ? 1 : 0;
				case 8:
					//equal
					return regA == regB ? 1 : 0;
				case 9:
					//less than
					return regA < regB ? 1 : 0;
				case 10:
					//jump if >
					return regA > regB ? newPc : oldPc + 1;
				case 11:
					//jump if =
					return regA == regB ? newPc : oldPc + 1;
				case 12:
					//jump if <
					return regA < regB ? newPc : oldPc + 1;
				default:
					throw new Exception($"Operation number {op} is not supported");
			}

		}

	}
}
