﻿using NUnit.Framework;
using System;

[TestFixture]
public class FizzBuzzTests
{
	[TestCase (1, "1")]
	[TestCase (2, "2")]
	[TestCase (3, "Fizz")]
	[TestCase (5, "Buzz")]
	[TestCase (6, "Fizz")]
	[TestCase (10, "Buzz")]
	[TestCase (15, "FizzBuzz")]
	public void Translate(int input, string expected)
	{
		string result = Translator.Translate (input);
		Assert.That (result, Is.EqualTo(expected));
	}
}

public class Translator
{
	public static string Translate(int i)
	{
		string returnString = string.Empty;
		returnString = Fizzy (i, returnString);
		returnString = Buzzy (i, returnString);
		returnString = Other (i, returnString);
		return returnString;

	}

	public static string Fizzy(int i, string returnString)
	{
		return returnString + (ShouldFizz (i) ? "Fizz" : string.Empty);
	}

	public static string Buzzy(int i, string returnString)
	{
		return returnString + (ShouldBuzz (i) ? "Buzz" : string.Empty);
	}

	public static string Other(int i, string returnString)
	{
		return string.IsNullOrEmpty (returnString) ? i.ToString () : returnString;
	}

	public static bool ShouldBuzz(int i)
	{
		return i % 5 == 0;
	}
	public static bool ShouldFizz(int i)
	{
		return i % 3 == 0;
	}
}