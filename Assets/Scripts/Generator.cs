using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

	[SerializeField]
	private float cloudCreateTimer = 0;
	[SerializeField]
	private float dropCreateTimer = 0;
	[SerializeField]
	private float acidDropCreateTimer = 0;
	[SerializeField]
	private float birdCreateTimer = 0;
	[SerializeField]
	private float UFOCreateTimer = 10;
	[SerializeField]
	private float lightningCreateTimer = 1;

	private void Update()
	{
		MakeClouds();
		MakeDrops();
		MakeBirds();
		MakeUFOs();
		MakeLightning();
		MakeAcidDrops();
	}

	private void MakeDrops()
	{
		if (dropCreateTimer <= 0)
		{
			dropCreateTimer = Random.Range(0.5f, 2f); // TODO: pull these out to serialized fields

			/* Get droplet from pool and set to active */
			DropletPool.Instance.Get().gameObject.SetActive(true);
		}

		dropCreateTimer -= Time.deltaTime;
	}

	//TODO: Random sprites, random size, random z value
	private void MakeClouds()
	{
		if (cloudCreateTimer <= 0)
		{
			cloudCreateTimer = Random.Range(3f, 6f);  // TODO: pull these out to serialized fields

			/* Get cloud from pool and set to active */
			CloudPool.Instance.Get().gameObject.SetActive(true);
		}

		cloudCreateTimer -= Time.deltaTime;
	}

	private void MakeBirds()
	{
		if (birdCreateTimer <= 0)
		{
			birdCreateTimer = Random.Range(1.5f, 4f);  // TODO: pull these out to serialized fields

			/* Get bird from pool and set to active */
			BirdPool.Instance.Get().gameObject.SetActive(true);
		}

		birdCreateTimer -= Time.deltaTime;
	}

	private void MakeUFOs()
	{
		if (UFOCreateTimer <= 0)
		{
			UFOCreateTimer = Random.Range(5, 10);  // TODO: pull these out to serialized fields

			/* Get bird from pool and set to active */
			UFOPool.Instance.Get().gameObject.SetActive(true);
		}

		UFOCreateTimer -= Time.deltaTime;
	}

	private void MakeLightning()
	{
		if (lightningCreateTimer <= 0)
		{
			lightningCreateTimer = Random.Range(5, 5);  // TODO: pull these out to serialized fields

			/* Get bird from pool and set to active */
			LightningPool.Instance.Get().gameObject.SetActive(true);
		}

		lightningCreateTimer -= Time.deltaTime;
	}

	private void MakeAcidDrops()
	{
		if (acidDropCreateTimer <= 0)
		{
			acidDropCreateTimer = Random.Range(2f, 3f); // TODO: pull these out to serialized fields

			/* Get droplet from pool and set to active */
			AcidDropletPool.Instance.Get().gameObject.SetActive(true);
		}

		acidDropCreateTimer -= Time.deltaTime;
	}
}

