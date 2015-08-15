using NUnit.Framework;
using System;
using System.Collections.Generic;

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
		var translator = new FizzBuzz ();
		string result = translator.Translate(input);
		Assert.That (result, Is.EqualTo(expected));
	}

	[TestCase (1, "1")]
	[TestCase (2, "2")]
	[TestCase (3, "3")]
	[TestCase (7, "Monkey")]
	[TestCase (14, "Monkey")]
	public void TranslateDifferentRules(int input, string expected)
	{
		var translator =  new FizzBuzz ();
		translator.Rules = new List<Func<int, string, string>> 
		{
			(i, returnString) => returnString + ((i % 7 == 0) ? "Monkey" : string.Empty),
			(i, returnString) => string.IsNullOrEmpty(returnString) ? i.ToString() : returnString
		};
		string result = translator.Translate (input);
		Assert.That (result, Is.EqualTo (expected));
	}
}

public class FizzBuzz
{
	public IList<Func<int, string, string>> Rules = new List<Func<int, string, string>>
	{
		Fizzy, Buzzy, Other
	};

	public string Translate(int i)
	{
		string returnString = string.Empty;
		foreach (var rule in Rules)
		{
			returnString = rule(i, returnString);
		}

		return returnString;
	}

	public static bool ShouldFizz(int i)
	{
		return i % 3 == 0;
	}

	public static bool ShouldBuzz(int i)
	{
		return i % 5 == 0;
	}

	public static string Fizzy(int i, string returnString)
	{
		return returnString + (ShouldFizz (i) ? "Fizz" : string.Empty);
	}

	public static string Buzzy(int i, string returnString)
	{
		return returnString + (ShouldBuzz (i) ? "Buzz" : string.Empty);
	}

	public static string Other (int i, string returnString)
	{
		return string.IsNullOrEmpty (returnString) ? i.ToString () : returnString;
	}
}