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
		if (weapon1 == "Rock" && weapon2 == "Scissors")
			return "Player1";
		if (weapon1 == "Paper" && weapon2 == "Rock")
			return "Player1";
		if (weapon1 == "Scissors" && weapon2 == "Paper")
			return "Player1";
		if (weapon1 == "Paper" && weapon2 == "Scissors")
			return "Player2";
		if (weapon1 == "Rock" && weapon2 == "Paper")
			return "Player2";
		if (weapon1 == "Scissors" && weapon2 == "Rock")
			return "Player2";
		if (weapon1 == "Rock" && weapon2 == "Rock")
			return "Tie";
		return "No Game";
	}
}
