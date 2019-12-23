using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {


	/* Spawned Object Params */
	#region Object Params
	private bool isGeneratingClouds;
	private SpawnRateData cloudSpawnRate;

	private bool isGeneratingDrops;
	private SpawnRateData dropSpawnRate;

	private bool isGeneratingBirds;
	private SpawnRateData birdSpawnRate;

	private bool isGeneratingLightening;
	private SpawnRateData lighteningSpawnRate;

	private bool isGeneratingUFOs;
	private SpawnRateData ufoSpawnRate;

	private bool isGeneratingAcidDrops;
	private SpawnRateData acidDropSpawnRate;
	#endregion


	/* Spawn Rates */
	[SerializeField]
	private float cloudGenerateTimer = 0;
	[SerializeField]
	private float dropGenerateTimer = 0;
	[SerializeField]
	private float acidDropGenerateTimer = 3;
	[SerializeField]
	private float birdGenerateTimer = 0;
	[SerializeField]
	private float UFOGenerateTimer = 4;
	[SerializeField]
	private float lightningGenerateTimer = 0;

	private static Generator _instance;

	public static Generator Instance { get { return _instance; } }

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
	}

	private void Update()
	{
		Generate();
	}

	private void Generate()
	{
		if (isGeneratingClouds)
			GenerateClouds();
		if (isGeneratingDrops)
			GenerateDrops();
		if (isGeneratingBirds)
			GenerateBirds();
		if (isGeneratingUFOs)
			GenerateUFOs();
		if (isGeneratingLightening)
			GenerateLightening();
		if (isGeneratingAcidDrops)
			GenerateAcidDrops();
	}


	#region Set Params
	public void SetDropParams(bool isEnabled, SpawnRateData spawnRateData)
	{
		isGeneratingDrops = isEnabled;
		dropSpawnRate = spawnRateData;
	}

	public void SetCloudParams(bool isEnabled, SpawnRateData spawnRateData)
	{
		isGeneratingClouds = isEnabled;
		cloudSpawnRate = spawnRateData;
	}

	public void SeBirdParams(bool isEnabled, SpawnRateData spawnRateData)
	{
		isGeneratingBirds = isEnabled;
		birdSpawnRate = spawnRateData;
	}

	public void SetAcidDropParams(bool isEnabled, SpawnRateData spawnRateData)
	{
		isGeneratingAcidDrops = isEnabled;
		acidDropSpawnRate = spawnRateData;
	}

	public void SetLighteningParams(bool isEnabled, SpawnRateData spawnRateData)
	{
		isGeneratingLightening = isEnabled;
		lighteningSpawnRate = spawnRateData;
	}

	public void SetUFOParams(bool isEnabled, SpawnRateData spawnRateData)
	{
		isGeneratingUFOs = isEnabled;
		ufoSpawnRate = spawnRateData;
	}
	#endregion

	#region Generate Objects
	private void GenerateDrops() // (0.5f, 2f)
	{
		
		if (dropGenerateTimer <= 0)
		{
			dropGenerateTimer = Random.Range(dropSpawnRate.MinTimeBetween, dropSpawnRate.MaxTimeBetween);

			/* Get droplet from pool and set to active */
			DropletPool.Instance.Get().gameObject.SetActive(true);
		}

		dropGenerateTimer -= Time.deltaTime;
	}

	private void GenerateClouds() // (3f, 6f)
	{
		if (cloudGenerateTimer <= 0)
		{
			cloudGenerateTimer = Random.Range(cloudSpawnRate.MinTimeBetween, cloudSpawnRate.MaxTimeBetween);

			/* Get cloud from pool and set to active */
			CloudPool.Instance.Get().gameObject.SetActive(true);
		}

		cloudGenerateTimer -= Time.deltaTime;
	}

	private void GenerateBirds() // (1.5f, 4f)
	{
		if (birdGenerateTimer <= 0)
		{
			birdGenerateTimer = Random.Range(birdSpawnRate.MinTimeBetween, birdSpawnRate.MaxTimeBetween);

			/* Get bird from pool and set to active */
			BirdPool.Instance.Get().gameObject.SetActive(true);
		}

		birdGenerateTimer -= Time.deltaTime;
	}

	private void GenerateUFOs() // (5, 10)
	{
		if (UFOGenerateTimer <= 0)
		{
			UFOGenerateTimer = Random.Range(ufoSpawnRate.MinTimeBetween, ufoSpawnRate.MaxTimeBetween);  // TODO: pull these out to serialized fields

			/* Get bird from pool and set to active */
			UFOPool.Instance.Get().gameObject.SetActive(true);
		}

		UFOGenerateTimer -= Time.deltaTime;
	}

	private void GenerateLightening() // (5, 5)
	{
		if (lightningGenerateTimer <= 0)
		{
			lightningGenerateTimer = Random.Range(lighteningSpawnRate.MinTimeBetween, lighteningSpawnRate.MaxTimeBetween);  // TODO: pull these out to serialized fields

			/* Get bird from pool and set to active */
			LightningPool.Instance.Get().gameObject.SetActive(true);
		}

		lightningGenerateTimer -= Time.deltaTime;
	}

	private void GenerateAcidDrops() // (2f, 3f)
	{
		if (acidDropGenerateTimer <= 0)
		{
			acidDropGenerateTimer = Random.Range(acidDropSpawnRate.MinTimeBetween, acidDropSpawnRate.MaxTimeBetween); // TODO: pull these out to serialized fields

			/* Get droplet from pool and set to active */
			AcidDropletPool.Instance.Get().gameObject.SetActive(true);
		}

		acidDropGenerateTimer -= Time.deltaTime;
	}
	#endregion
}

