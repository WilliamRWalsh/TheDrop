using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

	#region SpawnRateData
	[SerializeField]
	private SpawnRateData spawnRateDropLow;
	[SerializeField]
	private SpawnRateData spawnRateDropMedium;
	[SerializeField]
	private SpawnRateData spawnRateDropHigh;

	[SerializeField]
	private SpawnRateData spawnRateCloudLow;
	[SerializeField]
	private SpawnRateData spawnRateCloudMedium;
	[SerializeField]
	private SpawnRateData spawnRateCloudHigh;

	[SerializeField]
	private SpawnRateData spawnRateBirdLow;
	[SerializeField]
	private SpawnRateData spawnRateBirdMedium;
	[SerializeField]
	private SpawnRateData spawnRateBirdHigh;

	[SerializeField]
	private SpawnRateData spawnRateAcidLow;
	[SerializeField]
	private SpawnRateData spawnRateAcidMedium;
	[SerializeField]
	private SpawnRateData spawnRateAcidHigh;

	[SerializeField]
	private SpawnRateData spawnRateLighteningLow;
	[SerializeField]
	private SpawnRateData spawnRateLighteningMedium;
	[SerializeField]
	private SpawnRateData spawnRateLighteningHigh;

	[SerializeField]
	private SpawnRateData spawnRateUFOLow;
	[SerializeField]
	private SpawnRateData spawnRateUFOMedium;
	[SerializeField]
	private SpawnRateData spawnRateUFOHigh;
	#endregion

	private bool generatorToggle = false;

	private static LevelManager _instance;

	public static LevelManager Instance { get { return _instance; } }

	private void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			_instance = this;
		}

		/* Listeners */
		GameStateManager.OnStartGame += OnStartGame;
	}

	private void FixedUpdate()
	{
		UpdateGenerator();
	}

	/* This is a really bad way to change the level based off time */
	private void UpdateGenerator()
	{

		/* I hate this */
		if (!generatorToggle && GameStateManager.Instance.timer < 5f)
		{
			/* Drops (LOW) - Clouds (LOW) */
			Generator.Instance.SetDropParams(true, spawnRateDropLow);
			Generator.Instance.SetCloudParams(true, spawnRateCloudLow);

			generatorToggle = true;
		} else if (generatorToggle && GameStateManager.Instance.timer > 5f && GameStateManager.Instance.timer < 10f)
		{
			/* Birds (LOW) */
			Generator.Instance.SeBirdParams(true, spawnRateBirdLow);

			generatorToggle = false;
		} else if (!generatorToggle && GameStateManager.Instance.timer > 10f && GameStateManager.Instance.timer < 15f)
		{
			Generator.Instance.SetCloudParams(true, spawnRateCloudMedium);

			generatorToggle = true;
		} else if (generatorToggle && GameStateManager.Instance.timer > 15f && GameStateManager.Instance.timer < 20f)
		{
			/* Drops (Meddium) - Lightening (LOW) */
			Debug.Log("Light");
			Generator.Instance.SetDropParams(true, spawnRateDropMedium);
			Generator.Instance.SetLighteningParams(true, spawnRateLighteningLow);

			generatorToggle = false;
		} else if (!generatorToggle && GameStateManager.Instance.timer > 20f && GameStateManager.Instance.timer < 25f)
		{
			/* Birds (Medium) */
			Generator.Instance.SeBirdParams(true, spawnRateBirdMedium);
			Generator.Instance.SetAcidDropParams(true, spawnRateAcidLow);

			generatorToggle = true;
		}
		else if (generatorToggle && GameStateManager.Instance.timer > 25f && GameStateManager.Instance.timer < 30f)
		{
			/* UFOs (Low) */
			Generator.Instance.SetUFOParams(true, spawnRateUFOLow);
			Generator.Instance.SetLighteningParams(true, spawnRateLighteningMedium);
			
			generatorToggle = false;
		}
		else if (!generatorToggle && GameStateManager.Instance.timer > 30f && GameStateManager.Instance.timer < 35f)
		{
			/* UFOs (Low) */
			Generator.Instance.SeBirdParams(true, spawnRateBirdHigh);
			Generator.Instance.SetAcidDropParams(true, spawnRateAcidMedium);

			generatorToggle = true;
		}
		else if (generatorToggle && GameStateManager.Instance.timer > 30f && GameStateManager.Instance.timer < 35f)
		{
			/* UFOs (Low) */
			Generator.Instance.SetUFOParams(true, spawnRateUFOMedium);
			Generator.Instance.SetCloudParams(true, spawnRateCloudHigh);

			generatorToggle = false;
		}


	}

	private void OnStartGame()
	{
		Generator.Instance.SetDropParams(true, spawnRateDropLow);
		Generator.Instance.SetCloudParams(true, spawnRateCloudLow);
		Generator.Instance.SetAcidDropParams(false, null);
		Generator.Instance.SetLighteningParams(false, null);
		Generator.Instance.SetUFOParams(false, null);
	}
}

