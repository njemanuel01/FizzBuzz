using NUnit.Framework;
using System;


[TestFixture ()]
public class FizzBuzzTests
{
	[TestCase (1, "1")]
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
		return "1";
	}
}

