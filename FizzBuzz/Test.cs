using NUnit.Framework;
using System;


[TestFixture ()]
public class FizzBuzzTests
{
	[TestCase (1, "1")]
	[TestCase (2, "2")]
	[TestCase (3, "Fizz")]
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
		if (i == 3) return "Fizz";
		return i.ToString();
	}
}

