using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class ChangeMakerTests
{
	[TestCase (1,new int[] {1}, TestName="Test 1")]
	[TestCase (1.25,new int[] {1, 1}, TestName="Test 2")]
	[TestCase (1.35, new int[] {1, 1, 1}, TestName="Test 3")]
	[TestCase (1.40, new int[] {1, 1, 1, 1}, TestName="Test 4")]
	public void ChangeMaker(decimal input, int[] expected)
	{
		int[] result = Changer.MakeChange(input);
		Assert.That (result, Is.EqualTo(expected));
	}
}

public class Changer
{
	public static int[] MakeChange(decimal i)
	{
		List<int> list = new List<int> ();
		decimal amount = i * 100;
		int int_amount = Convert.ToInt32 (amount);
		if (int_amount / 100 > 0) {
			list.Add (int_amount / 100);
		}
		int_amount = int_amount % 100;
		if (int_amount / 25 > 0) 
		{
			list.Add (int_amount / 25);
		}
		int_amount = int_amount % 25;
		if (int_amount / 10 > 0) {
			list.Add (int_amount / 10);
		}

		return  list.ToArray();
	}
}


