using NUnit.Framework;
using System;

[TestFixture]
public class ChangeMakerTests
{
	[Test]
	public void ChangeMakerOne()
	{
		int result = ChangeMaker.MakeChange(1);
		Assert.That (result, Is.EqualTo(1));
	}
}

public class ChangeMaker
{
	public static int MakeChange (int i)
	{
		return 1;
	}
}


