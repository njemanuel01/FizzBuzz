using NUnit.Framework;
using System;


[TestFixture ()]
public class FizzBuzzTests
{
	[TestCase (1, "1")]
	[TestCase (2, "2")]
	[TestCase (3, "Fizz")]
	[TestCase (5, "Buzz")]
	[TestCase (6, "Fizz")]
	[TestCase (10, "Buzz")]
	[TestCase (15, "FizzBuzz")]
	public void Translate (int input, string expected)
	{
		string result = Translator.Translate (input);
		Assert.That(result, Is.EqualTo(expected));
	}
}

public class Translator
{
	public static string Translate(int i)
	{
		string returnString = string.Empty;
		if (ShouldFizz(i)) returnString += "Fizz";
		if (ShouldBuzz(i)) returnString += "Buzz";
		if (string.IsNullOrEmpty(returnString))
		{
			returnString = i.ToString();
		}
		return returnString;
	}

	private static bool ShouldBuzz(int i)
	{
		return i % 5 == 0;
	}

	private static bool ShouldFizz(int i)
	{
		return i % 3 == 0;
	}
}

