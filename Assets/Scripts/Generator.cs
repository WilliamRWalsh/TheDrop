using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {


	/* Spawned Object Params */
	private SpawnRateData spawnRate;

	#region Timers
	private float cloudGenerateTimer = 0;
	private float dropGenerateTimer = 0;
	private float acidDropGenerateTimer = 0;
	private float birdGenerateTimer = 0;
	private float UFOGenerateTimer = 0;
	private float lightningGenerateTimer = 0;
	#endregion

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
		if (spawnRate.isDropletsEnabled)
			GenerateDrops();
		if (spawnRate.isCloudsEnabled)
			GenerateClouds();
		if (spawnRate.isBirdsEnabled)
			GenerateBirds();
		if (spawnRate.isUFOsEnabled)
			GenerateUFOs();
		if (spawnRate.isLighteningEnabled)
			GenerateLightening();
		if (spawnRate.isAcidDropletsEnabled)
			GenerateAcidDrops();
	}


	#region Set spawnRate
	public void SetSpawnRateData(SpawnRateData spawnRateData)
	{
		spawnRate = spawnRateData;
	}
	#endregion

	#region Generate Objects

	private void GenerateDrops()
	{
		if (dropGenerateTimer <= 0)
		{
			dropGenerateTimer = Random.Range(spawnRate.dropletsMinTimeBetween, spawnRate.dropletsMaxTimeBetween);

			/* Get droplet from pool and set to active */
			DropletController droplet = DropletPool.Instance.Get();
			droplet.SetIsFromAbove(spawnRate.isDropletsFromAbove);
			droplet.gameObject.SetActive(true);
		}

		dropGenerateTimer -= Time.deltaTime;
	}

	private void GenerateClouds()
	{

		if (cloudGenerateTimer <= 0)
		{
			cloudGenerateTimer = Random.Range(spawnRate.cloudsMinTimeBetween, spawnRate.cloudsMaxTimeBetween);

			/* Get cloud from pool and set to active */
			CloudPool.Instance.Get().gameObject.SetActive(true);
		}

		cloudGenerateTimer -= Time.deltaTime;
	}

	private void GenerateBirds()
	{
		if (birdGenerateTimer <= 0)
		{
			birdGenerateTimer = Random.Range(spawnRate.birdsMinTimeBetween, spawnRate.birdsMaxTimeBetween);

			/* Get bird from pool and set to active */
			BirdPool.Instance.Get().gameObject.SetActive(true);
		}

		birdGenerateTimer -= Time.deltaTime;
	}

	private void GenerateUFOs()
	{
		if (UFOGenerateTimer <= 0)
		{
			UFOGenerateTimer = Random.Range(spawnRate.UFOsMinTimeBetween, spawnRate.UFOsMaxTimeBetween);  // TODO: pull these out to serialized fields

			/* Get bird from pool and set to active */
			UFOPool.Instance.Get().gameObject.SetActive(true);
		}

		UFOGenerateTimer -= Time.deltaTime;
	}

	private void GenerateLightening()
	{
		if (lightningGenerateTimer <= 0)
		{
			lightningGenerateTimer = Random.Range(spawnRate.lighteningMinTimeBetween, spawnRate.lighteningMaxTimeBetween);  // TODO: pull these out to serialized fields

			/* Get bird from pool and set to active */
			LightningPool.Instance.Get().gameObject.SetActive(true);
		}

		lightningGenerateTimer -= Time.deltaTime;
	}

	private void GenerateAcidDrops()
	{
		if (acidDropGenerateTimer <= 0)
		{
			acidDropGenerateTimer = Random.Range(spawnRate.acidDropletsMinTimeBetween, spawnRate.acidDropletsMaxTimeBetween); // TODO: pull these out to serialized fields

			/* Get droplet from pool and set to active */
			AcidDropletPool.Instance.Get().gameObject.SetActive(true);
		}

		acidDropGenerateTimer -= Time.deltaTime;
	}
	#endregion

}
