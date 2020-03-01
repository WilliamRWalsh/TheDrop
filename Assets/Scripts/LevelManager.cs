using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public float fallSpeed { get; private set; }

	[SerializeField]
	private PlayerController playerController;

	[SerializeField]
	private WallController cloudWallController;
	[SerializeField]
	private MenuCloudController menuCloudController;

	[SerializeField]
	private Generator generator;

	[SerializeField]
	private SpawnRateData start_0;

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
		StartBtn.OnStart += StartGame;
		RestartBtn.OnRestart += RestartGame;
		MenuCloudController.OnStartReady += StartReadyEvent;
		fallSpeed = -15;
	}

	void Update()
	{
		UpdateGeneratorSpawnRateData(start_0);
	}

	#region Event Handlers
	private void RestartGame()
	{
		fallSpeed = -25;
		cloudWallController.gameObject.SetActive(true);
		menuCloudController.gameObject.SetActive(true);
	}

	private void StartGame()
	{
		fallSpeed = 10;
		playerController.gameObject.SetActive(true);
	}

	private void StartReadyEvent()
	{
		fallSpeed = -15;
	}
	#endregion
	#region Generator Updates
	private void UpdateGeneratorSpawnRateData(SpawnRateData spawnRateData){
		generator.SetSpawnRateData(spawnRateData);
	}
	#endregion
}

