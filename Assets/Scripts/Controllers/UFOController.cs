using UnityEngine;

public class UFOController : BaseObjectController
{
	private float waitToMove = 7;
	private Vector3 startingPosition;
	private Vector3 firstTargetPosition;
	private Vector3 secondTargetPosition;

	public void AcidDeath()
	{
		GetComponent<SpriteRenderer>().color = Color.green;
		speedOffsetY = -14;
		speedX = 0;
		GetComponent<Animator>().enabled = false;

		waitToMove=-4;
	}
	protected override void OnEnable()
	{
		GetComponent<SpriteRenderer>().color = Color.white;
		SetPosition();
		firstTargetPosition = getTargetPosition(10);
		secondTargetPosition = getTargetPosition(-10);
		waitToMove = 7;
		GetComponent<AudioSource>().Play();
		GetComponent<Animator>().enabled = true;

	}

	protected override void SetPosition()
	{
		float xOffset = Camera.main.orthographicSize * cameraSizeToXRange;

		Vector3 newPosition = this.transform.position;
		newPosition.y = -10;
		newPosition.x = Random.Range(-xOffset + 2, xOffset - 2);

		this.transform.position = newPosition;
		startingPosition = newPosition;
	}

	protected override void Move()
	{
		waitToMove -= Time.deltaTime;
		if (waitToMove <= 5 && waitToMove > 0)
			this.transform.position = Vector3.Lerp(this.transform.position, firstTargetPosition, Time.deltaTime);

		if (waitToMove < 0)
			this.transform.position = Vector3.Lerp(this.transform.position, secondTargetPosition, Time.deltaTime);

		if (waitToMove < -5)
			UFOPool.Instance.ReturnToPool(this);
	}

	private Vector2 getTargetPosition(float y)
	{
		float xOffset = Camera.main.orthographicSize * cameraSizeToXRange;

		Vector2 targetPosition = this.transform.position;
		targetPosition.x = Random.Range(-xOffset + 2, xOffset - 2);
		targetPosition.y = y;

		return targetPosition;
	}
}
