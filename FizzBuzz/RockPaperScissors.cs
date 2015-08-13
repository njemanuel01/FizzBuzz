using NUnit.Framework;
using System;

[TestFixture]
public class RockPaperScissorsTests
{
	[TestCase ("Rock", "Scissors", "Player1")]
	[TestCase ("Paper", "Rock", "Player1")]
	[TestCase ("Scissors", "Paper", "Player1")]
	[TestCase ("Paper", "Scissors", "Player2")]
	[TestCase ("Rock", "Paper", "Player2")]
	[TestCase ("Scissors", "Rock", "Player2")]
	[TestCase ("Rock", "Rock", "Tie")]
	public void WinCondition (string input1, string input2, string expected)
	{
		string result = RockPaperScissors.winCondition (input1, input2);
		Assert.That (result, Is.EqualTo(expected));
	}
}

public class RockPaperScissors
{
	public static string winCondition(string weapon1, string weapon2)
	{
		if (Player1Wins(weapon1, weapon2))
			return "Player1";
		if (Player2Wins(weapon1, weapon2))
			return "Player2";
		if (Tie(weapon1, weapon2))
			return "Tie";
		return "No Game";
	}

	public static bool Player1Wins(string weapon1, string weapon2)
	{
		if (weapon1 == "Rock" && weapon2 == "Scissors")
			return true;
		if (weapon1 == "Paper" && weapon2 == "Rock")
			return true;
		if (weapon1 == "Scissors" && weapon2 == "Paper")
			return true;
		return false;
	}

	public static bool Player2Wins(string weapon1, string weapon2)
	{
		if (weapon1 == "Rock" && weapon2 == "Paper")
			return true;
		if (weapon1 == "Paper" && weapon2 == "Scissors")
			return true;
		if (weapon1 == "Scissors" && weapon2 == "Rock")
			return true;
		return false;
	}

	public static bool Tie(string weapon1, string weapon2)
	{
		if (weapon1 == weapon2)
			return true;
		return false;
	}
}
