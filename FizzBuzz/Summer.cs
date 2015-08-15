using NUnit.Framework;
using System;

[TestFixture]
public class SummerTest
{
	[TestCase (1, 1)]
	[TestCase (2, 2)]
	[TestCase (10, 1)]
	[TestCase (19, 1)]
	[TestCase (12345, 6)]
	public void MyMethod(int input, int expected)
	{
		int result = MySum.MyMethod (input);
		Assert.That (result, Is.EqualTo(expected));
	}
}

public class MySum
{
	public static int MyMethod(int i)
	{
		return MyLoop(i);
	}

	public static int MyLoop(int i)
	{
		while (i > 9) {
			char[] number = MyArrayMaker (i);
			i = 0;
			for (var x = 0; x < number.Length; x++) {
				i = MyDigitSummer (i, Convert.ToInt32 (number [x]));
			}
		}

		return i;
	}

	public static char[] MyArrayMaker(int i)
	{
		return i.ToString ().ToCharArray ();
	}

	public static int MyDigitSummer(int i, int x)
	{
		return i + (x - 48);	
	}
}


