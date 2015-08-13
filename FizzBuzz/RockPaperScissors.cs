using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;

[TestFixture]
public class RockPaperScissorsTests
{
	[TestCase ("Rock", "Scissors", "Player1 Wins")]
	[TestCase ("Paper", "Rock", "Player1 Wins")]
	[TestCase ("Scissors", "Paper", "Player1 Wins")]
	[TestCase ("Paper", "Scissors", "Player2 Wins")]
	[TestCase ("Rock", "Paper", "Player2 Wins")]
	[TestCase ("Scissors", "Rock", "Player2 Wins")]
	[TestCase ("Rock", "Rock", "Tie")]
	[TestCase ("Paper", "Paper", "Tie")]
	public void WinCondition (string input1, string input2, string expected)
	{
		var game = new RockPaperScissors ();
		string result = game.winCondition (input1, input2);
		Assert.That (result, Is.EqualTo(expected));
	}

	[TestCase ("Rock", "Spock", "Player2 Wins")]
	[TestCase ("Lizard", "Paper", "Player1 Wins")]
	public void WinConditionDifferentRules(string input1, string input2, string expected)
	{
		var game = new RockPaperScissors ();
		game.Rules = new List<Func<string, string, string>> 
		{
			(weapon1, weapon2) => (weapon1 == "Rock" && weapon2 == "Spock") ? "Player2 Wins" : string.Empty,
			(weapon1, weapon2) => (weapon1 == "Lizard" && weapon2 == "Paper") ? "Player1 Wins" : string.Empty
		};
	}

	[TestCase ("Rock", true)]
	[TestCase ("Bob", false)]
	[TestCase ("Paper", true)]
	[TestCase ("Scissors", true)]
	[TestCase ("rock", true)]
	[TestCase ("bob", false)]
	public void ValidEntry (string input, bool expected)
	{
		var game = new RockPaperScissors ();
		bool result = game.validEntry (input);
		Assert.That (result, Is.EqualTo(expected));
	}
}

public class RockPaperScissors
{
	public IList<Func<string, string, string>> Rules = new List<Func<string, string, string>>
	{
		Player1Wins, Player2Wins, Tie
	};

	public string winCondition(string weapon1, string weapon2)
	{
		string returnString = string.Empty;
		foreach (var rule in Rules) 
		{
			if (returnString == string.Empty)
			{
				returnString = rule (weapon1, weapon2);
			}
		}

		return returnString;
	}

	public bool validEntry(string entry)
	{
		string test_entry = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(entry);
		if (test_entry == "Rock" || test_entry == "Paper" || test_entry == "Scissors") return true;
		return false;
	}

	public static string Player1Wins(string weapon1, string weapon2)
	{
		if ((weapon1 == "Rock" && weapon2 == "Scissors") || (weapon1 == "Paper" && weapon2 == "Rock") || (weapon1 == "Scissors" && weapon2 == "Paper"))
			return "Player1 Wins";
		return string.Empty;
	}

	public static string Player2Wins(string weapon1, string weapon2)
	{
		if ((weapon1 == "Paper" && weapon2 == "Scissors") || (weapon1 == "Scissors" && weapon2 == "Rock") || (weapon1 == "Rock" && weapon2 == "Paper"))
			return "Player2 Wins";
		return string.Empty;
	}

	public static string Tie(string weapon1, string weapon2)
	{
		if (weapon1 == weapon2)
			return "Tie";
		return string.Empty;
	}
}
