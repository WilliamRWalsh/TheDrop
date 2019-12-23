using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Spawn Rate Level")]
public class SpawnRateData : ScriptableObject
{
	public float MinTimeBetween;
	public float MaxTimeBetween;
}