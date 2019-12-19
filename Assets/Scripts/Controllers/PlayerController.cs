using System;
using UnityEngine;
using EZCameraShake;

// TO DO: Refactor how to gain and lose size/speed - probabl;y move the camera size to the camera method
//	on bucket hit I need to let another script handle the score (GSM?)


public class PlayerController : MonoBehaviour
{

	public static event Action OnDeath = delegate { };

	[SerializeField]
	public int size { get; private set; }

	[SerializeField]
	private Vector3 startScale;

	private bool isAcid = false;
	private float acidCountDown = 0;

	private void Start()
	{
		SetScale();
	}

	private void Update()
	{
		CheckTilt();

		if (isAcid)
			AcidCountdown();

	}

	private void AcidCountdown()
	{
		acidCountDown -= Time.deltaTime;
		if (acidCountDown < 0)
			ReturnPlayerToNormal();
	}

	private void ReturnPlayerToNormal()
	{
		isAcid = false;
		GetComponent<SpriteRenderer>().color = Color.white;
	}

	private void KeepPlayerInsideCameraView()
	{
		Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
		pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);

		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}

	private void CheckTilt()
	{
		transform.Translate(Input.acceleration.x, 0, 0);
		KeepPlayerInsideCameraView();
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		DropletController dropletController = collision.GetComponent<DropletController>();
		if (dropletController != null)
			SuckUpDroplet(dropletController);

		BirdController birdController = collision.GetComponent<BirdController>();
		if (birdController != null)
		{
			if (isAcid)
			{
				birdController.AcidDeath();
			}
			else
			{
				EnemyHit();
			}
			
		}

		UFOController ufoController = collision.GetComponent<UFOController>();
		if (ufoController != null)
		{
			if (isAcid)
			{
				ufoController.AcidDeath();
			}
			else
			{
				EnemyHit();
			}
		}

		LightningController lightningController = collision.GetComponent<LightningController>();
		if (lightningController != null)
			EnemyHit();

		AcidDropletController acidDropletController = collision.GetComponent<AcidDropletController>();
		if (acidDropletController != null) // TODO: Get rid of acidDroplet prefab by using only droplets with bool for acid
			SuckUpAcidDroplet(acidDropletController);
	}

	private void SuckUpDroplet(DropletController dropletController)
	{
		size += 1;
		SetScale();
		AudioSource.PlayClipAtPoint(dropletController.GetComponent<AudioSource>().clip, new Vector3(0, 0, 1));
		DropletPool.Instance.ReturnToPool(dropletController);
	}

	private void SuckUpAcidDroplet(AcidDropletController acidDropletController)
	{
		size += 1;
		SetScale();
		AudioSource.PlayClipAtPoint(acidDropletController.GetComponent<AudioSource>().clip, new Vector3(0, 0, 1));
		AcidDropletPool.Instance.ReturnToPool(acidDropletController);
		TurnPlayerToAcid();
	}

	private void TurnPlayerToAcid()
	{
		isAcid = true;
		GetComponent<SpriteRenderer>().color = Color.green;
		acidCountDown = 5;
	}

	private void EnemyHit()
	{
		
		CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
		AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, new Vector3(0, 0, 1));
		if (size == 0)
		{
			OnDeath();
			this.gameObject.SetActive(false);
		}
		else
		{
			size = 0;
			SetScale();
		}
	}

	private void SetScale()
	{
		transform.localScale = startScale +  (new Vector3(0.1f, 0.1f, 0) * size);
	}

}
