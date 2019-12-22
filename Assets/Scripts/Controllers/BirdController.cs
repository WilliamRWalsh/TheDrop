﻿using UnityEngine;

public class BirdController : BaseObjectController
{
	private bool isMakeSound;
	private bool isFromAbove;

	public void AcidDeath()
	{
		GetComponent<SpriteRenderer>().color = Color.green;
		GetComponent<SpriteRenderer>().flipY = true;
		speedX = 0;
		GetComponent<Animator>().enabled = false;
	}

	protected override void OnEnable()
	{
		base.OnEnable();
		GetComponent<SpriteRenderer>().color = Color.white;
		isMakeSound = ProbabilityUtil.PercentChance(20f);
		GetComponent<Animator>().enabled = true;
		GetComponent<SpriteRenderer>().flipY = false;

		isFromAbove = ProbabilityUtil.PercentChance(100);
	}

	private void LateUpdate()
	{
		if (transform.position.y > disableThresholdY)
			BirdPool.Instance.ReturnToPool(this);

		if (isMakeSound && transform.position.y > -3)
		{
			isMakeSound = false;
			GetComponent<AudioSource>().Play();
		}
	}

	protected override void SetPosition()
	{
		float xOffset = Camera.main.orthographicSize * cameraSizeToXRange;

		float yValue = -Camera.main.orthographicSize * cameraSizeToYRange;
		if (isFromAbove)
			yValue = 17f;

		Vector3 newPosition = this.transform.position;
		newPosition.y = yValue;
		newPosition.x = Random.Range(-xOffset - 6, -xOffset - 3);

		if (isFlipped)
			newPosition.x *= -1;

		this.transform.position = newPosition;
	}

	protected override void SetSpeeds()
	{
		Vector2 targetPosition = getTargetPosition();

		speedOffsetY = Random.Range(minSpeedOffsetY, maxSpeedOffsetY);

		/* This is why SetPosition must be called before SetSpeeds */
		float deltaY = targetPosition.y - this.transform.position.y;
		float deltaX = targetPosition.x - this.transform.position.x;
		float m = deltaY / deltaX;

		speedX = (GameStateManager.Instance.fallSpeed + speedOffsetY) / m;
		if (isFromAbove)
			speedX = (GameStateManager.Instance.fallSpeed + speedOffsetY - 16) / m;

		if (isFlipped)
			speedX *= -1;
	}

	protected override void Move()
	{
		if (isFromAbove) { 
			transform.Translate(speedX * Time.deltaTime, (GameStateManager.Instance.fallSpeed + speedOffsetY - 16) * Time.deltaTime, 0);
		} else
		{
			base.Move();
		}

	}

	private Vector2 getTargetPosition()
	{
		float xOffset = Camera.main.orthographicSize * cameraSizeToXRange;

		Vector2 targetPosition = this.transform.position;
		targetPosition.x = Random.Range(-xOffset, xOffset);
		targetPosition.y = 0;

		return targetPosition;
	}
}
