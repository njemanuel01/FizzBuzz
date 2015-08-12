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
		if (i % 3 == 0) return "Fizz";
		return i.ToString();
	}
}

