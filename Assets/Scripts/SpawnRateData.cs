using UnityEngine;
using UnityEditor;

[CreateAssetMenu(menuName = "Spawn Rate Level")]
public class SpawnRateData : ScriptableObject
{
	#region UFOs
	public bool isDropletsOverrided;
	public bool isDropletsEnabled;
	public bool isDropletsFromAbove;
	public float dropletsMinTimeBetween;
	public float dropletsMaxTimeBetween;
	#endregion

	#region Acid Droplets
	public bool isAcidDropletsOverrided;
	public bool isAcidDropletsEnabled;
	public float acidDropletsMinTimeBetween;
	public float acidDropletsMaxTimeBetween;
	#endregion

	#region Clouds
	public bool isCloudsOverrided;
	public bool isCloudsEnabled;
	public float cloudsMinTimeBetween;
	public float cloudsMaxTimeBetween;
	#endregion

	#region Birds
	public bool isBirdsOverrided;
	public bool isBirdsEnabled;
	public float birdsMinTimeBetween;
	public float birdsMaxTimeBetween;
	#endregion

	#region Lightening
	public bool isLighteningOverrided;
	public bool isLighteningEnabled;
	public float lighteningMinTimeBetween;
	public float lighteningMaxTimeBetween;
	#endregion

	#region UFOs
	public bool isUFOsOverrided;
	public bool isUFOsEnabled;
	public float UFOsMinTimeBetween;
	public float UFOsMaxTimeBetween;
	#endregion

}