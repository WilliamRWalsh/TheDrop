using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
	public float fallSpeed { get; private set; }

	private float eventTimer = 15f;
	private float basicTimer = 15f;

	private enum State
	{
		Wait,
		Basic,
		Event,
	}
	private State state = State.Wait;
	
	#region  Serialized Fields
	[SerializeField]
	private PlayerController playerController;

	[SerializeField]
	private WallController cloudWallController;
	[SerializeField]
	private MenuCloudController menuCloudController;

	[SerializeField]
	private Generator generator;

	#region Spawn Rate Data
	/* Basic */
	[SerializeField]
	private SpawnRateData menu_rain;

	[SerializeField]
	private SpawnRateData start_game;

	[SerializeField]
	private SpawnRateData add_acid_rain;

	[SerializeField]
	private SpawnRateData basic_1;

	/* Events */
	[SerializeField]
	private SpawnRateData flock_of_birds;

	[SerializeField]
	private SpawnRateData heavy_rain;

	[SerializeField]
	private SpawnRateData thunder_storm;
	
	[SerializeField]
	private SpawnRateData ufo_invasion;
	#endregion

	#endregion

	// private SpawnRateData[] events = {flock_of_birds, heavy_rain, thunder_storm, ufo_invasion};

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
		PlayerController.OnDeath += PlayerDeathEvent;

		fallSpeed = -15;

		UpdateGeneratorSpawnRateData(menu_rain);
	}


	void Update()
	{
		switch(state)
		{
			case State.Wait:
				UpdateGeneratorSpawnRateData(menu_rain);
				break;
			case State.Basic:
				basicTimer -= Time.deltaTime;
				if (basicTimer <= 0)
					PickEvent();

				break;
			case State.Event:
				eventTimer -= Time.deltaTime;
				if (eventTimer <= 0)
					IncreaseBasic();
				break;
		}
	}

	private void PickEvent()
	{
		state = State.Event;
		eventTimer = 15f;
		SpawnRateData spawnRateData = PickRandomEvent();
		UpdateGeneratorSpawnRateData(spawnRateData);
	}

	private SpawnRateData PickRandomEvent()
	{
		SpawnRateData[] events = {flock_of_birds, heavy_rain, thunder_storm, ufo_invasion};
		int index = (int) Random.Range(0, events.Length - 1);
		return events[index];
	}

	private void IncreaseBasic()
	{
		state = State.Basic;
		basicTimer = 15f;
		SpawnRateData spawnRateData = basic_1;
		UpdateGeneratorSpawnRateData(spawnRateData);
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
		state = State.Basic;
		basicTimer = 15f;
		UpdateGeneratorSpawnRateData(start_game);
	}

	private void StartReadyEvent()
	{
		fallSpeed = -15;
	}

	private void PlayerDeathEvent(){
		state = State.Wait;
	}
	#endregion

	#region Generator
	private void UpdateGeneratorSpawnRateData(SpawnRateData spawnRateData){
		generator.SetSpawnRateData(spawnRateData);
	}
	#endregion
}

