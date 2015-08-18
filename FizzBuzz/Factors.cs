using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class FactorsTest
{
	[TestCase (1, new int[] {1})]
	[TestCase (2, new int[] {1, 2})]
	[TestCase (3, new int[] {1, 3})]
	[TestCase (4, new int[] {1, 2, 4})]
	[TestCase (8, new int[] {1, 2, 8})]
	public void Factoring(int input, int[] expected)
	{
		int[] result = Factors.Factored (input);
		Assert.That (result, Is.EqualTo(expected));
	}
}

public class Factors
{
	public static int[] Factored(int i)
	{
		List<int> factors = new List<int>();
		for (var x = 1; x <= i; x++) {
			if (i % x == 0) {
				factors.Add (x);
			}
		}
		return factors.ToArray();
	}
}


