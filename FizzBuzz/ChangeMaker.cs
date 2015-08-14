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
	[TestCase (1.41, new int[] {1, 1, 1, 1, 1}, TestName="Test 5")]
	[TestCase (1.69, new int[] {1, 2, 1, 1, 4}, TestName="Test 6")]
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
		if (Dollar(int_amount) > 0) 
		{
			list.Add (Dollar(int_amount));
		}
		int_amount = int_amount % 100;
		if (Quarter(int_amount) > 0) 
		{
			list.Add (Quarter(int_amount));
		}
		int_amount = int_amount % 25;
		if (Dime(int_amount) > 0) 
		{
			list.Add (Dime(int_amount));
		}
		int_amount = int_amount % 10;
		if (Nickel(int_amount) > 0) 
		{
			list.Add (Nickel(int_amount));
		}
		int_amount = int_amount % 5;
		if (Penny(int_amount) > 0)
		{
			list.Add (Penny(int_amount));
		}

		return  list.ToArray();
	}

	public static int Dollar(int amount)
	{
		return amount / 100;
	}

	public static int Quarter(int amount)
	{
		return amount / 25;
	}

	public static int Dime(int amount)
	{
		return amount / 10;
	}

	public static int Nickel(int amount)
	{
		return amount / 5;
	}

	public static int Penny(int amount)
	{
		return amount / 1;
	}
}


