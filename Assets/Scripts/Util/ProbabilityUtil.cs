using UnityEngine;

public static class ProbabilityUtil
{
	public static bool PercentChance(float percent)
	{
		return true ? Random.Range(0, 100) < percent : false;
	}
}
