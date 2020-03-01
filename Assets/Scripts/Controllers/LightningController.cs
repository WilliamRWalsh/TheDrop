using UnityEngine;
using EZCameraShake;
public class LightningController : BaseObjectController
{
	private float aliveTimer = 0;
	private bool struck = false;
	protected override void OnEnable()
	{
		aliveTimer = 0;
		SetAlpha(.3f);
		GetComponent<BoxCollider2D>().enabled = false;
		SetPosition();
		struck = false;
	}

	protected override void FixedUpdate()
	{
		aliveTimer += Time.deltaTime;

		if (aliveTimer > 0.7f && !struck)
			LightningStrike();

		if (aliveTimer > 1.5f)
			gameObject.SetActive(false);
	}

	private void LightningStrike()
	{
		SetAlpha(1f);
		AudioSource.PlayClipAtPoint(GetComponent<AudioSource>().clip, new Vector3(0, 0, 0));
		GetComponent<BoxCollider2D>().enabled = true;
		CameraShaker.Instance.ShakeOnce(2f, 1.5f, .5f, 1f);
	}

	private void SetAlpha(float alpha)
	{
		struck = true;
		Color color = GetComponent<SpriteRenderer>().color;
		color.a = alpha;
		GetComponent<SpriteRenderer>().color = color;
	}

	protected override void SetPosition()
	{
		Vector3 newPosition = this.transform.position;
		newPosition.x = Random.Range(-4.79f, 8.5f);
		newPosition.y = 1.8f;

		this.transform.position = newPosition;
	}
}
