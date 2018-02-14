﻿using System;

namespace cpuEm
{
	public static class Alu
	{
		public static int calc(int op, int arg1, int arg2, int newPc, int oldPc)
		{
			switch (op)
			{
				case 0:
					return arg1 + arg2;
				case 1:
					return arg1 - arg2;
				case 2:
					return -1*arg1;
				case 3:
					return arg1;
				case 4:
					//and
					throw new Exception("Operation And (num 4) is not supported");
				case 5:
					//or
					throw new Exception("Operation Or (num 5) is not supported");
				case 6:
					//boolean inverter
					return arg1 == 0 ? 1 : 0; 
				case 7:
					//greater than
					return arg1 > arg2 ? 1 : 0;
				case 8:
					//equal
					return arg1 == arg2 ? 1 : 0;
				case 9:
					//less than
					return arg1 < arg2 ? 1 : 0;
				case 10:
					//jump if >
					return arg1 > arg2 ? newPc : oldPc + 1;
				case 11:
					//jump if =
					return arg1 == arg2 ? newPc : oldPc + 1;
				case 12:
					//jump if <
					return arg1 < arg2 ? newPc : oldPc + 1;
				default:
					throw new Exception($"Operation number {op} is not supported");
			}
		}

	}
}
