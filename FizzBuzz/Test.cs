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
		if (ShouldFizz(i)) 
			return "Fizz";
		if (ShouldBuzz(i))
			return "Buzz";
		return i.ToString();
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

